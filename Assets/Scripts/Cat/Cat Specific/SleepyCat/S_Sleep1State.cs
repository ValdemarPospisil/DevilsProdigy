using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Sleep1State : CatSleepState
{
    private SleepyCat cat;
    private int rand;
    public S_Sleep1State(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatSleepState stateData, SleepyCat cat) : base(catEntity, catStateMachine, catAnimBoolName, stateData)
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

        if (isSleepTimeOver)
        {
            
            stateMachine.ChangeState(cat.IdleState);
        
            
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}