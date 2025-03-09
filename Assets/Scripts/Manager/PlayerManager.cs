using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Prodigy
{
    public class PlayerManager : MonoBehaviour, IDataPersistence
    {
        [SerializeField]
        private Transform respawnPoint;
        [SerializeField]
        private Transform startPoint;
        [SerializeField]
        private GameObject player;
        public int DeathCount;
        public TextMeshProUGUI DeathCountText;
        [SerializeField] private GameObject deathScreen;
        private bool isDeathScreen;

        public static PlayerManager instance;
        private List<int> magicVendorList = new List<int>();
        private List<int> blackSmithList = new List<int>();
        private List<int> mageList = new List<int>();
        private List<int> graveDiggerList = new List<int>();
        private List<int> girlList = new List<int>();
        private List<int> devilList = new List<int>();
        [SerializeField]private int currentSceneID;
        private Vector3 playerPosition;
            
            private void Awake() {
                 
                if (instance != null)
                {
                    Debug.Log("More than 1 data Game manager");
                    
                }
                instance = this;

                isDeathScreen = false;
            }


        private void Start() {
        
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if(DeathCount == 0)
            {
                DeathCountText.text = "";
            }
            else
            {
                DeathCountText.text = "Death Count: " + DeathCount.ToString();
            }

        }
            if (DeathCount == 0)
            {
                player.transform.position = startPoint.transform.position;
            }
            else if (currentSceneID == 1 && SceneManager.GetActiveScene().buildIndex == 1)
            {
                player.transform.position = playerPosition;
            }
            else
            {
                player.transform.position = respawnPoint.transform.position;
            }
        }

        private void Update() {
            if(isDeathScreen && PlayerInputHandler.GetInstance().GetSubmitPressed())
            {
                
                ScenesManager.instance.LoadScene(1);
                UIManager.IsPause = false;
            }
        }

    
         public void PlayerDeath () {

            StartCoroutine(DeathScreen());
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
            SoundManager.instance.Stop("Plains");
            } else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
            SoundManager.instance.Stop("Cave");
            }
            
            CheckPoints();
            
            
        }

        private IEnumerator DeathScreen()
        {
            yield return new WaitForSeconds(0.8f);
            isDeathScreen = true;
            deathScreen.SetActive(true);
            player.transform.position = playerPosition;
            player.SetActive(true);
            UIManager.IsPause = true;
            Time.timeScale = 0f;
            
        }

        public void CheckPoints () {
            DeathCount++;
           switch (DeathCount)
            {
                case 1:
                    graveDiggerList.Add(0);
                    devilList.Add(0);
                    magicVendorList.Add(0);
                    mageList.Add(1);
                    girlList.Add(1);
                break;

                case 2:
                    devilList.Add(1);
                break;

                case 3:
                    devilList.Add(2);
                    blackSmithList.Add(0);
                    graveDiggerList.Add(1);
                break;
                case 4:
                    devilList.Add(3);
                    
                break;
            }
            DataPersistenceManager.instance.SaveGame();
            
            
        }



         public void SaveData (GameData data) 
        {
            data.magicVendorList = this.magicVendorList;
            data.blackSmithList = this.blackSmithList;
            data.mageList = this.mageList;
            data.graveDiggerList = this.graveDiggerList;
            data.girlList = this.girlList;
            data.devilList = this.devilList;

            data.deathCount = this.DeathCount;
            data.currentSceneID = SceneManager.GetActiveScene().buildIndex;
            data.playerPosition = player.transform.position;
        }

        public void LoadData (GameData data) 
        {
            this.magicVendorList = data.magicVendorList;
            this.blackSmithList = data.blackSmithList;   
            this.mageList = data.mageList;   
            this.graveDiggerList = data.graveDiggerList;   
            this.girlList = data.girlList;   
            this.devilList = data.devilList;  


            this.DeathCount = data.deathCount;
            this.currentSceneID = data.currentSceneID;
            this.playerPosition = data.playerPosition;
        }

   
    
    

    }
}
