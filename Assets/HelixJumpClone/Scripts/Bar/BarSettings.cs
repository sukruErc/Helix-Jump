using UnityEngine;

namespace HelixJump.Bar
{
    [CreateAssetMenu(menuName = "HelixJumpClone/Bar/BarSettings")]
    public class BarSettings : ScriptableObject
    {
        [SerializeField] private Material _barDeadZoneMaterial;

        public Material BarDeadZoneMaterial => _barDeadZoneMaterial;
    }
}