using UnityEngine;

namespace HelixJump.Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private int _levelCounter;
        public int LevelCounter { get { return _levelCounter; } }
    }
}