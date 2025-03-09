using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;
    public float bonusMovementVelocity;

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public float bonusJumpVelocity;
    public int amountOfJumps = 1;
    public int bonusAmountOfJumps;

    [Header("Wall Jump State")]
    public float wallJumpVelocity = 20;
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);

    [Header("In Air State")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;

    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;

    [Header("Wall Climb State")]
    public float wallClimbVelocity = 3f;

    [Header("Ledge Climb State")]
    public Vector2 startOffset;
    public Vector2 stopOffset;

    [Header("Dash State")]
    public float dashCooldown = 2f;
    public float minusDashCooldown;
     public float maxHoldTime = 1f;
    public float holdTimeScale = 0.25f;
    public float dashTime = 0.2f;
 //   public float bonusDashTime;
    public float dashVelocity = 30f;
    public float bonusDashVelocity;
    public float drag = 10f;
    public float dashEndYMultiplier = 0.2f;
    public float distBetweenAfterImages = 0.5f;

    [Header("Crouch States")]
    public float crouchMovementVelocity = 5f;
    public float crouchColliderHeight = 0.8f;
    public float standColliderHeight = 1.6f;

    [Header("Stun State")] public float stunTime = 2f;

    [Header("Slopes")]
    public PhysicsMaterial2D noFriction;
    public PhysicsMaterial2D fullFriction;
     

         [Header("Health")]
        public float MaxHealth;
        public float bonusMaxHealth;
        public float currentHealth;
        public float bonusCurrentHealth;
        private Player player;
        public bool IsRegenActive;
        public float regenHealAmount;
        public int regenDuration;
        [Header("IFrames")]
        public bool isInvulnerable = false;
        public float iFramesDuration = 1;
        public int numberOfFlashes = 4;


         public void IncreaseHealth(float amount) 
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            currentHealth += amount;
            player.SetCurrentHealth(amount);
        }

        public void DecreaseHealth(float amount)
        {   
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            currentHealth -= amount;
            player.SetCurrentHealth(currentHealth);
        }

        [Header("Extra Life")]
        public int bonusAmountOfLives;

        [Header("Invincibility Shield")]
        public float shieldOnDuration;
        public float shieldOffDuration;
        public int numberOfFlashesShield;
        public bool isShieldActive;

        [Header("Projectile Shooter")]

        public GameObject acidProjectile;
        public GameObject darkProjectile;
        public GameObject earthProjectile;
        public GameObject fireProjectile;
        public GameObject holyProjectile;
        public GameObject iceProjectile;
        public GameObject thunderProjectile;
        public GameObject waterProjectile;
        public GameObject windProjectile;
        public GameObject natureProjectile;

    

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


        

      

}
