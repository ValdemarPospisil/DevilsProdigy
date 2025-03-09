using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prodigy.CoreSystem;

public class DamageRunState : AttackState {
	private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
	private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

	private Movement movement;
	private CollisionSenses collisionSenses;
	private Player player;


	protected D_DamageRunState stateData;

	protected bool isDetectingLedge;
	protected bool isDetectingWall;
	protected bool isChargeTimeOver;
	protected bool performCloseRangeAction;

	public DamageRunState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_DamageRunState stateData) : base(etity, stateMachine, animBoolName, attackPosition ) {
		this.stateData = stateData;
	}

	public override void DoChecks() {
		base.DoChecks();

		isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
		isDetectingLedge = CollisionSenses.LedgeVertical;
		isDetectingWall = CollisionSenses.WallFront;

		performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
	}

	public override void Enter() {
		base.Enter();

		isChargeTimeOver = false;
		Movement?.SetVelocityX(stateData.chargeSpeed * Movement.FacingDirection);
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		Movement?.SetVelocityX(stateData.chargeSpeed * Movement.FacingDirection);

		if (Time.time >= startTime + stateData.chargeTime) {
			isChargeTimeOver = true;
		}

		
		
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();


		Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

		
		foreach (Collider2D collider in detectedObjects) {
				IKnockBackable knockbackable = collider.GetComponent<IKnockBackable>();

				if (knockbackable != null) {
					knockbackable.KnockBack(stateData.knockbackAngle, stateData.knockbackStrength, Movement.FacingDirection);
				}

				IDamageable damageable = collider.GetComponent<IDamageable>();

				if (damageable != null) {
					damageable.Damage(stateData.attackDamage);
				}

				
			}
		

		
	}
}