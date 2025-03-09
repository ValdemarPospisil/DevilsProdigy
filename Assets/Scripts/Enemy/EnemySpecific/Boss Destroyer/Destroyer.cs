using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : Entity
{
    
    public Des_PlayerDetectedState playerDetectedState { get; private set; }
    public Des_ChargeState chargeState { get; private set; }
    public Des_LookForPlayerState lookForPlayerState { get; private set; }
    public Des_Attack1State attack1State { get; private set; }
    public Des_Attack2State attack2State { get; private set; }
    public Des_Attack3State attack3State { get; private set; }
    public Des_DamageRunState damageRunState { get; private set; }
    public Des_MoveState moveState { get; private set; }
    public Des_IdleState idleState { get; private set; }

    
    
    


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
    private D_DamageRunState damageRunStateData;
    [SerializeField]
    private D_MoveState moveStateData;

    [SerializeField]
    private D_IdleState idleStateData;
   
 
    [SerializeField]
        private Transform meleeAttackPosition;
        [SerializeField]
        private Transform damageRunPosition;
        [SerializeField]
        private Transform ultimateAttackPosition;
    public override void Awake()
    {
        base.Awake();

        
        playerDetectedState = new Des_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new Des_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new Des_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        attack1State = new Des_Attack1State(this, stateMachine, "attack1", meleeAttackPosition, meleeAttackStateData, this);
        attack2State = new Des_Attack2State(this, stateMachine, "attack2", meleeAttackPosition, meleeAttackStateData, this);
        attack3State = new Des_Attack3State(this, stateMachine, "attack3", ultimateAttackPosition, ultimateAttackstateData, this);
        damageRunState = new Des_DamageRunState(this, stateMachine, "damageRun", damageRunPosition, damageRunStateData, this);
        moveState = new Des_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Des_IdleState(this, stateMachine, "idle", idleStateData, this);
        
       
    }

    private void Start()
    {
        stateMachine.Initialize(moveState);        
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
         Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
         Gizmos.DrawWireSphere(damageRunPosition.position, damageRunStateData.attackRadius);
    }
}