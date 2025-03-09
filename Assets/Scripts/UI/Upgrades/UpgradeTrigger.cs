using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prodigy.CoreSystem;

public class UpgradeTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [Header("Upgrade list")]
    [SerializeField] private GameObject upgradeList;

    [SerializeField] private GameObject otherTrigger;
   
    private bool playerInRange;

    private void Awake() 
    {   
        
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update() 
    {   
       
            

        if (playerInRange && !otherTrigger.activeInHierarchy) 
        {
            visualCue.SetActive(true);
            if (PlayerInputHandler.GetInstance().GetInteractPressed()) 
            {
                UIManager.IsPause = true;
                upgradeList.SetActive(true);
                visualCue.SetActive(false);
                PlayerInputHandler.GetInstance().StopMovement();
            }

            if (PlayerInputHandler.GetInstance().GetPauseMenuPressed())
            {
                UIManager.IsPause = false;
                upgradeList.SetActive(false);
            }
        }
        else 
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}