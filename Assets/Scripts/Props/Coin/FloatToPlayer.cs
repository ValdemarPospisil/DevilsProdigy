using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prodigy
{
    public class FloatToPlayer : MonoBehaviour
    {

        private GameObject player;
        public float speed;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            if(player != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        
        }
    }
}
