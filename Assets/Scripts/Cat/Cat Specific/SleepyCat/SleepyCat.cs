using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepyCat : CatEntity
{
    public S_IdleState IdleState { get; private set; }
    public S_MoveState MoveState { get; private set; }
    public S_SleepState SleepState { get; private set; }
    public S_Sleep1State Sleep1State { get; private set; }
    public S_MeowState MeowState { get; private set; }
   


    [SerializeField]
    private D_CatIdleState idleStateData;
    [SerializeField]
    private D_CatMoveState moveStateData;
    [SerializeField]
    private D_CatSleepState sleepStateData;
    [SerializeField]
    private D_CatMeowState meowStateData;

 

    public override void Awake()
    {
        base.Awake();

        IdleState = new S_IdleState(this, stateMachine, "idle", idleStateData, this);
        MoveState = new S_MoveState(this, stateMachine, "move", moveStateData, this);
        SleepState = new S_SleepState(this, stateMachine, "sleep", sleepStateData, this);
        Sleep1State = new S_Sleep1State(this, stateMachine, "sleep1", sleepStateData, this);
        MeowState = new S_MeowState(this, stateMachine, "meow", meowStateData, this);
       
    }

    private void Start()
    {
        stateMachine.Initialize(SleepState);        
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}