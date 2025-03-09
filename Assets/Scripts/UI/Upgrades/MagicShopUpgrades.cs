using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Prodigy.Weapons;

    public enum Elements
    {
        fire,
        water,
        wind,
        Earth,
        nature,
        ice,
        thunder,
        acid,
        holy,
        dark
        
    }

namespace Prodigy
{
    public class MagicShopUpgrades : MonoBehaviour
    {
        public Image filedImage;
        public TextMeshProUGUI bonusDamageText;
        public TextMeshProUGUI goldNeededText;
        [SerializeField]private ElementData elementData;
        private ShopVariables shopVariables;
        private GameObject player;
        private Weapon weaponPrimary;
        private Weapon weaponSecondary;
        
      
        public Elements elements;

        private void Awake() {
            shopVariables = ShopVariables.instance;
            player = GameObject.FindWithTag("Player");
            weaponPrimary = player.GetComponentInChildren<Weapon>();
            weaponSecondary = GameObject.FindWithTag("SecondaryWeapon").GetComponent<Weapon>();
        }


        private void OnEnable() {

            switch (elements)
            {
                case Elements.fire:
                    bonusDamageText.text = ("+" + shopVariables.fireShopDamage.ToString() + " Bonus Fire Damage");
                    filedImage.fillAmount = shopVariables.fireProgress;
                    goldNeededText.text = shopVariables.fireGold.ToString();
                break;

                case Elements.water:
                    bonusDamageText.text = ("+" + shopVariables.waterShopDamage.ToString() + " Bonus Water Damage");
                    filedImage.fillAmount = shopVariables.waterProgress;
                    goldNeededText.text = shopVariables.waterGold.ToString();
                break;

                case Elements.Earth:
                    bonusDamageText.text = ("+" + shopVariables.earthShopDamage.ToString() + " Bonus Earth Damage");
                    filedImage.fillAmount = shopVariables.earthProgress;
                    goldNeededText.text = shopVariables.earthGold.ToString();
                break;

                case Elements.wind:
                    bonusDamageText.text = ("+" + shopVariables.windShopDamage.ToString() + " Bonus Wind Damage");
                    filedImage.fillAmount = shopVariables.windProgress;
                    goldNeededText.text = shopVariables.windGold.ToString();
                break;

                case Elements.thunder:
                    bonusDamageText.text = ("+" + shopVariables.thunderShopDamage.ToString() + " Bonus Thunder Damage");
                    filedImage.fillAmount = shopVariables.thunderProgress;
                    goldNeededText.text = shopVariables.thunderGold.ToString();
                break;

                case Elements.nature:
                    bonusDamageText.text = ("+" + shopVariables.natureShopDamage.ToString() + " Bonus Nature Damage");
                    filedImage.fillAmount = shopVariables.natureProgress;
                    goldNeededText.text = shopVariables.natureGold.ToString();
                break;

                case Elements.ice:
                    bonusDamageText.text = ("+" + shopVariables.iceShopDamage.ToString() + " Bonus Ice Damage");
                    filedImage.fillAmount = shopVariables.iceProgress;
                    goldNeededText.text = shopVariables.iceGold.ToString();
                break;

                case Elements.acid:
                    bonusDamageText.text = ("+" + shopVariables.acidShopDamage.ToString() + " Bonus Acid Damage");
                    filedImage.fillAmount = shopVariables.acidProgress;
                    goldNeededText.text = shopVariables.acidGold.ToString();
                break;

                case Elements.holy:
                    bonusDamageText.text = ("+" + shopVariables.holyShopDamage.ToString() + " Bonus Holy Damage");
                    filedImage.fillAmount = shopVariables.holyProgress;
                    goldNeededText.text = shopVariables.holyGold.ToString();
                break;
                
                case Elements.dark:
                    bonusDamageText.text = ("+" + shopVariables.darkShopDamage.ToString() + " Bonus Dark Damage");
                    filedImage.fillAmount = shopVariables.darkProgress;
                    goldNeededText.text = shopVariables.darkGold.ToString();
                break;


            }
        }


        public void Upgrade () {
                
                SoundManager.instance.Play("Equip");
                switch (elements)
                {
                    case Elements.fire:
                    if (shopVariables.fireProgress == 1)
                    {
                        Debug.Log("Fire fully upgraded");
                        return;
                    }
                    if (shopVariables.fireGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash for fire, just like me");
                        return;
                    }

                    shopVariables.fireProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.fireProgress;
            
                    elementData.fireDamage += shopVariables.fireShopDamage;
                    shopVariables.fireShopDamage += (shopVariables.fireShopDamage / 4);
                    shopVariables.fireShopDamage = Mathf.RoundToInt(shopVariables.fireShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.fireShopDamage.ToString() + " Bonus Fire Damage");

                    CurrencyCounter.instance.coins -= shopVariables.fireGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.fireGold += (shopVariables.fireGold / 3);
                    goldNeededText.text = shopVariables.fireGold.ToString();
                    break;


                    case Elements.water:
                    if (shopVariables.waterProgress == 1)
                    {
                        Debug.Log("Water Fully upgraded");
                        return;
                    }
                    if (shopVariables.waterGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash, just like me");
                        return;
                    }
            
                    shopVariables.waterProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.waterProgress;
            
                    elementData.waterDamage += shopVariables.waterShopDamage;
                    shopVariables.waterShopDamage += (shopVariables.waterShopDamage / 4);
                    shopVariables.waterShopDamage = Mathf.RoundToInt(shopVariables.waterShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.waterShopDamage.ToString() + " Bonus Water Damage");

                    CurrencyCounter.instance.coins -= shopVariables.waterGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.waterGold += (shopVariables.waterGold / 3);
                    goldNeededText.text = shopVariables.waterGold.ToString();
                    break;


                    case Elements.Earth:
                    if (shopVariables.earthProgress == 1)
                    {
                        Debug.Log("Earth Fully upgraded");
                        return;
                    }
                    if (shopVariables.earthGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash, just like me");
                        return;
                    }
            
                    shopVariables.earthProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.earthProgress;
            
                    elementData.earthDamage += shopVariables.earthShopDamage;
                    shopVariables.earthShopDamage += (shopVariables.earthShopDamage / 4);
                    shopVariables.earthShopDamage = Mathf.RoundToInt(shopVariables.earthShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.earthShopDamage.ToString() + " Bonus Earth Damage");

                    CurrencyCounter.instance.coins -= shopVariables.earthGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.earthGold += (shopVariables.earthGold / 3);
                    goldNeededText.text = shopVariables.earthGold.ToString();
                    break;


                    case Elements.wind:
                    if (shopVariables.windProgress == 1)
                    {
                        Debug.Log("Wind Fully upgraded");
                        return;
                    }
                    if (shopVariables.windGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash, just like me");
                        return;
                    }
            
                    shopVariables.windProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.windProgress;
            
                    elementData.windDamage += shopVariables.windShopDamage;
                    shopVariables.windShopDamage += (shopVariables.windShopDamage / 4);
                    shopVariables.windShopDamage = Mathf.RoundToInt(shopVariables.windShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.windShopDamage.ToString() + " Bonus Wind Damage");

                    CurrencyCounter.instance.coins -= shopVariables.windGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.windGold += (shopVariables.windGold / 3);
                    goldNeededText.text = shopVariables.windGold.ToString();
                    break;


                    case Elements.thunder:
                    if (shopVariables.thunderProgress == 1)
                    {
                        Debug.Log("Thunder Fully upgraded");
                        return;
                    }
                    if (shopVariables.thunderGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash, just like me");
                        return;
                    }
            
                    shopVariables.thunderProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.thunderProgress;
            
                    elementData.thunderDamage += shopVariables.thunderShopDamage;
                    shopVariables.thunderShopDamage += (shopVariables.thunderShopDamage / 4);
                    shopVariables.thunderShopDamage = Mathf.RoundToInt(shopVariables.thunderShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.thunderShopDamage.ToString() + " Bonus Thunder Damage");

                    CurrencyCounter.instance.coins -= shopVariables.thunderGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.thunderGold += (shopVariables.thunderGold / 3);
                    goldNeededText.text = shopVariables.thunderGold.ToString();
                    break;


                    case Elements.nature:
                    if (shopVariables.natureProgress == 1)
                    {
                        Debug.Log("Nature Fully upgraded");
                        return;
                    }
                    if (shopVariables.natureGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash, just like me");
                        return;
                    }
            
                    shopVariables.natureProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.natureProgress;
            
                    elementData.woodDamage += shopVariables.natureShopDamage;
                    shopVariables.natureShopDamage += (shopVariables.natureShopDamage / 4);
                    shopVariables.natureShopDamage = Mathf.RoundToInt(shopVariables.natureShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.natureShopDamage.ToString() + " Bonus Nature Damage");

                    CurrencyCounter.instance.coins -= shopVariables.natureGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.natureGold += (shopVariables.natureGold / 3);
                    goldNeededText.text = shopVariables.natureGold.ToString();
                    break;


                    case Elements.ice:
                    if (shopVariables.iceProgress == 1)
                    {
                        Debug.Log("Ice Fully upgraded");
                        return;
                    }
                    if (shopVariables.iceGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash, just like me");
                        return;
                    }
            
                    shopVariables.iceProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.iceProgress;
            
                    elementData.iceDamage += shopVariables.iceShopDamage;
                    shopVariables.iceShopDamage += (shopVariables.iceShopDamage / 4);
                    shopVariables.iceShopDamage = Mathf.RoundToInt(shopVariables.iceShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.iceShopDamage.ToString() + " Bonus Ice Damage");

                    CurrencyCounter.instance.coins -= shopVariables.iceGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.iceGold += (shopVariables.iceGold / 3);
                    goldNeededText.text = shopVariables.iceGold.ToString();
                    break;


                    case Elements.acid:
                    if (shopVariables.acidProgress == 1)
                    {
                        Debug.Log("Acid Fully upgraded");
                        return;
                    }
                    if (shopVariables.acidGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash, just like me");
                        return;
                    }
            
                    shopVariables.acidProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.acidProgress;
            
                    elementData.acidDamage += shopVariables.acidShopDamage;
                    shopVariables.acidShopDamage += (shopVariables.acidShopDamage / 4);
                    shopVariables.acidShopDamage = Mathf.RoundToInt(shopVariables.acidShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.acidShopDamage.ToString() + " Bonus Acid Damage");

                    CurrencyCounter.instance.coins -= shopVariables.acidGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.acidGold += (shopVariables.acidGold / 3);
                    goldNeededText.text = shopVariables.acidGold.ToString();
                    break;


                    case Elements.holy:
                    if (shopVariables.holyProgress == 1)
                    {
                        Debug.Log("Holy Fully upgraded");
                        return;
                    }
                    if (shopVariables.holyGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash, just like me");
                        return;
                    }
            
                    shopVariables.holyProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.holyProgress;
            
                    elementData.holyDamage += shopVariables.holyShopDamage;
                    shopVariables.holyShopDamage += (shopVariables.holyShopDamage / 4);
                    shopVariables.holyShopDamage = Mathf.RoundToInt(shopVariables.holyShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.holyShopDamage.ToString() + " Bonus Holy Damage");

                    CurrencyCounter.instance.coins -= shopVariables.holyGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.holyGold += (shopVariables.holyGold / 3);
                    goldNeededText.text = shopVariables.holyGold.ToString();
                    break;


                    case Elements.dark:
                    if (shopVariables.darkProgress == 1)
                    {
                        Debug.Log("Dark Fully upgraded");
                        return;
                    }
                    if (shopVariables.darkGold > CurrencyCounter.instance.coins)
                    {
                        Debug.Log("No cash, just like me");
                        return;
                    }
            
                    shopVariables.darkProgress += 0.125f; 
                    filedImage.fillAmount = shopVariables.darkProgress;
            
                    elementData.darkDamage += shopVariables.darkShopDamage;
                    shopVariables.darkShopDamage += (shopVariables.darkShopDamage / 4);
                    shopVariables.darkShopDamage = Mathf.RoundToInt(shopVariables.darkShopDamage);
                    bonusDamageText.text = ("+" + shopVariables.darkShopDamage.ToString() + " Bonus Dark Damage");

                    CurrencyCounter.instance.coins -= shopVariables.darkGold;
                    CurrencyCounter.instance.UpdateText();
                    shopVariables.darkGold += (shopVariables.darkGold / 3);
                    goldNeededText.text = shopVariables.darkGold.ToString();
                    break;

                }
            weaponPrimary.AddWeaponBuffs();
            weaponSecondary.AddWeaponBuffs();
            
        }
    }
}
