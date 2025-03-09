using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PlayerDetectedState : PlayerDetectedState {
	private Enemy1 enemy;
	private int rand;

	public E1_PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy1 enemy) : base(etity, stateMachine, animBoolName, stateData) {
		this.enemy = enemy;
	}

	public override void Enter() {
		base.Enter();

		rand = Random.Range(1, 3);
	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		if (performCloseRangeAction) {

			 if(rand == 1)
            {
				stateMachine.ChangeState(enemy.meleeAttackState);
            }
            if(rand == 2)
            {
				stateMachine.ChangeState(enemy.meleeAttackState2);
            }

		} else if (performLongRangeAction) {
			stateMachine.ChangeState(enemy.chargeState);
		} else if (!isPlayerInMaxAgroRange) {
			stateMachine.ChangeState(enemy.lookForPlayerState);
		} else if (!isDetectingLedge) {
			Movement?.Flip();
			stateMachine.ChangeState(enemy.moveState);
		}

	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}
}