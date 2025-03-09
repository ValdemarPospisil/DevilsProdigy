using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class UpgradePaper : MonoBehaviour
    {   

        public  static bool IsInUpgrade;

       private void Update() {
            if (PlayerInputHandler.GetInstance().PauseMenuInput)
            {
                this.gameObject.SetActive(false);
            }
            UIManager.IsPause = true;
       }

       


        public void Close () {
            this.gameObject.SetActive(false);
            UIManager.IsPause = false;
            
        }
    }

