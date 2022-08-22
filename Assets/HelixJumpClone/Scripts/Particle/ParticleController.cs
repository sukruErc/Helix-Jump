using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelixJump.Particle
{
    public class ParticleController : MonoBehaviour
    {
        private const byte JUMPFX = 0, DEADFX = 1;
        [SerializeField] private ParticleSystem[] _particleFx;

        public void JumpFxPlay()
        {
            _particleFx[JUMPFX].Play();
        }
        public void DeadFxPlay()
        {
            _particleFx[DEADFX].Play();
        }
    }
}