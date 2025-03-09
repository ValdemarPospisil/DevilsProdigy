using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prodigy.CoreSystem;

public class CatMoveState : CatState {
	private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
	private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

	private Movement movement;
	private CollisionSenses collisionSenses;

	protected D_CatMoveState stateData;

	protected bool isDetectingWall;
	protected bool isDetectingLedge;
	protected bool isPlayerInMinAgroRange;

		protected bool isMoveTimeOver;
        protected float moveTime;

	public CatMoveState(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName, D_CatMoveState stateData) : base(catEntity, catStateMachine, catAnimBoolName) {
		this.stateData = stateData;
	}

	public override void DoChecks() {
		base.DoChecks();

		isDetectingLedge = CollisionSenses.LedgeVertical;
		isDetectingWall = CollisionSenses.WallFront;
		isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
	}

	public override void Enter() {
		base.Enter();
		Movement?.SetVelocityX(stateData.movementSpeed * Movement.FacingDirection);
		isMoveTimeOver = false;
        SetRandomSitTime();

	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();
		Movement?.SetVelocityX(stateData.movementSpeed * Movement.FacingDirection);
		  if (Time.time >= startTime + moveTime) {
			isMoveTimeOver = true;
		}
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}

	private void SetRandomSitTime() {
		moveTime = Random.Range(stateData.minMoveTime, stateData.maxMoveTime);
	}

}