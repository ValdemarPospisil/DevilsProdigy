using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prodigy.CoreSystem;


public class CatItchState : CatState
{
    protected D_CatItchState stateData;


    	protected bool isItchTimeOver;
        protected float itchTime;


    public CatItchState(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatItchState stateData) : base(catEntity, catStateMachine, catAnimBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        isItchTimeOver = false;
        SetRandomSitTime();
    }

   
    public override void Exit()
    {
        base.Exit();
    }

  

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + itchTime) {
			isItchTimeOver = true;
		}
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SetRandomSitTime() {
		itchTime = Random.Range(stateData.minItchTime, stateData.maxItchTime);
	}



}

