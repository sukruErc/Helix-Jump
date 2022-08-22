using UnityEngine;

namespace HelixJump.Bar
{
    public class BarController : MonoBehaviour
    {
        [SerializeField] BarSettings _barSettings;
        private int _randomObjectChange, _randomObjectFalse, _randomLoopAmount;

        [SerializeField] private MeshRenderer[] _bars;

        private void Start()
        {
            _randomLoopAmount = Random.Range(1, 4);
            for (int i = 0; i < _randomLoopAmount; i++)
            {
                _randomObjectChange = Random.Range(0, _bars.Length);
                _randomObjectFalse = Random.Range(0, _bars.Length);

                _bars[_randomObjectChange].material = _barSettings.BarDeadZoneMaterial;
                _bars[_randomObjectChange].gameObject.tag = "DeadZone";

                _bars[_randomObjectFalse].gameObject.SetActive(false);
            }
        }
    }
}