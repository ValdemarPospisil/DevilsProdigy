using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class M_Lick1State : CatLickState
{

     private MovingCat cat;
    public M_Lick1State(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatLickState stateData, MovingCat cat) : base(catEntity, catStateMachine, catAnimBoolName, stateData)
    {
        this.cat = cat;
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

        if (isLickTimeOver)
        {
           
            stateMachine.ChangeState(cat.SitState);
        
           
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}

