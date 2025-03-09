using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prodigy
{
    public class DestroyInSeconds : MonoBehaviour
    {

        [SerializeField] private float secondsToDestroy = 1f;
        // Start is called before the first frame update
        void OnEnable()
        {
            Destroy(gameObject, secondsToDestroy);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
