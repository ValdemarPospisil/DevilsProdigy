using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Prodigy
{
    public class SceneTeleport : MonoBehaviour
    {
            private Animator anim;



     private GameObject currentTeleporter;
    private GameObject player;
    private SoundManager soundManager;
 
     private bool canTeleport;
     [SerializeField] private int sceneNumber;


     [SerializeField]private GameObject border;
     [SerializeField]private GameObject visualCue;


     private PlayerInputHandler playerInputHandler;







 

   
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        playerInputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
        canTeleport = false;
        soundManager = FindObjectOfType<SoundManager>();
        border.SetActive(false);
        if(visualCue != null)
        {
            visualCue.SetActive(false);
        }
    }

    private void Update() {

        if(playerInputHandler.InteractInput)
        {
            
            if(currentTeleporter != null && canTeleport)
            {
                StartPort();
            }


            
            
        }
    }



    private void StartPort () {
        if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                CurrencyCounter.instance.CutInhalf();
            }
        anim.SetTrigger("Port");
        border.SetActive(true);
        canTeleport = false;
        soundManager.Play("Teleport");

    }


    private void AnimationFinishedTrigger() 
    {
        canTeleport = true;
        border.SetActive(false);
    } 
        
    private void AnimationPortTrigger() 
    {   
        
        player.SetActive(false);
        DataPersistenceManager.instance.SaveGame();
        ScenesManager.instance.LoadScene(sceneNumber);
        
    }


     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentTeleporter = collision.gameObject;
            canTeleport = true;
            if(visualCue != null)
            {
                visualCue.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                 if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
                canTeleport = false;
                if(visualCue != null)
            {
                visualCue.SetActive(false);
            }
            }
            
        }
    }
    }
}
