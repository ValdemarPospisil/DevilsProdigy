using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
    
    public H_PlayerDetectedState playerDetectedState { get; private set; }
    public H_ChargeState chargeState { get; private set; }
    public H_LookForPlayerState lookForPlayerState { get; private set; }
    public H_Attack1State attack1State { get; private set; }
    public H_Attack2State attack2State { get; private set; }
    public H_DashAttackState dashAttackState { get; private set; }
    public H_CastState castState { get; private set; }
    public H_MoveState moveState { get; private set; }
    public H_IdleState idleState { get; private set; }
    
    
    


    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_UltimateAttackState ultimateAttackstateData;
    [SerializeField]
    private D_DashAttackState dashAttackStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
   
 
    [SerializeField]
        private Transform meleeAttackPosition;
        [SerializeField]
        private Transform dashRunPosition;
        [SerializeField]
        private Transform ultimateAttackPosition;
    public override void Awake()
    {
        base.Awake();

        
        playerDetectedState = new H_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new H_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new H_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        attack1State = new H_Attack1State(this, stateMachine, "attack1", meleeAttackPosition, meleeAttackStateData, this);
        attack2State = new H_Attack2State(this, stateMachine, "attack2", meleeAttackPosition, meleeAttackStateData, this);
        castState = new H_CastState(this, stateMachine, "cast", ultimateAttackPosition, ultimateAttackstateData, this);
        dashAttackState = new H_DashAttackState(this, stateMachine, "dash", dashRunPosition, dashAttackStateData, this);
        idleState = new H_IdleState(this, stateMachine, "idle", idleStateData, this );
        moveState = new H_MoveState(this, stateMachine, "move", moveStateData, this);
        
       
    }

    private void Start()
    {
        stateMachine.Initialize(moveState);        
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
         Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}