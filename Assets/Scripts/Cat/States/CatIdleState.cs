using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prodigy.CoreSystem;


    public class CatIdleState : CatState
    {
        private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
	private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

	private Movement movement;
	private CollisionSenses collisionSenses;

	protected D_CatIdleState stateData;

	protected bool flipAfterIdle;
	protected bool isIdleTimeOver;
	

	protected float idleTime;

	public CatIdleState(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatIdleState stateData) : base(catEntity, catStateMachine, catAnimBoolName) {
		this.stateData = stateData;
	}

	public override void DoChecks() {
		base.DoChecks();
		
	
	}

	public override void Enter() {
		base.Enter();

		Movement?.SetVelocityX(0f);
		isIdleTimeOver = false;
		SetRandomIdleTime();
	}

	public override void Exit() {
		base.Exit();

		if (flipAfterIdle) {
			Movement?.Flip();
		}
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		Movement?.SetVelocityX(0f);

		if (Time.time >= startTime + idleTime) {
			isIdleTimeOver = true;
		}
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}

	public void SetFlipAfterIdle(bool flip) {
		flipAfterIdle = flip;
	}

	private void SetRandomIdleTime() {
		idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
	}

}

