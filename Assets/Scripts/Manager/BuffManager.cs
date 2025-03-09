using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Prodigy.Weapons;

namespace Prodigy
{
    public class BuffManager : MonoBehaviour
    {
        private static BuffManager _instance;

        public static BuffManager instance
        {
            get
            {
            return _instance;
            }
        }

        
        [SerializeField]
        private PlayerData playerData;
        [SerializeField]
        private ElementData elementData;
        private Player player;
        private Weapon weaponPrimary;
        private Weapon weaponSecondary;
        private GameObject playerGO;
        protected GameObject projectile;
        protected ProjectileOld projectileScript;

        private void Awake() {

            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            playerGO = GameObject.FindWithTag("Player");
            weaponPrimary = playerGO.GetComponentInChildren<Weapon>();
            weaponSecondary = GameObject.FindWithTag("SecondaryWeapon").GetComponent<Weapon>();

        }
        


        private void Start() {
            
            if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            playerData.amountOfJumps -= playerData.bonusAmountOfJumps;
            playerData.jumpVelocity -= playerData.bonusJumpVelocity;
            playerData.movementVelocity -= playerData.bonusMovementVelocity;
            playerData.MaxHealth -= playerData.bonusMaxHealth;
            playerData.currentHealth -= playerData.bonusCurrentHealth;
            playerData.dashVelocity -= playerData.bonusDashVelocity;
       //     playerData.dashTime -= playerData.bonusDashTime;
            playerData.dashCooldown += playerData.minusDashCooldown;
            
            playerData.bonusAmountOfJumps = 0;
            playerData.bonusJumpVelocity = 0;
            playerData.bonusMovementVelocity = 0;
            playerData.bonusMaxHealth = 0;
            playerData.bonusCurrentHealth = 0;
            playerData.bonusDashVelocity = 0;
       //     playerData.bonusDashTime = 0;
            playerData.minusDashCooldown = 0;

            playerData.IsRegenActive = false;
            playerData.regenHealAmount = 0;

            playerData.bonusAmountOfLives = 0;

            playerData.shieldOffDuration = 0;
            playerData.shieldOnDuration = 0;
            playerData.isShieldActive = false;
            playerData.numberOfFlashesShield = 0;




            elementData.acidDamage -= elementData.bonusAcidDamage;
            elementData.darkDamage -= elementData.bonusDarkDamage;
            elementData.earthDamage -= elementData.bonusEarthDamage;
            elementData.fireDamage -= elementData.bonusFireDamage;
            elementData.holyDamage -= elementData.bonusHolyDamage;
            elementData.iceDamage -= elementData.bonusIceDamage;
            elementData.thunderDamage -= elementData.bonusThunderDamage;
            elementData.waterDamage -= elementData.bonusWaterDamage;
            elementData.windDamage -= elementData.bonusWindDamage;
            elementData.woodDamage -= elementData.bonusWoodDamage;

            elementData.bonusAcidDamage = 0;
            elementData.bonusDarkDamage = 0;
            elementData.bonusEarthDamage = 0;
            elementData.bonusFireDamage = 0;
            elementData.bonusHolyDamage = 0;
            elementData.bonusIceDamage = 0;
            elementData.bonusThunderDamage = 0;
            elementData.bonusWaterDamage = 0;
            elementData.bonusWaterDamage = 0;
            elementData.bonusWindDamage = 0;
            elementData.bonusWoodDamage = 0;


            elementData.swordDamage -= elementData.bonusSwordDamage;
            elementData.polearmDamage -= elementData.bonusPolearmDamage;
            elementData.heavyDamage -= elementData.bonusHeavyDamage;
            elementData.longRangeDamage -= elementData.bonusLongRangeDamage;


            elementData.bonusSwordDamage = 0;
            elementData.bonusPolearmDamage = 0;
            elementData.bonusHeavyDamage = 0;
            elementData.bonusLongRangeDamage = 0;

            playerData.IsActiveAcid = false;
            playerData.IsActiveDark = false;
            playerData.IsActiveEarth = false;
            playerData.IsActiveFire = false;
            playerData.IsActiveHoly = false;
            playerData.IsActiveIce = false;
            playerData.IsActiveNature = false;
            playerData.IsActiveWater = false;
            playerData.IsActiveWind = false;

            
            
        }
         else
         {
            if(playerData.IsActiveAcid)
                StartCoroutine(Acid());
            else if(playerData.IsActiveDark)
                StartCoroutine(Dark());
            else if(playerData.IsActiveEarth)
                StartCoroutine(Earth());
            else if(playerData.IsActiveFire)
                StartCoroutine(Fire());
            else if(playerData.IsActiveHoly)
                StartCoroutine(Holy());
            else if(playerData.IsActiveIce)
                StartCoroutine(Ice());
            else if(playerData.IsActiveNature)
                StartCoroutine(Nature());
            else if(playerData.IsActiveThunder)
                StartCoroutine(Thunder());
            else if(playerData.IsActiveWater)
                StartCoroutine(Water());
            else if(playerData.IsActiveWind){
                StartCoroutine(Wind());}
         }   

            
            
        }

        public void JumpBuff (float bonusJumpVelocity) {
            playerData.bonusJumpVelocity += bonusJumpVelocity;
            playerData.jumpVelocity += bonusJumpVelocity;
            player.soundManager.Play("JumpBuff");
        }

        public void MovementBuff (float bonusMovementVelocity) {
            playerData.bonusMovementVelocity += bonusMovementVelocity;
            playerData.movementVelocity += bonusMovementVelocity;
            player.soundManager.Play("MovementBuff");
        }

        public void ExtraJump (int bonusAmountOfJumps) {
            playerData.bonusAmountOfJumps += bonusAmountOfJumps;
            playerData.amountOfJumps += bonusAmountOfJumps;
            player.soundManager.Play("JumpBuff");
        }

        public void Heal (float healAmount) {
            playerData.currentHealth += healAmount;
            if(playerData.currentHealth > playerData.MaxHealth)
            {
                playerData.currentHealth += (playerData.MaxHealth - playerData.currentHealth);
            }
            player.soundManager.Play("Heal");
            player.SetCurrentHealth(playerData.currentHealth);
        }

        public void HealthBuff (float bonusHealth) {
            playerData.bonusMaxHealth += bonusHealth;
            playerData.MaxHealth += bonusHealth;
            playerData.bonusCurrentHealth += bonusHealth;
            playerData.currentHealth += bonusHealth;
            player.soundManager.Play("Health");
       //     player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            player.SetMaxHealth(playerData.MaxHealth);
            player.SetCurrentHealth(playerData.currentHealth);
        }

        public void HealOverTime(float healAmount, int regenDuration) {
            playerData.IsRegenActive = true;
            playerData.regenHealAmount = healAmount;
            playerData.regenDuration = regenDuration;
            player.soundManager.Play("Regen");
            StartCoroutine(HealOverTimeCoroutine(healAmount, regenDuration));
        }

        

        public void DashBuff (float bonusDashVelocity, float minusDashCooldown) {
            playerData.bonusDashVelocity += bonusDashVelocity;
            playerData.dashVelocity += bonusDashVelocity;

     //       playerData.bonusDashTime += bonusDashTime;
     //       playerData.dashTime += bonusDashTime;

            playerData.minusDashCooldown += minusDashCooldown;
            playerData.dashCooldown -= minusDashCooldown;
            player.soundManager.Play("DashBuff");
        }


        public void ExtraLife (int bonusAmountOfLives) {
            playerData.bonusAmountOfLives += bonusAmountOfLives;
        }

        public void InvincibilityShield (float shieldOnDuration, float shieldOffDuration, int numberOfFlashes) {
            playerData.shieldOnDuration += shieldOnDuration;
            playerData.shieldOffDuration += shieldOffDuration;
            playerData.numberOfFlashesShield += numberOfFlashes;
            player.soundManager.Play("Shield");
            if(!playerData.isShieldActive)
            {
                StartCoroutine(InvincibilityShield());
            } 
        }       


        public void ShootProjectiles (Element element) {


            switch (element)
            {
                case Element.Acid:
                    playerData.acidDuration = 40;
                    StartCoroutine(Acid());
                break;
                case Element.Dark:
                    playerData.darkDuration = 40;
                    StartCoroutine(Dark());
                break;
                case Element.Earth:
                    playerData.earthDuration = 40;
                    StartCoroutine(Earth());
                break;
                case Element.Fire:
                    playerData.fireDuration = 40;
                    StartCoroutine(Fire());
                break;
                case Element.Holy:
                    playerData.holyDuration = 40;
                    StartCoroutine(Holy());
                break;
                case Element.Ice:
                    playerData.iceDuration = 40;
                    StartCoroutine(Ice());
                break;
                case Element.Thunder:
                    playerData.thunderDuration = 40;
                    StartCoroutine(Thunder());
                break;
                case Element.Water:
                    playerData.waterDuration = 40;
                    StartCoroutine(Water());
                break;
                case Element.Wind:
                    playerData.windDuration = 40;
                    StartCoroutine(Wind());
                break;
                case Element.Nature:
                    playerData.natureDuration = 40;
                    StartCoroutine(Nature());
                break;

            }

        }

       
        private IEnumerator Fire()
        {
            playerData.IsActiveFire = true; 
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < playerData.fireDuration; i++) {
                projectile = GameObject.Instantiate(playerData.fireProjectile, player.transform.position, player.transform.rotation);
                projectileScript = projectile.GetComponent<ProjectileOld>();
                projectileScript.FireProjectile(elementData.fireProjectileSpeed,elementData.fireTravelDistance, elementData.fireProjectileDamage + elementData.fireDamage);
                playerData.fireDuration--;
                SoundManager.instance.Play("Fire");
                yield return new WaitForSeconds(3f);
            }
            playerData.IsActiveFire = false;  
        }

        private IEnumerator Water()
        {
            playerData.IsActiveWater = true; 
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < playerData.waterDuration; i++) {
                projectile = GameObject.Instantiate(playerData.waterProjectile, player.transform.position, player.transform.rotation);
                projectileScript = projectile.GetComponent<ProjectileOld>();
                projectileScript.FireProjectile(elementData.waterProjectileSpeed,elementData.waterTravelDistance, elementData.waterProjectileDamage + elementData.waterDamage);
                playerData.waterDuration--; 
                SoundManager.instance.Play("Water");
                yield return new WaitForSeconds(3f);
            }
            playerData.IsActiveWater = false;  
        }

        private IEnumerator Earth()
        {
            playerData.IsActiveEarth = true; 
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < playerData.earthDuration; i++) {
                projectile = GameObject.Instantiate(playerData.earthProjectile, player.transform.position, player.transform.rotation);
                projectileScript = projectile.GetComponent<ProjectileOld>();
                projectileScript.FireProjectile(elementData.earthProjectileSpeed,elementData.earthTravelDistance, elementData.earthProjectileDamage + elementData.earthDamage);
                playerData.earthDuration--;
                SoundManager.instance.Play("Earth");
                yield return new WaitForSeconds(3f);
            }
            playerData.IsActiveEarth = false;  
        }

        private IEnumerator Wind()
        {
            playerData.IsActiveWind = true; 
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < playerData.windDuration; i++) {
                projectile = GameObject.Instantiate(playerData.windProjectile, player.transform.position, player.transform.rotation);
                projectileScript = projectile.GetComponent<ProjectileOld>();
                projectileScript.FireProjectile(elementData.windProjectileSpeed,elementData.windTravelDistance, elementData.windProjectileDamage + elementData.windDamage);
                playerData.windDuration--;
                SoundManager.instance.Play("Wind");
                yield return new WaitForSeconds(3f);
            }
            playerData.IsActiveWind = false;  
        }

        private IEnumerator Thunder()
        {
            playerData.IsActiveThunder = true; 
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < playerData.thunderDuration; i++) {
                projectile = GameObject.Instantiate(playerData.thunderProjectile, player.transform.position, player.transform.rotation);
                projectileScript = projectile.GetComponent<ProjectileOld>();
                projectileScript.FireProjectile(elementData.thunderProjectileSpeed,elementData.thunderTravelDistance, elementData.thunderProjectileDamage + elementData.thunderDamage);
                playerData.thunderDuration--; 
                SoundManager.instance.Play("Thunder");
                yield return new WaitForSeconds(3f);
            }
            playerData.IsActiveThunder = false;  
        }

        private IEnumerator Ice()
        {
            playerData.IsActiveIce = true; 
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < playerData.iceDuration; i++) {
                projectile = GameObject.Instantiate(playerData.iceProjectile, player.transform.position, player.transform.rotation);
                projectileScript = projectile.GetComponent<ProjectileOld>();
                projectileScript.FireProjectile(elementData.iceProjectileSpeed,elementData.iceTravelDistance, elementData.iceProjectileDamage + elementData.iceDamage);
                playerData.iceDuration--;
                yield return new WaitForSeconds(3f);
            }
            playerData.IsActiveIce = false;  
        }
        private IEnumerator Nature()
        {
            playerData.IsActiveNature = true; 
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < playerData.natureDuration; i++) {
                projectile = GameObject.Instantiate(playerData.natureProjectile, player.transform.position, player.transform.rotation);
                projectileScript = projectile.GetComponent<ProjectileOld>();
                projectileScript.FireProjectile(elementData.natureProjectileSpeed,elementData.natureTravelDistance, elementData.natureProjectileDamage + elementData.woodDamage);
                playerData.natureDuration--;
                SoundManager.instance.Play("Nature");
                yield return new WaitForSeconds(3f);
            }
            playerData.IsActiveNature = false;  
        }
        private IEnumerator Acid()
        {
            playerData.IsActiveAcid = true; 
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < playerData.acidDuration; i++) {
                projectile = GameObject.Instantiate(playerData.acidProjectile, player.transform.position, player.transform.rotation);
                projectileScript = projectile.GetComponent<ProjectileOld>();
                projectileScript.FireProjectile(elementData.acidProjectileSpeed,elementData.acidTravelDistance, elementData.acidProjectileDamage + elementData.acidDamage);
                playerData.acidDuration--;
                SoundManager.instance.Play("Acid");
                yield return new WaitForSeconds(3f);
            }
            playerData.IsActiveAcid = false;  
        }
        private IEnumerator Holy()
        {
            playerData.IsActiveHoly = true; 
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < playerData.holyDuration; i++) {
                projectile = GameObject.Instantiate(playerData.holyProjectile, player.transform.position, player.transform.rotation);
                projectileScript = projectile.GetComponent<ProjectileOld>();
                projectileScript.FireProjectile(elementData.holyProjectileSpeed,elementData.holyTravelDistance, elementData.holyProjectileDamage + elementData.holyDamage);
                playerData.holyDuration--;
                SoundManager.instance.Play("Holy");
                yield return new WaitForSeconds(3f);
            }
            playerData.IsActiveHoly = false;  
        }
        private IEnumerator Dark()
        {
            playerData.IsActiveDark = true; 
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < playerData.darkDuration; i++) {
                projectile = GameObject.Instantiate(playerData.darkProjectile, player.transform.position, player.transform.rotation);
                projectileScript = projectile.GetComponent<ProjectileOld>();
                projectileScript.FireProjectile(elementData.darkProjectileSpeed,elementData.darkTravelDistance, elementData.darkProjectileDamage + elementData.darkDamage);
                playerData.darkDuration--;
                SoundManager.instance.Play("Dark");
                yield return new WaitForSeconds(3f);
            }
            playerData.IsActiveDark = false;  
        }

       


        public void ElementBuff (float bonusElementDamage, Element element) {

            switch (element)
            {
                case Element.Acid:
                elementData.bonusAcidDamage += bonusElementDamage;
                elementData.acidDamage += bonusElementDamage;
                SoundManager.instance.Play("Acid");
                break;
                case Element.Dark:
                elementData.bonusDarkDamage += bonusElementDamage;
                elementData.darkDamage += bonusElementDamage;
                SoundManager.instance.Play("Dark");
                break;
                case Element.Earth:
                elementData.bonusEarthDamage += bonusElementDamage;
                elementData.earthDamage += bonusElementDamage;
                    SoundManager.instance.Play("Earth");
                break;
                case Element.Fire:
                elementData.bonusFireDamage += bonusElementDamage;
                elementData.fireDamage += bonusElementDamage; 
                    SoundManager.instance.Play("Fire");
                break;
                case Element.Holy:
                elementData.bonusHolyDamage += bonusElementDamage;
                elementData.holyDamage += bonusElementDamage; 
                    SoundManager.instance.Play("Holy");
                break;
                case Element.Ice:
                elementData.bonusIceDamage += bonusElementDamage;
                elementData.iceDamage += bonusElementDamage;
                    SoundManager.instance.Play("Ice");
                break;
                case Element.Thunder:
                elementData.bonusThunderDamage += bonusElementDamage;
                elementData.thunderDamage += bonusElementDamage;
                    SoundManager.instance.Play("Thunder"); 
                break;
                case Element.Water:
                elementData.bonusWaterDamage += bonusElementDamage;
                elementData.waterDamage += bonusElementDamage;
                    SoundManager.instance.Play("Water");
                break;
                case Element.Wind:
                elementData.bonusWindDamage += bonusElementDamage;
                elementData.windDamage += bonusElementDamage; 
                    SoundManager.instance.Play("Wind");
                break;
                case Element.Nature:
                elementData.bonusWoodDamage += bonusElementDamage;
                elementData.woodDamage += bonusElementDamage; 
                    SoundManager.instance.Play("Nature");
                break;
            }
            weaponPrimary.AddWeaponBuffs();
            weaponSecondary.AddWeaponBuffs();

        }


        public void DamageBuff (float bonusDamage, ItemType weaponType) {
            if(weaponType == ItemType.Swords) {
                elementData.swordDamage += bonusDamage;
                elementData.bonusSwordDamage += bonusDamage;
                    SoundManager.instance.Play("SwordBuff");
                }
            else if(weaponType == ItemType.Polearms) {
                elementData.polearmDamage += bonusDamage;
                elementData.bonusPolearmDamage += bonusDamage; 
                    SoundManager.instance.Play("PolearmBuff");
                }
            else if(weaponType == ItemType.HeavyWeaponry) {
                elementData.heavyDamage += bonusDamage; 
                elementData.bonusHeavyDamage += bonusDamage;
                    SoundManager.instance.Play("HeavyBuff");
                }
            else if(weaponType == ItemType.LongRangeWeapons) {
                elementData.longRangeDamage += bonusDamage;
                elementData.bonusLongRangeDamage += bonusDamage; 
                    SoundManager.instance.Play("LongBuff");
                }
            weaponPrimary.AddWeaponBuffs();
            weaponSecondary.AddWeaponBuffs();
        }






        public IEnumerator Invunerability()
            {
                playerData.isInvulnerable = true;

                for(int i = 0; i < playerData.numberOfFlashes; i++) {
                    player.spriteRenderer.color = new Color(1, 0, 0, 0.5f);
                    yield return new WaitForSeconds(playerData.iFramesDuration / (playerData.numberOfFlashes * 2));
                    player.spriteRenderer.color = Color.white;   
                    yield return new WaitForSeconds(playerData.iFramesDuration / (playerData.numberOfFlashes * 2));        
                }
                playerData.isInvulnerable = false;
            }


         public IEnumerator InvincibilityShield()
    {
            player.shield.SetActive(true);
            playerData.isShieldActive = true;
            playerData.isInvulnerable = true;
        for(int i = 0; i < playerData.numberOfFlashesShield; i++) {
            player.shield.GetComponent<SpriteRenderer>().color = new Color32(170, 130, 160, 130);
            Debug.Log("Invicibility shield is on");
            yield return new WaitForSeconds(playerData.shieldOnDuration);
            playerData.isInvulnerable = false;


            player.shield.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
            yield return new WaitForSeconds(playerData.shieldOffDuration);        
            playerData.isInvulnerable = true;
            playerData.numberOfFlashesShield--;
        }

        playerData.isShieldActive = false;
        
    }

    public IEnumerator HealOverTimeCoroutine(float healAmount, int regenDuration)
        {
            
        for(int i = 0; i < regenDuration; i++) 
        {  
            if(playerData.currentHealth < playerData.MaxHealth)
            {
                playerData.currentHealth += healAmount;
                player.SetCurrentHealth(playerData.currentHealth);
                if(playerData.regenDuration != 0)
                {
                    playerData.regenDuration--;
                }
            }
            
            yield return new WaitForSeconds(2f);
        }
        }
    }

}

