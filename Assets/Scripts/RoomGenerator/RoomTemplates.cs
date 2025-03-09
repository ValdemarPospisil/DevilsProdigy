using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftUpRooms;
	public GameObject[] leftDownRooms;
	public GameObject[] rightUpRooms;
	public GameObject[] rightDownRooms;

	public GameObject[] bottomCurveRooms;
	public GameObject[] topCurveRooms;
	public GameObject[] leftUpCurveRooms;
	public GameObject[] leftDownCurveRooms;
	public GameObject[] rightUpCurveRooms;
	public GameObject[] rightDownCurveRooms;

	public GameObject[] bottomExitRooms;
	public GameObject[] topExitRooms;
	public GameObject[] leftUpExitRooms;
	public GameObject[] leftDownExitRooms;
	public GameObject[] rightUpExitRooms;
	public GameObject[] rightDownExitRooms;

	public GameObject closedRoom;

	public List<GameObject> rooms;
	
	public int roomCap;
	public int curveRoomStart = 12;
	public int Rooms;

		public float waitTime;
	private bool spawnedBoss;
	private bool spawnedChest;
	private bool spawnedEnemies;
	public GameObject boss;
	



	public List<GameObject> chests;
	public int chestRoomSpawn; //declaring public int set randomly by the script
	public int selectedChest;
	public int currentNumberofChests, maxNumberOfChests; //holds the current number and maximum number of chests spawned



	public List<GameObject> enemies;
	public int enemyRoomSpawn;
	public int selectedEnemies;
	public int currentNumberofEnemies, maxNumberOfEnemies;


	#region random number range 

	void randomizechest ()
    {
		selectedChest = Random.Range(0, chests.Count); //this method chooses a random object  that the user has put into the chests list
	
    }

	void randomizeEnemies()
	{
		selectedEnemies = Random.Range(0, enemies.Count); //this method chooses a random object  that the user has put into the chests list

	}

	#endregion

	void Update(){
		Rooms = rooms.Count;

      
        if (waitTime <= 0 && spawnedBoss == false){
			for (int i = 0; i < rooms.Count; i++) {
				if(i == rooms.Count-1){
//					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
					
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
       
	}
	}

