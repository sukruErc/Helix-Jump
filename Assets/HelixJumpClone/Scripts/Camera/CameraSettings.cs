using UnityEngine;

namespace HelixJump.Camera
{
    [CreateAssetMenu(menuName = "HelixJumpClone/Camera/CameraSettings")]
    public class CameraSettings : ScriptableObject
    {
        [SerializeField] private float _cameraPosition;
        public float CameraPosition { get { return _cameraPosition; } set { _cameraPosition = value; } }

        [SerializeField] private float _cameraMoveSmooth;
        public float CameraMoveSmooth { get { return _cameraMoveSmooth; } set { _cameraMoveSmooth = value; } }
    }
}