using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prodigy
{
    public class LevelVariation : MonoBehaviour
    {
        [SerializeField] private GameObject [] levelVariation;
        [SerializeField] private GameObject [] inSceneObjects;
        private Vector3 pos;
        private int rand;

        private void Awake() {
            
            pos = new Vector3(0, 0, 0);
            rand = Random.Range(0, levelVariation.Length);
            GameObject level = Instantiate(levelVariation[rand], pos, Quaternion.identity) as GameObject;
            level.transform.SetParent(this.gameObject.transform, false);
            inSceneObjects[rand].SetActive(true);
        }
    }
}
