using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner1 : MonoBehaviour {

	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left up door
	// 4 --> need right up door
	// 5 --> need left down door
	// 6 --> need right down door

	private RoomTemplates1 templates;
	private int rand;
	private bool spawned = false;
	

	private float waitTime = 2;
	

	void Start(){
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates1>();
		Invoke("Spawn", 0.5f);
		
		
	}


	void Spawn(){

			if(openingDirection == 1 && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a RU door.
				rand = Random.Range(0, templates.RURooms.Length);
				Instantiate(templates.RURooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}
			else if(openingDirection == 2 && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a RD door.
				rand = Random.Range(0, templates.RDRooms.Length);
				Instantiate(templates.RDRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}	
			else if(openingDirection == 3 && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a LU door.
				rand = Random.Range(0, templates.LURooms.Length);
				Instantiate(templates.LURooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}
			else if(openingDirection == 4 && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a LD door.
				rand = Random.Range(0, templates.LDRooms.Length);
				Instantiate(templates.LDRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}	
			



			if(openingDirection == 1 && templates.Rooms >= templates.roomCap && spawned == false){
				// Need to spawn a room with a RT Exit door.
				rand = Random.Range(0, templates.RUExitRooms.Length);
				Instantiate(templates.RUExitRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			} else if(openingDirection == 2 && templates.Rooms >= templates.roomCap && spawned == false){
				// Need to spawn a room with a RB Exit door.
				rand = Random.Range(0, templates.RDExitRooms.Length);
				Instantiate(templates.RDExitRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			} else if(openingDirection == 3 && templates.Rooms >= templates.roomCap && spawned == false){
				// Need to spawn a room with a LT Exit door.
				rand = Random.Range(0, templates.LUExitRooms.Length);
				Instantiate(templates.LUExitRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			} else if(openingDirection == 4 && templates.Rooms >= templates.roomCap && spawned == false){
				// Need to spawn a room with a LB Exit door.
				rand = Random.Range(0, templates.LDExitRooms.Length);
				Instantiate(templates.LDExitRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}
			else
		
		spawned = true;
		
	}

	
void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("SpawnPoint")){
			
			spawned = true;
		}
	}
	
}