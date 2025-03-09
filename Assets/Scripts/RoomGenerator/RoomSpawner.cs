using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left up door
	// 4 --> need right up door
	// 5 --> need left down door
	// 6 --> need right down door

	private RoomTemplates templates;
	private int rand;
	private bool spawned = false;
	

	private float waitTime = 1;
	

	void Start(){
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.5f);
		
		
	}


	void Spawn(){

			    


			if(openingDirection == 1 && templates.Rooms >= templates.curveRoomStart && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a BOTTOM CURVE door.
				rand = Random.Range(0, templates.bottomCurveRooms.Length);
				Instantiate(templates.bottomCurveRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}				
			else if(openingDirection == 2 && templates.Rooms >= templates.curveRoomStart && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a TOP CURVE door.
				rand = Random.Range(0, templates.topCurveRooms.Length);
				Instantiate(templates.topCurveRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}	
			else if(openingDirection == 3 && templates.Rooms >= templates.curveRoomStart && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a LEFT UP CURVE door.
				rand = Random.Range(0, templates.leftUpCurveRooms.Length);
				Instantiate(templates.leftUpCurveRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}	
			 else if(openingDirection == 4 && templates.Rooms >= templates.curveRoomStart && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a RIGHT UP CURVE door.
				rand = Random.Range(0, templates.rightUpCurveRooms.Length);
				Instantiate(templates.rightUpCurveRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}	
			else if(openingDirection == 5 && templates.Rooms >= templates.curveRoomStart && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a LEFT DOWN CURVE door.
				rand = Random.Range(0, templates.leftDownCurveRooms.Length);
				Instantiate(templates.leftDownCurveRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}	
			else if(openingDirection == 6 && templates.Rooms >= templates.curveRoomStart && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a RIGHT DOWN CURVE door.
				rand = Random.Range(0, templates.rightDownCurveRooms.Length);
				Instantiate(templates.rightDownCurveRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}	





			else if(openingDirection == 1 && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a BOTTOM door.
				rand = Random.Range(0, templates.bottomRooms.Length);
				Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}
			else if(openingDirection == 2 && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a TOP door.
				rand = Random.Range(0, templates.topRooms.Length);
				Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}	
			else if(openingDirection == 3 && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a LEFT UP door.
				rand = Random.Range(0, templates.leftUpRooms.Length);
				Instantiate(templates.leftUpRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}
			else if(openingDirection == 4 && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a RIGHT UP door.
				rand = Random.Range(0, templates.rightUpRooms.Length);
				Instantiate(templates.rightUpRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}	
			else if(openingDirection == 5 && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a LEFT DOWN door.
				rand = Random.Range(0, templates.leftDownRooms.Length);
				Instantiate(templates.leftDownRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}	
			else if(openingDirection == 6 && templates.Rooms <= templates.roomCap && spawned == false){
				// Need to spawn a room with a RIGHT DOWN door.
				rand = Random.Range(0, templates.rightDownRooms.Length);
				Instantiate(templates.rightDownRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			}



			if(openingDirection == 1 && templates.Rooms >= templates.roomCap && spawned == false){
				// Need to spawn a room with a BOTTOM door.
				rand = Random.Range(0, templates.bottomExitRooms.Length);
				Instantiate(templates.bottomExitRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			} else if(openingDirection == 2 && templates.Rooms >= templates.roomCap && spawned == false){
				// Need to spawn a room with a TOP door.
				rand = Random.Range(0, templates.topExitRooms.Length);
				Instantiate(templates.topExitRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			} else if(openingDirection == 3 && templates.Rooms >= templates.roomCap && spawned == false){
				// Need to spawn a room with a LEFT UP door.
				rand = Random.Range(0, templates.leftUpExitRooms.Length);
				Instantiate(templates.leftUpExitRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			} else if(openingDirection == 4 && templates.Rooms >= templates.roomCap && spawned == false){
				// Need to spawn a room with a RIGHT UP door.
				rand = Random.Range(0, templates.rightUpExitRooms.Length);
				Instantiate(templates.rightUpExitRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			} else if(openingDirection == 5 && templates.Rooms >= templates.roomCap && spawned == false){
				// Need to spawn a room with a LEFT DOWN door.
				rand = Random.Range(0, templates.leftDownExitRooms.Length);
				Instantiate(templates.leftDownExitRooms[rand], transform.position, Quaternion.identity);
				spawned = true;
			} else if(openingDirection == 6 && templates.Rooms >= templates.roomCap && spawned == false){
				// Need to spawn a room with a RIGHT DOWN door.
				rand = Random.Range(0, templates.rightDownExitRooms.Length);
				Instantiate(templates.rightDownExitRooms[rand], transform.position, Quaternion.identity);
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