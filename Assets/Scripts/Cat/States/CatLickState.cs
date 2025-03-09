using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prodigy.CoreSystem;


public class CatLickState : CatState
{
    protected D_CatLickState stateData;


    	protected bool isLickTimeOver;
        protected float lickTime;


    public CatLickState(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatLickState stateData) : base(catEntity, catStateMachine, catAnimBoolName)
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
        isLickTimeOver = false;
        SetRandomLickTime();
    }

   
    public override void Exit()
    {
        base.Exit();
    }

  

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + lickTime) {
			isLickTimeOver = true;
		}
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SetRandomLickTime() {
		lickTime = Random.Range(stateData.minlickTime, stateData.maxlickTime);
	}



}

