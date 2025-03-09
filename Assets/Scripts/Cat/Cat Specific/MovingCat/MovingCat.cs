using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCat : CatEntity
{
    public M_IdleState IdleState { get; private set; }
    public M_MoveState MoveState { get; private set; }
    public M_SitState SitState { get; private set; }
    public M_LickState LickState { get; private set; }
    public M_Lick1State Lick1State { get; private set; }
    public M_ItchState ItchState { get; private set; }


    [SerializeField]
    private D_CatIdleState idleStateData;
    [SerializeField]
    private D_CatMoveState moveStateData;
    [SerializeField]
    private D_CatSitState sitStateData;
    [SerializeField]
    private D_CatLickState lickStateData;
    [SerializeField]
    private D_CatItchState itchStateData;

 

    public override void Awake()
    {
        base.Awake();

        IdleState = new M_IdleState(this, stateMachine, "idle", idleStateData, this);
        MoveState = new M_MoveState(this, stateMachine, "move", moveStateData, this);
        SitState = new M_SitState(this, stateMachine, "sit", sitStateData, this);
        LickState = new M_LickState(this, stateMachine, "lick", lickStateData, this);
        Lick1State = new M_Lick1State(this, stateMachine, "lick1", lickStateData, this);
        ItchState = new M_ItchState(this, stateMachine, "itch", itchStateData, this);
       
    }

    private void Start()
    {
        stateMachine.Initialize(MoveState);        
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}