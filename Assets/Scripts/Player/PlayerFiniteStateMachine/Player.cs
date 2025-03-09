using System.Collections;
using System.Collections.Generic;
using Prodigy.Weapons;
using Prodigy.CoreSystem;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Prodigy.EventChannels;
using UnityEngine.SceneManagement;
using System;
using Prodigy;


//using Prodigy.FSM;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallGrabState WallGrabState { get; private set; }
    public PlayerWallClimbState WallClimbState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerLedgeClimbState LedgeClimbState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerAttackState PrimaryAttackState { get; private set; }
    public PlayerAttackState SecondaryAttackState { get; private set; }


    public PlayerData playerData;
    #endregion

    #region Components
    public Core Core { get; private set; }
    public Stats Stats { get; private set; }
    public Death Death { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Transform DashDirectionIndicator { get; private set; }
    public CapsuleCollider2D MovementCollider { get; private set; }
    public SoundManager soundManager {get; private set; }


    private static Player _instance;
     public static Player instance
  {
    get
    {
      return _instance;
    }
  }



    
    public SpriteRenderer spriteRenderer { get; private set; }
    public GameObject shield;


    
        




    public Attribute[] attributes;
    #endregion

    #region Other Variables         

    private Vector2 workspace;

    private Weapon primaryWeapon;
    private Weapon secondaryWeapon;


    
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        Core = GetComponentInChildren<Core>();
        Stats = GetComponentInChildren<Stats>();
        Death = GetComponentInChildren<Death>();
        
        primaryWeapon = transform.Find("PrimaryWeapon").GetComponent<Weapon>();
        secondaryWeapon = transform.Find("SecondaryWeapon").GetComponent<Weapon>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        DashDirectionIndicator = transform.Find("DashDirectionIndicator");

        MovementCollider = GetComponent<CapsuleCollider2D>();
        
        


        primaryWeapon.SetCore(Core);
        secondaryWeapon.SetCore(Core);

        soundManager = FindObjectOfType<SoundManager>();
        
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, soundManager, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, soundManager, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, soundManager, "inAir");
        AirState = new PlayerAirState(this, StateMachine, playerData, soundManager, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, soundManager, "land");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, soundManager, "wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, playerData,soundManager, "wallGrab");
        WallClimbState = new PlayerWallClimbState(this, StateMachine, playerData,soundManager, "wallClimb");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData,soundManager, "inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, playerData,soundManager, "ledgeClimbState");
        DashState = new PlayerDashState(this, StateMachine, playerData,soundManager, "inAir");
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, playerData,soundManager, "attack", primaryWeapon, CombatInputs.primary);
        SecondaryAttackState = new PlayerAttackState(this, StateMachine, playerData,soundManager, "attack", secondaryWeapon, CombatInputs.secondary);
    }

    private void Start()
    {
        


        StateMachine.Initialize(IdleState);




        

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            playerData.currentHealth = playerData.MaxHealth;
            Healthbar.instance.SetFreshHealth(playerData.MaxHealth);
            playerData.isShieldActive = false;
        }
      

        Healthbar.instance.SetMaxHealth(playerData.MaxHealth);
        Healthbar.instance.SetCurrentHealth(playerData.currentHealth);

        if(playerData.isShieldActive)
        {
            StartCoroutine(BuffManager.instance.InvincibilityShield());
        }
        if(playerData.IsRegenActive)
        {
            StartCoroutine(BuffManager.instance.HealOverTimeCoroutine(playerData.regenHealAmount, playerData.regenDuration));
        }

    
    }

    private void OnEnable() {
        spriteRenderer.color = Color.white;  
        playerData.isInvulnerable = false;
    }
  

    private void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();


    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Other Functions

    public void SetColliderHeight(float height)
    {
        Vector2 center = MovementCollider.offset;
        workspace.Set(MovementCollider.size.x, height);

        center.y += (height - MovementCollider.size.y) / 2;

        MovementCollider.size = workspace;
        MovementCollider.offset = center;
    }   

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimtionFinishTrigger() => StateMachine.CurrentState.AnimationFinishTriger();

  


    public void DecreaseHealth (float Amount) {
        if(playerData.isInvulnerable == false)    
        {   
            playerData.DecreaseHealth(Amount);
            SoundManager.instance.Play("GetHit");
            StartCoroutine(BuffManager.instance.Invunerability());
            
        }
    }
    

    public void SetMaxHealth(float bonusHealth) {
        Healthbar.instance.SetMaxHealth(bonusHealth);
    }
    public void SetCurrentHealth(float bonusHealth) {
        Healthbar.instance.SetCurrentHealth(bonusHealth);
    }

 
   public void CheckIfDead () 
   {
        if(playerData.currentHealth < 0 || playerData.currentHealth == 0)
        {
            if(playerData.bonusAmountOfLives > 0)
            {
                Ressurect();
            }
            else
            {
                Death.PlayerDie();
            }
        } 
   }

   public void Ressurect () {
                StartCoroutine(BuffManager.instance.Invunerability());
                playerData.currentHealth = (playerData.MaxHealth / 2);
                Healthbar.instance.SetCurrentHealth(playerData.currentHealth);
                soundManager.Play("Revive");
                playerData.bonusAmountOfLives--;
   }

    

   
                

            
        }

#endregion
    
