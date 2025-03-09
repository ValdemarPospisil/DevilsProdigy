using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Prodigy
{
    public class DevilChat : MonoBehaviour, IDataPersistence
    {
        [SerializeField] private GameObject[] answers;
        [SerializeField] private GameObject[] questions;
        [SerializeField] private GameObject answer;
        private List<int> devilList = new List<int>();
        private Vector3 pos;

        private void OnEnable() {
            Queue<int> devilQ = new Queue<int>(devilList);
            for(int i = 0; i < devilList.Count; i++) {
                questions[devilQ.Dequeue()].SetActive(true);
            }
        }

        private void OnDisable() {
            for(int i = 0; i < questions.Length; i++) {
                questions[i].SetActive(false);
            }
        }

        public void ShowAnswer (int id) {
            pos = new Vector3(0, 0, 0);
           GameObject newAnswer = Instantiate(answers[id], pos, answer.transform.rotation) as GameObject;
           newAnswer.transform.SetParent(answer.transform, false);
            devilList.Remove(id);
        }

        public void SaveData (GameData data) {

            data.devilList = this.devilList;
        }

        public void LoadData (GameData data) {
            
            this.devilList = data.devilList;  
        }

       
    }
}
