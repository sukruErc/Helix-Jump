using UnityEngine;

namespace HelixJump.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraSettings _cameraSettings;
        private void Start()
        {
            _cameraSettings.CameraPosition = transform.position.y;
        }

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, _cameraSettings.CameraPosition, transform.position.z), _cameraSettings.CameraMoveSmooth);
        }
    }
}