using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class M_SitState : CatSitState
{

     private MovingCat cat;
      private int rand;

    public M_SitState(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatSitState stateData, MovingCat cat) : base(catEntity, catStateMachine, catAnimBoolName, stateData)
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
        rand = Random.Range(1, 6);
    }

 
    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isSitTimeOver)
        {
            if(rand == 1)
            {
            stateMachine.ChangeState(cat.ItchState);
            }
            if(rand == 2)
            {
                stateMachine.ChangeState(cat.LickState);
            }
            if(rand == 3)
            {
                stateMachine.ChangeState(cat.Lick1State);
            }
            if(rand == 4 || rand == 5)
            {
                stateMachine.ChangeState(cat.MoveState);
            }
            
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}

