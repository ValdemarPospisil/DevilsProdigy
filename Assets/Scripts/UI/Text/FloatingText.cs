using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prodigy
{   
    public class FloatingText : MonoBehaviour
    {

        Transform unit;
        Transform canvas;

        public Vector3 offset;

        // Start is called before the first frame update
        void Start()
        {
            unit = transform.parent;
            canvas = GameObject.FindFirstObjectByType<Canvas>().transform;

            transform.SetParent(canvas);

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = unit.position + offset;
        }
    }
}
