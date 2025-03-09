using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des_DamageRunState : DamageRunState
{
    private Destroyer boss;

    public Des_DamageRunState(Entity etity, FiniteStateMachine stateMachine, string animBoolName,  Transform attackPosition, D_DamageRunState stateData, Destroyer boss) : base(etity, stateMachine, animBoolName,attackPosition, stateData)
    {
        this.boss = boss;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

       
        if (!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(boss.lookForPlayerState);
        }
      
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}