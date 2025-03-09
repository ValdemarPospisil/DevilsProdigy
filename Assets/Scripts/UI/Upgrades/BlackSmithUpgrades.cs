using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Prodigy.Weapons;

    public enum weaponType
    {
        Swords,
        Polearms,
        HeavyWeaponry,
        LongRange
        
    }

namespace Prodigy
{
    public class BlackSmithUpgrades : MonoBehaviour
    {
       public Image filedImage;
        public TextMeshProUGUI bonusDamageText;
        public TextMeshProUGUI goldNeededText;
        [SerializeField]private ElementData elementData;
        private ShopVariables shopVariables;
        private GameObject player;
        private Weapon weaponPrimary;
        private Weapon weaponSecondary;
        
      
        public weaponType weaponType;

        private void Awake() {
            shopVariables = ShopVariables.instance;
            player = GameObject.FindWithTag("Player");
            weaponPrimary = player.GetComponentInChildren<Weapon>();
            weaponSecondary = GameObject.FindWithTag("SecondaryWeapon").GetComponent<Weapon>();
        }


        private void OnEnable() {

            switch (weaponType)
            {
                case weaponType.Swords:
                    bonusDamageText.text = ("+" + shopVariables.swordShopDamage.ToString() + " Bonus Damage");
                    filedImage.fillAmount = shopVariables.swordProgress;
                    goldNeededText.text = shopVariables.swordGold.ToString();
                break;

                case weaponType.Polearms:
                    bonusDamageText.text = ("+" + shopVariables.polearmShopDamage.ToString() + " Bonus Damage");
                    filedImage.fillAmount = shopVariables.polearmProgress;
                    goldNeededText.text = shopVariables.polearmGold.ToString();
                break;

                case weaponType.HeavyWeaponry:
                    bonusDamageText.text = ("+" + shopVariables.heavyWeaponryShopDamage.ToString() + " Bonus Damage");
                    filedImage.fillAmount = shopVariables.heavyWeaponryProgress;
                    goldNeededText.text = shopVariables.heavyWeaponryGold.ToString();
                break;

                case weaponType.LongRange:
                    bonusDamageText.text = ("+" + shopVariables.longRangeShopDamage.ToString() + " Bonus Damage");
                    filedImage.fillAmount = shopVariables.longRangeProgress;
                    goldNeededText.text = shopVariables.longRangeGold.ToString();
                break;

                


            }
        }


        public void Upgrade () {

            SoundManager.instance.Play("Equip");
                switch (weaponType)
                {
                    case weaponType.Swords:
                    if (shopVariables.swordProgress == 1)
                    {
                        Debug.Log("Swords fully upgraded");
                        return;
                    }
                    if (shopVariables.swordGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash for swords, just like me");
                        return;
                    }

                    shopVariables.swordProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.swordProgress;
            
                    elementData.swordDamage += shopVariables.swordShopDamage;
                    shopVariables.swordShopDamage += (shopVariables.swordShopDamage / 4);
                    shopVariables.swordShopDamage = Mathf.RoundToInt(shopVariables.swordShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.swordShopDamage.ToString() + " Bonus Damage");

                    CurrencyCounter.instance.coins -= shopVariables.swordGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.swordGold += (shopVariables.swordGold / 3);
                    goldNeededText.text = shopVariables.swordGold.ToString();
                    break;


                    case weaponType.Polearms:
                    if (shopVariables.polearmProgress == 1)
                    {
                        Debug.Log("Polearms Fully upgraded");
                        return;
                    }
                    if (shopVariables.polearmGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash for Polearms, just like me");
                        return;
                    }
            
                    shopVariables.polearmProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.polearmProgress;
            
                    elementData.polearmDamage += shopVariables.polearmShopDamage;
                    shopVariables.polearmShopDamage += (shopVariables.polearmShopDamage / 4);
                    shopVariables.polearmShopDamage = Mathf.RoundToInt(shopVariables.polearmShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.polearmShopDamage.ToString() + " Bonus Damage");

                    CurrencyCounter.instance.coins -= shopVariables.polearmGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.polearmGold += (shopVariables.polearmGold / 3);
                    goldNeededText.text = shopVariables.polearmGold.ToString();
                    break;


                    case weaponType.HeavyWeaponry:
                    if (shopVariables.heavyWeaponryProgress == 1)
                    {
                        Debug.Log("Heavy Weaponry Fully upgraded");
                        return;
                    }
                    if (shopVariables.heavyWeaponryGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash for heavy weaponry, just like me");
                        return;
                    }
            
                    shopVariables.heavyWeaponryProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.heavyWeaponryProgress;
            
                    elementData.heavyDamage += shopVariables.heavyWeaponryShopDamage;
                    shopVariables.heavyWeaponryShopDamage += (shopVariables.heavyWeaponryShopDamage / 4);
                    shopVariables.heavyWeaponryShopDamage = Mathf.RoundToInt(shopVariables.heavyWeaponryShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.heavyWeaponryShopDamage.ToString() + " Bonus Damage");

                    CurrencyCounter.instance.coins -= shopVariables.heavyWeaponryGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.heavyWeaponryGold += (shopVariables.heavyWeaponryGold / 3);
                    goldNeededText.text = shopVariables.heavyWeaponryGold.ToString();
                    break;


                    case weaponType.LongRange:
                    if (shopVariables.longRangeProgress == 1)
                    {
                        Debug.Log("Long Range weapons Fully upgraded");
                        return;
                    }
                    if (shopVariables.longRangeGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash for long range weapons, just like me");
                        return;
                    }
            
                    shopVariables.longRangeProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.longRangeProgress;
            
                    elementData.longRangeDamage += shopVariables.longRangeShopDamage;
                    shopVariables.longRangeShopDamage += (shopVariables.longRangeShopDamage / 4);
                    shopVariables.longRangeShopDamage = Mathf.RoundToInt(shopVariables.longRangeShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.longRangeShopDamage.ToString() + " Bonus Damage");

                    CurrencyCounter.instance.coins -= shopVariables.longRangeGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.longRangeGold += (shopVariables.longRangeGold / 3);
                    goldNeededText.text = shopVariables.longRangeGold.ToString();
                    break;

                }
                
            weaponPrimary.AddWeaponBuffs();
            weaponSecondary.AddWeaponBuffs();
            
        }
    }
}
