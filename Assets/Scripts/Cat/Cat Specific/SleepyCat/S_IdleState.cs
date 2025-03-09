using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_IdleState : CatIdleState
{
    private SleepyCat cat;
    private int rand;
    public S_IdleState(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatIdleState catStateData, SleepyCat cat) : base(catEntity, catStateMachine, catAnimBoolName, catStateData)
    {
        this.cat = cat;
    }

    public override void Enter()
    {
        base.Enter();
        rand = Random.Range(1, 5);
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
            if(rand == 1)
            {
                stateMachine.ChangeState(cat.MoveState);
            }
            if(rand == 2)
            {
                stateMachine.ChangeState(cat.MeowState);
            }
            if(rand == 3)
            {
                stateMachine.ChangeState(cat.SleepState);
            }
            if(rand == 4)
            {
                stateMachine.ChangeState(cat.Sleep1State);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}