using UnityEngine;

namespace HelixJump.Rotate
{
    public class RotateController : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private GameObject _rotateObject;
        [SerializeField] private float _rotateSpeed;

        private Vector3 _rotAngles, _firstInputPosition, _lastInputPosition;

        private void Update()
        {
            if (_gameManager.state == GameManager.GameState.Play)
            {
                if (Input.GetMouseButtonDown(0)) _firstInputPosition = Input.mousePosition;

                if (Input.GetMouseButton(0)) _lastInputPosition = Input.mousePosition;

                _rotAngles = _lastInputPosition - _firstInputPosition;

                _rotateObject.transform.rotation = Quaternion.Euler(0, _rotAngles.x * _rotateSpeed, 0);
            }
        }
    }
}