using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prodigy
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemyTemplates templates;
	    private int rand;
	    private bool spawned = false;
        public int EnemyType;
        private float waitTime = 1;
        
        void Awake(){
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<EnemyTemplates>();
		Invoke("Spawn", 0.5f);
        }
        void Spawn(){
		
		
			if(EnemyType == 1 && spawned == false){
				
				rand = Random.Range(0, templates.Enemy1.Length);
				Instantiate(templates.Enemy1[rand], transform.position, Quaternion.identity);
				spawned = true;
			} else if(EnemyType == 2 && spawned == false){
				
				rand = Random.Range(0, templates.Enemy2.Length);
				Instantiate(templates.Enemy2[rand], transform.position, Quaternion.identity);
				spawned = true;
			} else if(EnemyType == 3 && spawned == false){
				
				rand = Random.Range(0, templates.Enemy3.Length);
				Instantiate(templates.Enemy3[rand], transform.position, Quaternion.identity);
				spawned = true;
			} else if(EnemyType == 4 && spawned == false){
				
				rand = Random.Range(0, templates.Enemy4.Length);
				Instantiate(templates.Enemy4[rand], transform.position, Quaternion.identity);
				spawned = true;
			} 
			else
		
		spawned = true;
		
	
		
		
	}
    }
}
