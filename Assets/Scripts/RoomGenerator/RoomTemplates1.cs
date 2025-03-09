using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates1 : MonoBehaviour {

	public GameObject[] LURooms;
	public GameObject[] LDRooms;
	public GameObject[] RURooms;
	public GameObject[] RDRooms;



	public GameObject[] LUExitRooms;
	public GameObject[] LDExitRooms;
	public GameObject[] RDExitRooms;
	public GameObject[] RUExitRooms;


	public List<GameObject> rooms;
	
	public int roomCap;
	public int Rooms;

		public float waitTime;
	private bool spawnedBoss;
	





	void Update(){
		
		Rooms = rooms.Count;

      
        if (waitTime <= 0 && spawnedBoss == false){
			for (int i = 0; i < rooms.Count; i++) {
				if(i == rooms.Count-1){
					//Instantiate(boss, rooms1[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
					
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
       
	}

}
