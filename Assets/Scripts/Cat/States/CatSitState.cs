using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prodigy.CoreSystem;


public class CatSitState : CatState
{
    protected D_CatSitState stateData;


    	protected bool isSitTimeOver;
        protected float sitTime;


    public CatSitState(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatSitState stateData) : base(catEntity, catStateMachine, catAnimBoolName)
    {
        this.stateData =stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        isSitTimeOver = false;
        SetRandomSitTime();
    }

   
    public override void Exit()
    {
        base.Exit();
    }

  

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + sitTime) {
			isSitTimeOver = true;
		}
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SetRandomSitTime() {
		sitTime = Random.Range(stateData.minSitTime, stateData.maxSitTime);
	}



}

