using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelixJump
{
    public class GameManager : MonoBehaviour
    {
        public GameState state;
        public enum GameState
        {
            Play,
            Finish,
            Failed
        }
    }
}