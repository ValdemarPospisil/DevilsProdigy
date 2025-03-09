using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prodigy
{
    public class ChestSpawner : MonoBehaviour
    {
        private ChestTemplates templates;
        private int rand;
	    private bool spawned = false;
        private float waitTime = 1;

         void Start(){
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<ChestTemplates>();
		Invoke("Spawn", 0.5f);
        }


        void Spawn(){
		
		
			if(spawned == false){
				
				rand = Random.Range(0, templates.Chests.Length);
				Instantiate(templates.Chests[rand], transform.position, Quaternion.identity);
				spawned = true;
			}
			else
		
		spawned = true;
		
	
		
		
	}
    }
}
