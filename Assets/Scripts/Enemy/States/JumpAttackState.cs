using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prodigy.CoreSystem;


public class JumpAttackState : AttackState {
	private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
	private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

	private Movement movement;
	private CollisionSenses collisionSenses;
	private Enemy3 enemy;

	protected D_JumpAttackState stateData;

	protected bool performCloseRangeAction;
	protected bool isPlayerInMaxAgroRange;
	protected bool isGrounded;
	protected bool isJumpAttackOver;

    public JumpAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_JumpAttackState stateData) : base(etity, stateMachine, animBoolName, attackPosition)
    {
		this.stateData = stateData;
    }

    public override void DoChecks() {
		base.DoChecks();

		performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
		isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
		isGrounded = CollisionSenses.Ground;
	}

	public override void Enter() {
		base.Enter();

		isJumpAttackOver = false;

			Movement?.SetVelocity(stateData.JumpAttackSpeed, stateData.JumpAttackAngle, -Movement.FacingDirection);
	}
		public override void TriggerAttack() {
		base.TriggerAttack();

		Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

		foreach (Collider2D collider in detectedObjects) {
			IDamageable damageable = collider.GetComponent<IDamageable>();

			if (damageable != null) {
				damageable.Damage(stateData.attackDamage);
			}

			IKnockBackable knockbackable = collider.GetComponent<IKnockBackable>();

			if (knockbackable != null) {
				knockbackable.KnockBack(stateData.knockbackAngle, stateData.knockbackStrength, Movement.FacingDirection);
			}
		}
	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		if (Time.time >= startTime + stateData.JumpAttackTime && isGrounded) {
			isJumpAttackOver = true;
		}
	}

}
