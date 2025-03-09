using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des_PlayerDetectedState : PlayerDetectedState {
	private Destroyer boss;
	private int rand;

	public Des_PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Destroyer boss) : base(etity, stateMachine, animBoolName, stateData) {
		this.boss = boss;
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
				stateMachine.ChangeState(boss.attack1State);
            }
            if(rand == 2)
            {
				stateMachine.ChangeState(boss.attack2State);
            }
		}
		else if(isPlayerInDashAgroRange)
		{
			if(rand == 1)
            {
				stateMachine.ChangeState(boss.chargeState);
            }
            if(rand == 2)
            {
				stateMachine.ChangeState(boss.attack3State);
            }
		}
		else if (isPlayerInMinAgroRange)
		{
			if(rand == 1)
            {
				stateMachine.ChangeState(boss.chargeState);
            }
            if(rand == 2)
            {
				stateMachine.ChangeState(boss.damageRunState);
            }
		}
		else if (isPlayerInMaxAgroRange && !isPlayerInDashAgroRange)
		{
			stateMachine.ChangeState(boss.damageRunState);
		}
		else if (!isPlayerInMaxAgroRange) 
		{
			stateMachine.ChangeState(boss.lookForPlayerState);
		}

	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}
}