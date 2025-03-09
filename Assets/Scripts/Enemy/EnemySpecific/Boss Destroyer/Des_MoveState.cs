using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des_MoveState : MoveState
{
    private Destroyer boss;

    public Des_MoveState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Destroyer boss) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.boss = boss;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(boss.playerDetectedState);
        }
        else if(isDetectingWall || !isDetectingLedge)
        {
            boss.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(boss.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}