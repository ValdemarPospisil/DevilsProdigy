using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_IdleState : CatIdleState
{
    private MovingCat cat;
    private int rand;
    public M_IdleState(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatIdleState catStateData, MovingCat cat) : base(catEntity, catStateMachine, catAnimBoolName, catStateData)
    {
        this.cat = cat;
    }

    public override void Enter()
    {
        base.Enter();
        rand = Random.Range(1, 3);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isIdleTimeOver)
        {
            if(rand == 1 )
            {
            stateMachine.ChangeState(cat.MoveState);
            }
            if(rand == 2)
            {
                stateMachine.ChangeState(cat.SitState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}