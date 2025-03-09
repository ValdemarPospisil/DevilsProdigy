using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Prodigy;


    public class UIManager : MonoBehaviour
    {

    private static UIManager _instance;

    public static UIManager instance
    {
        get
        {
        return _instance;
        }
    }


   [SerializeField] private GameObject InventoryMenu;
   [SerializeField] private GameObject PauseMenu;
   [SerializeField] private GameObject ControlsMenu;
   [SerializeField] private GameObject SettingsMenu;
   [SerializeField] private GameObject MapMenu;
   [SerializeField] private GameObject AudioSection;
   [SerializeField] private GameObject GeneralSection;
   [SerializeField] private GameObject weapons;
   [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject saveSlotMenu;
    [SerializeField] private GameObject popUpMenu;

    public static bool pauseMenu;
    public  static bool IsPause;
    public static bool inInventory;


   [SerializeField] private Button ResumeGameButton;
   [SerializeField] private Button GeneralButton;
   [SerializeField] private Button AudioButton;
   [SerializeField] private Selectable sfxSlider;
   [SerializeField] private Selectable musicSlider;
   [SerializeField] private Selectable ControlsButton;
   [SerializeField] private Selectable InventoryButton;
   [SerializeField] private Selectable InventoryButton1;

  

    private void Awake() {
        Time.timeScale = 1f;
        if (_instance != null && _instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      _instance = this;
    }



    if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            
            mainMenu.SetActive(true);
            popUpMenu.SetActive(false);
            saveSlotMenu.SetActive(false);
        }
        else
        {
            weapons.SetActive(true);
            PauseMenu.SetActive(false);

        }
    }

    void Start() 
    {
        pauseMenu = false;
        IsPause = false; 
       
       
                
        SettingsMenu.SetActive(false);
        AudioSection.SetActive(false);     
        GeneralSection.SetActive(true);
        ControlsMenu.SetActive(false);
        GeneralButton.interactable = false;
        AudioButton.interactable = true;
            
            
        
    }

    public void OpenpopUpToMenu () {
        popUpMenu.SetActive(true);
    }


    public void ClosepopUpToMenu () {
        popUpMenu.SetActive(false);
        ResumeGameButton.Select();
    }

   


    public void SFXSlider () {
        sfxSlider.Select();
    }
    public void MusicSlider () {
        musicSlider.Select();
    }

    

    public void PauseGame () 
    {
        if(UpgradePaper.IsInUpgrade == false)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            SoundManager.instance.Play("Pause");
            IsPause = true;
            pauseMenu = true;
            ResumeGameButton.Select();
        }
    }

    public void ResumeGame () 
    {
         if(UpgradePaper.IsInUpgrade == false)
        {
            PauseMenu.SetActive(false);
            SettingsMenu.SetActive(false);
            InventoryMenu.SetActive(false);
            ControlsMenu.SetActive(false);
            Time.timeScale = 1f;
            SoundManager.instance.Play("Resume");
            IsPause = false;
            pauseMenu = false;
    //      DialogueSystem.instance.Stop();
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                MapMenu.SetActive(false);
            }


        }
    }

    public void OpenMainMenu () {
        PauseMenu.SetActive(false); 
        Time.timeScale = 1f;
        if(SceneManager.GetActiveScene().buildIndex != 1)
        {
            PlayerManager.instance.CheckPoints();
        }
        else
        {
            DataPersistenceManager.instance.SaveGame();
        }
        ScenesManager.instance.LoadScene(0);
    }


    public void OpenSettings()
    {
        
        
        SoundManager.instance.Play("Confirm");
        PauseMenu.SetActive(false);
        InventoryMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        AudioSection.SetActive(false);
        GeneralSection.SetActive(true);
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            MapMenu.SetActive(false);
        }
            
        
        Time.timeScale = 0f;
        IsPause = true;
        GeneralButton.interactable = false;
        AudioButton.interactable = true;
        AudioButton.Select();
    }

    public void CloseSettings () 
    {
        SettingsMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPause = false;
        
    }
    public void OpenControls()
    {
        SoundManager.instance.Play("Confirm");
        PauseMenu.SetActive(false);
        InventoryMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        ControlsMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPause = true;
        InventoryButton.Select();
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            MapMenu.SetActive(false);
        }
    }

    public void CloseControls () 
    {
        ControlsMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPause = false;
        
    }

    public void OpenAudioSection () {
        SoundManager.instance.Play("Confirm");
        GeneralSection.SetActive(false);
        AudioSection.SetActive(true);
        GeneralButton.interactable = true;
        AudioButton.interactable = false;
        GeneralButton.Select();

    }

    public void OpenGeneralSection () {
        SoundManager.instance.Play("Confirm");
        AudioSection.SetActive(false);
        GeneralSection.SetActive(true);
        GeneralButton.interactable = false;
        AudioButton.interactable = true;
        AudioButton.Select();

    }


    public void ExitGame () 
    {
        Debug.Log("Exiting the game...");
        Application.Quit();    
    }


       public void OpenInventory () 
    {
        SoundManager.instance.Play("Confirm");
        SettingsMenu.SetActive(false);
        PauseMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        InventoryMenu.SetActive(true);
        inInventory = true;
        ControlsButton.Select();
        Time.timeScale = 0f;
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            MapMenu.SetActive(false);
        }
        
    }

    public void CloseInventory () 
    {
        InventoryMenu.SetActive(false);
        inInventory = false;
        Time.timeScale = 1f;
    }

       public void OpenMap () 
    {
        SoundManager.instance.Play("Confirm");
        SettingsMenu.SetActive(false);
        PauseMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        InventoryMenu.SetActive(false);
        MapMenu.SetActive(true); 
        Time.timeScale = 0f;
        IsPause = true;
        InventoryButton1.Select();   
    }

    public void CloseMap () 
    {
        MapMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPause = false;
    }



}

