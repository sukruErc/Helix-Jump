using System.Collections.Generic;
using UnityEngine;

namespace HelixJump.Ground
{
    public class GroundCreator : MonoBehaviour
    {
        [SerializeField] private GroundSettings _groundSettings;

        [SerializeField] private Transform _groundParentObject;

        private List<GameObject> _barObjects = new List<GameObject>();

        private float _groundNewPositions, _groundNewRotation;

        private void Start()
        {
            _groundNewPositions = 4;
            for (int i = 0; i < _groundSettings.GroundCreateCount; i++)
            {
                _barObjects.Add(Instantiate(_groundSettings.BarObjectPrefab));
                _barObjects[i].SetActive(false);

                _barObjects[i].transform.parent = _groundParentObject;
                _barObjects[i].transform.position = new Vector3(0, _groundNewPositions, 0);
                _groundNewPositions -= _groundSettings.GroundCreateDistance;

                _groundNewRotation = Random.Range(0, 360);
                _barObjects[i].transform.rotation = Quaternion.Euler(90, _groundNewRotation, 0);
                _barObjects[i].SetActive(true);
            }
        }
    }
}