using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prodigy.CoreSystem;

public class DashAttackState : AttackState {
	private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }

	private Movement movement;
	private Vector2 dashDirection;
	protected bool isAbilityDone = false;

	protected bool performCloseRangeAction;
	

	protected D_DashAttackState stateData;

	public DashAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_DashAttackState stateData) : base(etity, stateMachine, animBoolName, attackPosition) {
		this.stateData = stateData;
	}

	public override void DoChecks() {
		base.DoChecks();

		performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
	}

	public override void Enter() {
		base.Enter();
		dashDirection = Vector2.right * Movement.FacingDirection;
		isAbilityDone = false;

		
	}

	public override void Exit() {
		base.Exit();
		if (Movement?.CurrentVelocity.y > 0) {
			Movement?.SetVelocityY(Movement.CurrentVelocity.y * stateData.dashEndYMultiplier);
		}
	}

	public override void FinishAttack() {
		base.FinishAttack();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();
		entity.anim.SetFloat("yVelocity", Movement.CurrentVelocity.y);
		entity.anim.SetFloat("xVelocity", Mathf.Abs(Movement.CurrentVelocity.x));

		entity.RB.linearDamping = stateData.drag;
		Movement?.SetVelocity(stateData.dashSpeed, dashDirection);

		if (Time.time >= startTime + stateData.dashTime) {
					isAbilityDone = true;
					entity.RB.linearDamping = 0f;
				}
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}

}