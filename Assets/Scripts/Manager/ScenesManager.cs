 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    public class ScenesManager : MonoBehaviour
    {
        public static ScenesManager instance;
        public GameObject loadingScreen;
        public Image loadingBarFill;

        private void Awake() {
            if (instance != null)
            {
                Debug.Log("More than 1 CheckPoints Managers");
            }
            instance = this;
        }

        public enum Scene
        {
            Menu,
            Base,
            Plains,
            Cave
        }

        public void LoadScene(int sceneId) 
        {
         //   SceneManager.LoadScene(scene.ToString());
            StartCoroutine(LoadSceneAsync(sceneId));    
         //       SceneManager.LoadScene(sceneId);
        }

        IEnumerator LoadSceneAsync(int sceneId)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

            loadingScreen.SetActive(true);

            while (!operation.isDone)
            {
                float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

                loadingBarFill.fillAmount = progressValue;

                yield return null;
            }
            loadingScreen.SetActive(false);
        }


        public void LoadNewGame()
        {
            SceneManager.LoadScene(Scene.Base.ToString());
        }

        public void LoadNextScene () {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LoadMainMenu () {
           SceneManager.LoadScene(Scene.Menu.ToString());
            
        }
        public void LoadBaseLevel () {
           SceneManager.LoadScene(Scene.Base.ToString());
            
        }
    }
