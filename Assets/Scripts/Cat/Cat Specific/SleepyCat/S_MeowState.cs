using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MeowState : CatMeowState
{
    private SleepyCat cat;
    private int rand;
    public S_MeowState(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatMeowState catStateData, SleepyCat cat) : base(catEntity, catStateMachine, catAnimBoolName, catStateData)
    {
        this.cat = cat;
    }

    public override void Enter()
    {
        base.Enter();
        SoundManager.instance.Play("Meow");
    }

    public override void Exit()
    {
        base.Exit();
        SoundManager.instance.Stop("Meow");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isMeowTimeOver)
        {
            
            stateMachine.ChangeState(cat.MoveState);
            
            
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}