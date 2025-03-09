using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Prodigy
{
    public class SettingsManager : MonoBehaviour
    {
        
        public TMP_Dropdown resolutionDropdown;
        Resolution [] resolutions;
        private bool isFullScreen;
        private int resolutionIndex;
        [SerializeField] private Toggle fullScreenToggle;

        private void Start() {

            
            resolutions = Screen.resolutions;

            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;

            for(int i = 0; i < resolutions.Length; i++) 
            {
                string option = resolutions[i].width + " x" + resolutions[i].height;
                options.Add(option);    
            
                if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
    //        SetResolution(PlayerPrefs.GetInt("Resolution"));

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = PlayerPrefs.GetInt("Resolution");
            resolutionDropdown.RefreshShownValue();


            fullScreenToggle.isOn = (PlayerPrefs.GetInt("Fullscreen") != 0);
         //   SetFullscreen(PlayerPrefs.GetInt("Fullscreen") != 0);
        //    Debug.Log("REsoulution is " + (PlayerPrefs.GetInt("Resolution")));
        //    Debug.Log("Fullscreen is " + (PlayerPrefs.GetInt("Fullscreen") != 0));
        }

        public void SetFullscreen (bool isFullScreen) {
            Screen.fullScreen = isFullScreen;
            PlayerPrefs.SetInt("Fullscreen", (isFullScreen ? 1 : 0));
        }

        public void SetResolution (int resolutionIndex) 
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            PlayerPrefs.SetInt("Resolution", resolutionIndex);
        }

    }
}
