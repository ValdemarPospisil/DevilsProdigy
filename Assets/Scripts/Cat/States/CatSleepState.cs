using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prodigy.CoreSystem;


public class CatSleepState : CatState
{
    protected D_CatSleepState stateData;


    	protected bool isSleepTimeOver;
        protected float sleepTime;


    public CatSleepState(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatSleepState stateData) : base(catEntity, catStateMachine, catAnimBoolName)
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
        isSleepTimeOver = false;
        SetRandomLickTime();
    }

   
    public override void Exit()
    {
        base.Exit();
    }

  

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + sleepTime) {
			isSleepTimeOver = true;
		}
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SetRandomLickTime() {
		sleepTime = Random.Range(stateData.minSleepTime, stateData.maxSleepTime);
	}



}

