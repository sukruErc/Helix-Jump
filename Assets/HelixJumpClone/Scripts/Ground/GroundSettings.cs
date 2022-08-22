using UnityEngine;

namespace HelixJump.Ground
{
    [CreateAssetMenu(menuName = "HelixJumpClone/Ground/GroundSettings")]
    public class GroundSettings : ScriptableObject
    {
        [SerializeField] private GameObject _barObjectPrefab;
        public GameObject BarObjectPrefab { get { return _barObjectPrefab; } }

        [SerializeField] private int _groundCreateCount;
        public int GroundCreateCount { get { return _groundCreateCount; } set { _groundCreateCount = value; } }

        [SerializeField] private float _groundCreateDistance;
        public float GroundCreateDistance { get { return _groundCreateDistance; } }
    }
}