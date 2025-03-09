using System.Collections;
using System.Collections.Generic;
using Prodigy;
using UnityEngine;


public class Enemy3 : Entity
{
 //   public E3_IdleState idleState { get; private set; }
//    public E3_MoveState moveState { get; private set; }
//    public E3_PlayerDetectedState playerDetectedState { get; private set; }
//    public E3_ChargeState chargeState { get; private set; }
   public E3_LookForPlayerState lookForPlayerState { get; private set; }
    public E3_MeleeAttackState meleeAttackState { get; private set; }

//    public E3_JumpAttackState jumpAttackState { get; private set; }
    public E3_DeadState deadState { get; private set; }

//    [SerializeField]
//    private D_IdleState idleStateData;

    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;

        [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;

    [SerializeField]
    private D_DeadState deadStateData;


    [SerializeField]
    private Transform meleeAttackPosition;


    public override void Awake()
    {
        base.Awake();

       
        lookForPlayerState = new E3_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new E3_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        deadState = new E3_DeadState(this, stateMachine, "dead", deadStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(lookForPlayerState);        
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}