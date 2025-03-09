using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Prodigy
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] ItemDatabase itemDatabase;
        [SerializeField] ElementData elementData;
        [Header("Primary Weapon")]
        [SerializeField] private Image primaryIcon;
        [SerializeField] private TextMeshProUGUI primaryName;
        [SerializeField] private TextMeshProUGUI primaryDescription;
        [Header("Secondary Weapon")]
        [SerializeField] private Image secondaryIcon;
        [SerializeField] private TextMeshProUGUI secondaryName;
        [SerializeField] private TextMeshProUGUI secondaryDescription;
        [Header("Elements")]
        [SerializeField] private TextMeshProUGUI fireText;
        [SerializeField] private TextMeshProUGUI waterText;
        [SerializeField] private TextMeshProUGUI earthText;
        [SerializeField] private TextMeshProUGUI windText;
        [SerializeField] private TextMeshProUGUI thunderText;
        [SerializeField] private TextMeshProUGUI natureText;
        [SerializeField] private TextMeshProUGUI acidText;
        [SerializeField] private TextMeshProUGUI iceText;
        [SerializeField] private TextMeshProUGUI holyText;
        [SerializeField] private TextMeshProUGUI darkText;
        [Header("Weapon Types")]
        [SerializeField] private TextMeshProUGUI swordText;
        [SerializeField] private TextMeshProUGUI polearmsText;
        [SerializeField] private TextMeshProUGUI heavyWeaponryText;
        [SerializeField] private TextMeshProUGUI longRangeTexts;


        private void OnEnable() 
        {
            primaryIcon.sprite = itemDatabase.primaryWeapons[ShowEquippedWeapons.instance.currentPrimaryWeaponID].uiDisplay;
            primaryName.text = itemDatabase.primaryWeapons[ShowEquippedWeapons.instance.currentPrimaryWeaponID].Name;
            primaryDescription.text = itemDatabase.primaryWeapons[ShowEquippedWeapons.instance.currentPrimaryWeaponID].description;


            secondaryIcon.sprite = itemDatabase.secondaryWeapons[ShowEquippedWeapons.instance.currentSecondaryWeaponID].uiDisplay;
            secondaryName.text = itemDatabase.secondaryWeapons[ShowEquippedWeapons.instance.currentSecondaryWeaponID].Name;
            secondaryDescription.text = itemDatabase.secondaryWeapons[ShowEquippedWeapons.instance.currentSecondaryWeaponID].description;


            fireText.text = ("Fire Damage: " + elementData.fireDamage);
            waterText.text = ("Water Damage: " + elementData.waterDamage);
            earthText.text = ("Earth Damage: " + elementData.earthDamage);
            windText.text = ("Wind Damage: " + elementData.windDamage);
            thunderText.text = ("Thunder Damage: " + elementData.thunderDamage);
            natureText.text = ("Nature Damage: " + elementData.woodDamage);
            acidText.text = ("Acid Damage: " + elementData.acidDamage);
            iceText.text = ("Ice Damage: " + elementData.iceDamage);
            holyText.text = ("Holy Damage: " + elementData.holyDamage);
            darkText.text = ("Dark Damage: " + elementData.darkDamage);

            swordText.text = ("Swords Damage: " + elementData.swordDamage);
            polearmsText.text = ("Polearms Damage: " + elementData.polearmDamage);
            heavyWeaponryText.text = ("Heavy Weaponry Damage: " + elementData.heavyDamage);
            longRangeTexts.text = ("Bows Damage: " + elementData.longRangeDamage);

        }
    }
}

    
