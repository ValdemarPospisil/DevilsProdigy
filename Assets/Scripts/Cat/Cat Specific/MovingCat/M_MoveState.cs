using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_MoveState : CatMoveState
{
    private MovingCat cat;

    public M_MoveState(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatMoveState catStateData, MovingCat cat) : base(catEntity, catStateMachine, catAnimBoolName, catStateData)
    {
        this.cat = cat;
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

    if(isDetectingWall || !isDetectingLedge)
        {
            cat.IdleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(cat.IdleState);
        }

        if(isMoveTimeOver)
        {
            stateMachine.ChangeState(cat.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}