using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowEquippedWeapons : MonoBehaviour, IDataPersistence
{
    private static ShowEquippedWeapons _instance;

    public static ShowEquippedWeapons instance
    {
        get
        {
        return _instance;
        }
    }
    [SerializeField] private ItemDatabase itemDatabase;
    [SerializeField] private Image currentPrimaryImage;
    [SerializeField] private Image currentSecondaryImage;
    [SerializeField] private GameObject primaryDetails;
    [SerializeField] private GameObject secondaryDetails;
    private ItemDetails primaryItemDetails;
    private ItemDetails secondaryItemDetails;
    public int currentPrimaryWeaponID;
    public int currentSecondaryWeaponID;

    private void Awake() {
        if (_instance != null && _instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      _instance = this;
    }

    }

    public void SaveData (GameData data) {
        data.currentPrimaryID = this.currentPrimaryWeaponID;
        data.currentSecondaryID = this.currentSecondaryWeaponID;
    }

     public void LoadData (GameData data) 
        {
            this.currentPrimaryWeaponID = data.currentPrimaryID;
            this.currentSecondaryWeaponID = data.currentSecondaryID;
        }

    

    private void Start() {
        primaryItemDetails = primaryDetails.GetComponent<ItemDetails>();
        secondaryItemDetails = secondaryDetails.GetComponent<ItemDetails>();
    }


  

    public void ChangeSprites () {
        currentPrimaryImage.sprite = itemDatabase.primaryWeapons[currentPrimaryWeaponID].uiDisplay;
        currentSecondaryImage.sprite = itemDatabase.secondaryWeapons[currentSecondaryWeaponID].uiDisplay;
    }


    public void ShowPrimaryWeaponDetails () {
        primaryItemDetails.ShowDetails(itemDatabase.primaryWeapons[currentPrimaryWeaponID]);
    }
    public void HidePrimaryWeaponDetails()
    {
        primaryItemDetails.HideDetails();
    }

     public void ShowSecondaryWeaponDetails () {
        secondaryItemDetails.ShowDetails(itemDatabase.secondaryWeapons[currentSecondaryWeaponID]);
    }

    public void HideSecondaryWeaponDetails()
    {
        secondaryItemDetails.HideDetails();
    }

}
