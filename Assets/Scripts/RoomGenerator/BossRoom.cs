using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
		public GameObject[] boss;
		private int rand;
	

		private void Start() {
			rand = Random.Range(0, boss.Length);
			for(int i = 0; i < boss.Length; i++) {
				boss[i].SetActive(false);
			}
		}


		private void OnTriggerEnter2D(Collider2D other) {
			if(other.CompareTag("Player") && !other.isTrigger)
			{
				boss[rand].SetActive(true);
				SoundManager.instance.Play("Encouter");
				
			}
		} 

	
		
		private void OnTriggerExit2D(Collider2D other) {
			if(other.CompareTag("Player") && !other.isTrigger)
			{
				boss[rand].SetActive(false);
				
		}
	}
}

