using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prodigy
{
    public class VariableManager : MonoBehaviour, IDataPersistence
    {
        [SerializeField]
        private PlayerData playerData;
        [SerializeField]
        private ElementData elementData;
        private int currentSceneID;

        private void Awake() {
            currentSceneID = SceneManager.GetActiveScene().buildIndex;
        }



        public void SaveData (GameData data) {
            data.currentSceneID = this.currentSceneID;

            data.acidDamage = elementData.acidDamage;
            data.darkDamage = elementData.darkDamage;
            data.earthDamage = elementData.earthDamage;
            data.fireDamage = elementData.fireDamage;
            data.holyDamage = elementData.holyDamage;
            data.iceDamage = elementData.iceDamage;
            data.thunderDamage = elementData.thunderDamage;
            data.waterDamage = elementData.waterDamage;
            data.windDamage = elementData.windDamage;
            data.woodDamage = elementData.woodDamage;

            data.acidDamage = elementData.acidDamage;
            data.bonusDarkDamage = elementData.bonusDarkDamage;
            data.bonusEarthDamage = elementData.bonusEarthDamage;
            data.bonusFireDamage = elementData.bonusFireDamage;
            data.bonusHolyDamage = elementData.bonusHolyDamage;
            data.bonusIceDamage = elementData.bonusIceDamage;
            data.bonusThunderDamage = elementData.bonusThunderDamage;
            data.bonusWaterDamage = elementData.bonusWaterDamage;
            data.bonusWindDamage = elementData.bonusWindDamage;
            data.bonusWoodDamage = elementData.bonusWoodDamage;
            
            data.heavyDamage = elementData.heavyDamage;
            data.longRangeDamage = elementData.longRangeDamage;
            data.polearmDamage = elementData.polearmDamage;
            data.swordDamage = elementData.swordDamage;
            
            data.bonusHeavyDamage = elementData.bonusHeavyDamage;
            data.bonusLongRangeDamage = elementData.bonusLongRangeDamage;
            data.bonusPolearmDamage = elementData.bonusPolearmDamage;
            data.bonusSwordDamage = elementData.bonusSwordDamage;


            data.movementVelocity = playerData.movementVelocity;
            data.bonusMovementVelocity = playerData.bonusMovementVelocity;
            data.jumpVelocity = playerData.jumpVelocity;
            data.bonusJumpVelocity = playerData.bonusJumpVelocity;
            data.amountOfJumps = playerData.amountOfJumps;
            data.bonusAmountOfJumps = playerData.bonusAmountOfJumps;
            data.dashCooldown = playerData.dashCooldown;
            data.minusDashCooldown = playerData.minusDashCooldown;
            data.dashVelocity = playerData.dashVelocity;
            data.bonusDashVelocity = playerData.bonusDashVelocity;
            data.MaxHealth = playerData.MaxHealth;
            data.bonusMaxHealth = playerData.bonusMaxHealth;
            data.currentHealth = playerData.currentHealth;
            data.bonusCurrentHealth = playerData.bonusCurrentHealth;
            data.IsRegenActive = playerData.IsRegenActive;
            data.regenDuration = playerData.regenDuration;
            data.regenHealAmount = playerData.regenHealAmount;
            data.bonusAmountOfLives = playerData.bonusAmountOfLives;
            data.shieldOnDuration = playerData.shieldOnDuration;
            data.shieldOffDuration = playerData.shieldOffDuration;
            data.numberOfFlashes = playerData.numberOfFlashesShield;
            data.isShieldActive = playerData.isShieldActive;


            data.acidDuration = playerData.acidDuration;
            data.darkDuration = playerData.darkDuration;
            data.earthDuration = playerData.earthDuration;
            data.fireDuration = playerData.fireDuration;
            data.holyDuration = playerData.holyDuration;
            data.iceDuration = playerData.iceDuration;
            data.thunderDuration = playerData.thunderDuration;
            data.waterDuration = playerData.waterDuration;
            data.waterDuration = playerData.windDuration;
            data.natureDuration = playerData.natureDuration;

            data.IsActiveAcid = playerData.IsActiveAcid;
            data.IsActiveDark = playerData.IsActiveDark;
            data.IsActiveEarth = playerData.IsActiveEarth;
            data.IsActiveFire = playerData.IsActiveFire;
            data.IsActiveHoly = playerData.IsActiveHoly;
            data.IsActiveIce = playerData.IsActiveIce;
            data.IsActiveThunder = playerData.IsActiveThunder;
            data.IsActiveWater = playerData.IsActiveWater;
            data.IsActiveWind = playerData.IsActiveWind;
            data.IsActiveNature = playerData.IsActiveNature;

        }

        public void LoadData (GameData data) {
            elementData.acidDamage = data.acidDamage;


            elementData.acidDamage = data.acidDamage;
            elementData.darkDamage = data.darkDamage;
            elementData.earthDamage = data.earthDamage;
            elementData.fireDamage = data.fireDamage;
            elementData.holyDamage = data.holyDamage;
            elementData.iceDamage = data.iceDamage;
            elementData.thunderDamage = data.thunderDamage;
            elementData.waterDamage = data.waterDamage;
            elementData.windDamage = data.windDamage;
            elementData.woodDamage = data.woodDamage;

            elementData.acidDamage = data.acidDamage;
            elementData.bonusDarkDamage = data.bonusDarkDamage;
            elementData.bonusEarthDamage = data.bonusEarthDamage;
            elementData.bonusFireDamage = data.bonusFireDamage;
            elementData.bonusHolyDamage = data.bonusHolyDamage;
            elementData.bonusIceDamage = data.bonusIceDamage;
            elementData.bonusThunderDamage = data.bonusThunderDamage;
            elementData.bonusWaterDamage = data.bonusWaterDamage;
            elementData.bonusWindDamage = data.bonusWindDamage;
            elementData.bonusWoodDamage = data.bonusWoodDamage;

            elementData.bonusHeavyDamage = data.bonusHeavyDamage;
            elementData.bonusLongRangeDamage = data.bonusLongRangeDamage;
            elementData.bonusPolearmDamage = data.bonusPolearmDamage;
            elementData.bonusSwordDamage = data.bonusSwordDamage;




            playerData.movementVelocity = data.movementVelocity;
            playerData.bonusMovementVelocity = data.bonusMovementVelocity;
            playerData.jumpVelocity = data.jumpVelocity;
            playerData.bonusJumpVelocity = data.bonusJumpVelocity;
            playerData.amountOfJumps = data.amountOfJumps;
            playerData.bonusAmountOfJumps = data.bonusAmountOfJumps;
            playerData.dashCooldown = data.dashCooldown;
            playerData.minusDashCooldown = data.minusDashCooldown;
            playerData.dashVelocity = data.dashVelocity;
            playerData.bonusDashVelocity = data.bonusDashVelocity;
            playerData.MaxHealth = data.MaxHealth;
            playerData.bonusMaxHealth = data.bonusMaxHealth;
            playerData.currentHealth = data.currentHealth;
            playerData.bonusCurrentHealth = data.bonusCurrentHealth;
            playerData.IsRegenActive = data.IsRegenActive;
            playerData.regenHealAmount = data.regenHealAmount;
            playerData.regenDuration = data.regenDuration;
            playerData.bonusAmountOfLives = data.bonusAmountOfLives;
            playerData.shieldOnDuration = data.shieldOnDuration;
            playerData.shieldOffDuration = data.shieldOffDuration;
            playerData.numberOfFlashesShield = data.numberOfFlashes;
            playerData.isShieldActive = data.isShieldActive;


            playerData.acidDuration = data.acidDuration;
            playerData.darkDuration =  data.darkDuration;
            playerData.earthDuration = data.earthDuration;
            playerData.fireDuration = data.fireDuration;
            playerData.holyDuration = data.holyDuration;
            playerData.iceDuration = data.iceDuration;
            playerData.thunderDuration = data.thunderDuration;
            playerData.waterDuration = data.waterDuration;
            playerData.windDuration = data.waterDuration;
            playerData.natureDuration = data.natureDuration;

            playerData.IsActiveAcid = data.IsActiveAcid;
            playerData.IsActiveDark = data.IsActiveDark;
            playerData.IsActiveEarth = data.IsActiveEarth;
            playerData.IsActiveFire = data.IsActiveFire;
            playerData.IsActiveHoly = data.IsActiveHoly;
            playerData.IsActiveIce = data.IsActiveIce;
            playerData.IsActiveThunder = data.IsActiveThunder;
            playerData.IsActiveWater = data.IsActiveWater;
            playerData.IsActiveWind = data.IsActiveWind;
            playerData.IsActiveNature = data.IsActiveNature;

        }

    }
}
