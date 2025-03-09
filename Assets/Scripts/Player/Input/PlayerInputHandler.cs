using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Prodigy.EventChannels;
using Prodigy.Managers;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;

    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool GrabInput { get; private set; }
    public bool DashInput { get; private set; }
    public bool DashInputStop { get; private set; }
    public bool InventoryInput { get; private set; }
    public bool PauseMenuInput { get; private set; }
    public bool InteractInput { get; private set; }
      private bool submitPressed = false;

    public bool[] AttackInputs { get; private set; }

     public event Action<bool> OnInteract;

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float jumpInputStartTime;
    private float dashInputStartTime;

    private static PlayerInputHandler instance;

    private void Awake() {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;

       
    }
    public static PlayerInputHandler GetInstance() 
    {
        return instance;
    }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[count];

        cam = Camera.main;
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();


    }

   

  
  public void OnInteractedInput(InputAction.CallbackContext context)
  {
    if (context.started)
    {
      OnInteract?.Invoke(true);
    }

    if (context.canceled)
    {
      OnInteract?.Invoke(false);
    }
  }

 


    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {

            if (context.started && !UIManager.IsPause)
            {
                AttackInputs[(int)CombatInputs.primary] = true;
            }

            if (context.canceled)
            {
                AttackInputs[(int)CombatInputs.primary] = false;
            }
    }

    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started && !UIManager.IsPause)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }

        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if(!UIManager.IsPause)
        {
            RawMovementInput = context.ReadValue<Vector2>();

            NormInputX = Mathf.RoundToInt(RawMovementInput.x);
            NormInputY = Mathf.RoundToInt(RawMovementInput.y);       
        }

        if(context.canceled)
        {
            RawMovementInput = context.ReadValue<Vector2>();

            NormInputX = 0;
            NormInputY = 0;   
        }
       
        
    }

    public void StopMovement () {
        
            NormInputX = 0;
            NormInputY = 0;   
        
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started && !UIManager.IsPause)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started && !UIManager.IsPause)
        {
            GrabInput = true;
        }

        if (context.canceled && !UIManager.IsPause)
        {
            GrabInput = false;
        }
    }
     public void OnInventoryInput(InputAction.CallbackContext context)
    {
        if (context.started && !UIManager.inInventory)
        {
            InventoryInput = true;
            UIManager.instance.OpenInventory();
        }
        else if (context.started && UIManager.inInventory)
        {   
            InventoryInput = true;
            UIManager.instance.CloseInventory();
        }

        if (context.canceled && UIManager.inInventory)
        {
            InventoryInput = false;
        }
    }

    public void OnPauseMenuInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PauseMenuInput = true;
            if(UIManager.IsPause)
            {
                UIManager.instance.ResumeGame();
            }
            else{
                UIManager.instance.PauseGame();
            }

        }
        if (context.canceled)
        {
            PauseMenuInput = false;
        }
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.started && !UIManager.IsPause)
        {
            InteractInput = true;
           
            
        }
        if (context.canceled)
        {
            InteractInput = false;
        }
    }

    public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        } 
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started && !UIManager.IsPause)
        {
            DashInput = true;
            DashInputStop = false;
            dashInputStartTime = Time.time;
        }
        else if (context.canceled)
        {
            DashInputStop = true;
        }
    }

 
    public void UseJumpInput() => JumpInput = false;

    public void UseDashInput() => DashInput = false;
        /// <summary>
    /// Used to set the specific attack input back to false. Usually passed through the player attack state from an animation event.
    /// </summary>
    public void UseAttackInput(int i) => AttackInputs[i] = false;

    private void CheckJumpInputHoldTime()
    {
        if(Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    private void CheckDashInputHoldTime()
    {
        if(Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
    }

     public bool GetSubmitPressed() 
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }

    public void RegisterSubmitPressed() 
    {
        submitPressed = false;
    }

     public bool GetInteractPressed() 
    {
        bool result = InteractInput;
        InteractInput = false;
        return result;
    }

    public bool GetPauseMenuPressed()
    {
        bool result = PauseMenuInput;
        PauseMenuInput = false;
        return result;
    }



}

public enum CombatInputs
{
    primary,
    secondary
}