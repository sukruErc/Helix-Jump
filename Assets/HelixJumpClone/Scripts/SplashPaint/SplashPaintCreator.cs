using System.Collections.Generic;
using UnityEngine;

namespace HelixJump.SplashPaint
{
    public class SplashPaintCreator : MonoBehaviour
    {
        public List<GameObject> paintObjects;

        public Transform paintParent;

        [SerializeField] private GameObject _paintPrefab;

        private int _randomRotation;

        private void Start()
        {
            for (int i = 0; i < 20; i++)
            {
                _randomRotation = Random.Range(0, 360);
                paintObjects.Add(Instantiate(_paintPrefab));
                paintObjects[i].SetActive(false);
                paintObjects[i].transform.position = paintParent.position;
                paintObjects[i].transform.rotation = Quaternion.Euler(90, _randomRotation, 0);
                paintObjects[i].transform.parent = paintParent;
            }
        }
    }
}