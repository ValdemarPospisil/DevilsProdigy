using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public int deathCount;
    public int coins;
    public Vector3 playerPosition;
    public int currentSceneID;
    public int currentPrimaryID;
    public int currentSecondaryID;

    //Element data
    [Header("Element Data")]
    public float acidDamage;
    public float darkDamage;
    public float earthDamage;
    public float fireDamage;
    public float holyDamage;
    public float iceDamage;
    public float thunderDamage;
    public float waterDamage;
    public float windDamage;
    public float woodDamage;
    public float bonusAcidDamage;
    public float bonusDarkDamage;
    public float bonusEarthDamage;
    public float bonusFireDamage;
    public float bonusHolyDamage;
    public float bonusIceDamage;
    public float bonusThunderDamage;
    public float bonusWaterDamage;
    public float bonusWindDamage;
    public float bonusWoodDamage;
    public float bonusSwordDamage;
    public float bonusPolearmDamage;
    public float bonusHeavyDamage;
    public float bonusLongRangeDamage;
    public float swordDamage;
    public float polearmDamage;
    public float heavyDamage;
    public float longRangeDamage;

    [Header("Player Data")] 
    public float movementVelocity;
    public float bonusMovementVelocity;
    public float jumpVelocity;
    public float bonusJumpVelocity;
    public int amountOfJumps;
    public int bonusAmountOfJumps;
    public float dashCooldown;
    public float minusDashCooldown;
    public float dashVelocity;
    public float bonusDashVelocity;
    public float MaxHealth;
    public float bonusMaxHealth;
    public float currentHealth;
    public float bonusCurrentHealth;
    public bool IsRegenActive;
    public float regenHealAmount;
    public int regenDuration;
    public int bonusAmountOfLives;
    public float shieldOnDuration;
    public float shieldOffDuration;
    public int numberOfFlashes;
    public bool isShieldActive;

    [Header("Shop Data")] 

        public int fireGold;
        public int waterGold;
        public int windGold;
        public int natureGold;
        public int thunderGold;
        public int iceGold;
        public int earthGold;
        public int acidGold;
        public int holyGold;
        public int darkGold; 
        
        public float fireShopDamage;
        public float waterShopDamage;
        public float windShopDamage;
        public float earthShopDamage;
        public float iceShopDamage;
        public float thunderShopDamage;
        public float natureShopDamage;
        public float acidShopDamage;
        public float holyShopDamage;
        public float darkShopDamage;

        public float fireProgress;
        public float waterProgress;
        public float earthProgress;
        public float windProgress;
        public float iceProgress;
        public float thunderProgress;
        public float natureProgress;
        public float acidProgress;
        public float holyProgress;
        public float darkProgress;



        public int swordGold;
        public int polearmGold;
        public int heavyWeaponryGold;
        public int longRangeGold;

        public float swordShopDamage;
        public float polearmShopDamage;
        public float heavyWeaponryShopDamage;
        public float longRangeShopDamage;

        public float swordProgress;
        public float polearmProgress;
        public float heavyWeaponryProgress;
        public float longRangeProgress;

        [Header("MPC Dialogue Data")] 

        public List<int> magicVendorList;
        public List<int> blackSmithList;
        public List<int> mageList;
        public List<int> graveDiggerList;
        public List<int> girlList;
        public List<int> devilList;

        public int hasDialogueG;
        public int hasDialogueM;

        [Header("Projectile shooter Data")]

        public int acidDuration;
        public int darkDuration;
        public int earthDuration;
        public int fireDuration;
        public int holyDuration;
        public int iceDuration;
        public int thunderDuration;
        public int waterDuration;
        public int windDuration;
        public int natureDuration;

        public bool IsActiveAcid;
        public bool IsActiveDark;
        public bool IsActiveEarth;
        public bool IsActiveFire;
        public bool IsActiveHoly;
        public bool IsActiveIce;
        public bool IsActiveThunder;
        public bool IsActiveWater;
        public bool IsActiveWind;
        public bool IsActiveNature;


 


   //   public SerializableDictionary<string, bool> coinsCollected;
  //  public AttributesData playerAttributesData;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData() 
    {
        this.deathCount = 0;
        this.coins = 0;
        this.currentPrimaryID = 5;
        this.currentSecondaryID = 36;
        playerPosition = Vector3.zero;
        this.currentSceneID = 1;
   //d     coinsCollected = new SerializableDictionary<string, bool>();
 //       playerAttributesData = new AttributesData();

        this.acidDamage = 0;
        this.darkDamage = 0;
        this.earthDamage = 0;
        this.fireDamage = 0;
        this.holyDamage = 0;
        this.iceDamage = 0;
        this.thunderDamage = 0;
        this.waterDamage = 0;
        this.windDamage = 0;
        this.woodDamage = 0;

        this.bonusAcidDamage = 0;
        this.bonusDarkDamage = 0;
        this.bonusEarthDamage = 0;
        this.bonusFireDamage = 0;
        this.bonusHolyDamage = 0;
        this.bonusIceDamage = 0;
        this.bonusThunderDamage = 0;
        this.bonusWaterDamage = 0;
        this.bonusWindDamage = 0;
        this.bonusWoodDamage = 0;


        this.swordDamage = 0;
        this.polearmDamage = 0;
        this.heavyDamage = 0;
        this.longRangeDamage = 0;

        this.bonusHeavyDamage = 0;
        this.bonusLongRangeDamage = 0;
        this.bonusPolearmDamage = 0;
        this.bonusSwordDamage = 0;




        this.movementVelocity = 8;
        this.bonusMovementVelocity = 0;
        this.jumpVelocity = 22;
        this.bonusJumpVelocity = 0;
        this.amountOfJumps = 1;
        this.bonusAmountOfJumps = 0;
        this.dashCooldown = 2;
        this.minusDashCooldown  = 0;
        this.dashVelocity = 25;
        this.bonusDashVelocity = 0;
        this.MaxHealth = 200;
        this.bonusMaxHealth = 0;
        this.currentHealth = 150;
        this.bonusCurrentHealth = 0;
        this.IsRegenActive = false;
        this.regenHealAmount = 0;
        this.regenDuration = 0;
        this.bonusAmountOfLives = 0;
        this.shieldOnDuration = 0;
        this.shieldOffDuration = 0;
        this.numberOfFlashes = 0;
        this.isShieldActive = false;

        this.fireGold = 30;
        this.waterGold = 30;
        this.windGold = 30;
        this.natureGold = 30;
        this.thunderGold = 30;
        this.iceGold = 30;
        this.earthGold = 30;
        this.acidGold = 30;
        this.holyGold = 30;
        this.darkGold = 30; 
        
        this.fireShopDamage = 5;
        this.waterShopDamage = 5;
        this.windShopDamage = 5;
        this.earthShopDamage = 5;
        this.iceShopDamage = 5;
        this.thunderShopDamage = 5;
        this.natureShopDamage = 5;
        this.acidShopDamage = 5;
        this.holyShopDamage = 5;
        this.darkShopDamage = 5;

        this.fireProgress = 0;
        this.waterProgress = 0;
        this.earthProgress = 0;
        this.windProgress = 0;
        this.iceProgress = 0;
        this.thunderProgress = 0;
        this.natureProgress = 0;
        this.acidProgress = 0;
        this.holyProgress = 0;
        this.darkProgress = 0;

        this.swordGold = 60;
        this.polearmGold = 60;
        this.heavyWeaponryGold = 60;
        this.longRangeGold = 100;

        this.swordShopDamage = 5;
        this.polearmShopDamage = 5;
        this.heavyWeaponryShopDamage = 5;
        this.longRangeShopDamage = 5;
        this.swordProgress = 0;
        this.polearmProgress = 0;
        this.heavyWeaponryProgress = 0;
        this.longRangeProgress = 0;
        

       

        this.magicVendorList = new List<int>();
        this.blackSmithList = new List<int>();
        this.mageList = new List<int>();
        this.graveDiggerList = new List<int>();
        this.girlList = new List<int>();
        this.devilList = new List<int>();

        this.hasDialogueG = 0;
        this.hasDialogueM = 0;





        this.acidDuration = 40;
        this.darkDuration = 40;
        this.earthDuration = 40;
        this.fireDuration = 40;
        this.holyDuration = 40;
        this.iceDuration = 40;
        this.thunderDuration = 40;
        this.waterDuration = 40;
        this.windDuration = 40;
        this.natureDuration = 40;

        this.IsActiveAcid = false;
        this.IsActiveDark = false;
        this.IsActiveEarth = false;
        this.IsActiveFire = false;
        this.IsActiveHoly = false;
        this.IsActiveIce = false;
        this.IsActiveThunder = false;
        this.IsActiveWater = false;
        this.IsActiveWind = false;
        this.IsActiveNature = false;






    }

/*
    public int GetPercentageComplete() 
    {
        // figure out how many coins we've collected
        int totalCollected = 0;
        foreach (bool collected in coinsCollected.Values) 
        {
            if (collected) 
            {
                totalCollected++;
            }
        }

        // ensure we don't divide by 0 when calculating the percentage
        int percentageCompleted = -1;
        if (coinsCollected.Count != 0) 
        {
            percentageCompleted = (totalCollected * 100 / coinsCollected.Count);
        }
        return percentageCompleted;
    }
    */
}