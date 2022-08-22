using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using HelixJump.Camera;
using HelixJump.Level;
using HelixJump.SplashPaint;
using HelixJump.Score;
using HelixJump.Ground;
using HelixJump.UI;
using HelixJump.Particle;

namespace HelixJump.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Scriptable Objects
        [Header("ScriptableObject")]
        [SerializeField] private CameraSettings _cameraSettings;
        [SerializeField] private GroundSettings _groundSettings;
        #endregion

        #region Manager Objects
        [Header("Managers")]
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private UIManager _uIManager;
        [SerializeField] private SplashPaintCreator _splashPaintCreator;
        [SerializeField] private ScoreManager _scoreManager;
        [SerializeField] private ParticleController _particleController;
        #endregion

        private Rigidbody _ballRigidbody;
        private bool _isGrounded;
        [SerializeField] private float _jumpSpeed;

        private int _scoreCuttler;

        private int paintCounter = 0;

        [SerializeField] private Slider _levelSlider;
        private float _sliderCount;

        private void Start()
        {
            _ballRigidbody = GetComponent<Rigidbody>();
            _sliderCount = (100f / (_groundSettings.GroundCreateCount + 1)) / 100f;
        }
        private void Update()
        {
            if (_gameManager.state == GameManager.GameState.Play && _isGrounded)
            {
                _ballRigidbody.velocity = new Vector2(_ballRigidbody.velocity.x, _jumpSpeed);
                _isGrounded = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
                _scoreCuttler = 0;
                _splashPaintCreator.paintObjects[paintCounter].SetActive(true);
                _splashPaintCreator.paintObjects[paintCounter].transform.parent = collision.transform;
                paintCounter++;
                _particleController.JumpFxPlay();

                if (paintCounter == 19) paintCounter = 0;
            }

            if (collision.gameObject.CompareTag("DeadZone"))
            {
                _particleController.DeadFxPlay();
                _gameManager.state = GameManager.GameState.Failed;
                _uIManager.FailedPanelActive();
            }

            if (collision.gameObject.CompareTag("Finish"))
            {
                _gameManager.state = GameManager.GameState.Finish;
                _uIManager.FinishPanelActive();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Down"))
            {
                _cameraSettings.CameraPosition -= 3;
                _scoreCuttler += 1;
                _scoreManager.ScoreIncrease(_levelManager.LevelCounter * _scoreCuttler);

                _levelSlider.value += _sliderCount;

                SplashPaintObjectReset();
                
                paintCounter = 0;
            }
        }

        private void SplashPaintObjectReset()
        {
            for (int i = 0; i < _splashPaintCreator.paintObjects.Count; i++)
            {
                _splashPaintCreator.paintObjects[i].SetActive(false);
                _splashPaintCreator.paintObjects[i].transform.position = _splashPaintCreator.paintParent.position;
                _splashPaintCreator.paintObjects[i].transform.parent = _splashPaintCreator.paintParent;
            }
        }
    }
}