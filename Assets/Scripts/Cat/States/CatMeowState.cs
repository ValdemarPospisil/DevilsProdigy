using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prodigy.CoreSystem;


public class CatMeowState : CatState
{
    protected D_CatMeowState stateData;


    	protected bool isMeowTimeOver;
        protected float meowTime;


    public CatMeowState(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatMeowState stateData) : base(catEntity, catStateMachine, catAnimBoolName)
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
        isMeowTimeOver = false;
        SetRandomLickTime();
    }

   
    public override void Exit()
    {
        base.Exit();
    }

  

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + meowTime) {
			isMeowTimeOver = true;
		}
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SetRandomLickTime() {
		meowTime = Random.Range(stateData.minMeowTime, stateData.maxMeowTime);
	}



}

