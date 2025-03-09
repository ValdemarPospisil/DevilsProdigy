using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Prodigy.Weapons;
using UnityEngine.SceneManagement;

public class GroundItem : MonoBehaviour
{
    [SerializeField]private ItemObject item;
    [SerializeField] private ItemObject[] itemObjects;
    private int random;

    [SerializeField]private float minHeight;


    private WeaponGenerator weaponGeneratorPrimary;
    private WeaponGenerator weaponGeneratorSecondary;

    private GameObject player;
    private bool canOpen = false;
    private ItemDetails itemDetails;
    private ItemDetails itemDetailsDown;
    [SerializeField] private GameObject descriptionUI;
    [SerializeField] private GameObject descriptionUIDown;
  


     void Awake() {
            random = Random.Range(0, itemObjects.Length);
            item = itemObjects[random];
            GetComponentInChildren<SpriteRenderer>().sprite = item.uiDisplay;


            player = GameObject.FindWithTag("Player");
            weaponGeneratorPrimary = player.GetComponentInChildren<WeaponGenerator>();
            weaponGeneratorSecondary = GameObject.FindWithTag("SecondaryWeapon").GetComponent<WeaponGenerator>();
            itemDetails = descriptionUI.GetComponent<ItemDetails>();
            itemDetailsDown = descriptionUIDown.GetComponent<ItemDetails>();
            
            
           
        }

        private void Update() {

             if(PlayerInputHandler.GetInstance().InteractInput & canOpen)
            {
             
                GenerateItem();
                
            }
        }

   

     public void OnTriggerEnter2D(Collider2D other)
    {
         if(other.transform.tag == "Player")
        {   
            canOpen = true;
            if(item.type == ItemType.LongRangeWeapons)
            {
                ShowEquippedWeapons.instance.ShowSecondaryWeaponDetails();
                } else
            {
                ShowEquippedWeapons.instance.ShowPrimaryWeaponDetails();
            }
            if(this.gameObject.transform.position.y >= minHeight && SceneManager.GetActiveScene().buildIndex == 2)
            {
                descriptionUIDown.SetActive(true);
                itemDetailsDown.ShowDetails(item);
            }
            else
            {
                descriptionUI.SetActive(true);
                itemDetails.ShowDetails(item);
            }
            
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
         if(other.transform.tag == "Player")
        {   
            if(item.type == ItemType.LongRangeWeapons)
            {
                ShowEquippedWeapons.instance.HideSecondaryWeaponDetails();
            } else
            {
                ShowEquippedWeapons.instance.HidePrimaryWeaponDetails();
            }
            canOpen = false;
           
              //  itemDetailsDown.HideDetails();
                descriptionUIDown.SetActive(false);
            
             //   itemDetails.HideDetails();
                descriptionUI.SetActive(false);
            
            
        }
    }

    private void GenerateItem () {
        if(item.type == ItemType.LongRangeWeapons)
        {
            weaponGeneratorSecondary.GenerateWeapon(item);
        } else
        {
            weaponGeneratorPrimary.GenerateWeapon(item);
        }
        SoundManager.instance.Play("Equip");
        Destroy(this.gameObject);
    }


    private void OnValidate()
    {
#if UNITY_EDITOR
        GetComponentInChildren<SpriteRenderer>().sprite = item.uiDisplay;
#endif
    }

}