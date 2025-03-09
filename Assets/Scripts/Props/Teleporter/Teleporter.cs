using UnityEngine;
using System;

public class Teleporter : MonoBehaviour
{
 
    private Animator anim;

    [SerializeField] private Transform destination;


     private GameObject currentTeleporter;
    private GameObject player;
    private SoundManager soundManager;
 
     private bool canTeleport;


     [SerializeField]private GameObject border;
     [SerializeField]private GameObject visualCue;

     private PlayerInputHandler playerInputHandler;
     [SerializeField] private bool isDoor;



public Transform GetDestination()
    {
        return destination;
    }



 

   
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        playerInputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
        canTeleport = false;
        soundManager = FindObjectOfType<SoundManager>();
        if(border != null)
        {
            border.SetActive(false);
        }
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
        
        anim.SetTrigger("Port");
        if(border != null)
        {
            border.SetActive(true);
        }
        canTeleport = false;
        if (isDoor)
        {
            soundManager.Play("Door");
        }
        else
        {
            soundManager.Play("Teleport");
        }

    }


    private void AnimationFinishedTrigger() 
    {
        player.transform.position = GetDestination().position;
        player.SetActive(true);
        canTeleport = true;
        anim.SetTrigger("Idle");
        if(border != null)
        {
            border.SetActive(false);
        }
    } 
        
    private void AnimationPortTrigger() 
    {   
        
        player.SetActive(false);
        
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