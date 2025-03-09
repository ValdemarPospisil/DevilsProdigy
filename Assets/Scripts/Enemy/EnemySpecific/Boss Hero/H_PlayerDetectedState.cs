using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_PlayerDetectedState : PlayerDetectedState {
	private Hero boss;
	private int rand;
	private int rand1;

	public H_PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Hero boss) : base(etity, stateMachine, animBoolName, stateData) {
		this.boss = boss;
	}

	public override void Enter() {
		base.Enter();

		rand = Random.Range(1, 3);
		rand1 = Random.Range(1, 4);
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
					stateMachine.ChangeState(boss.dashAttackState);
				}
				if(rand == 2)
				{
					stateMachine.ChangeState(boss.chargeState);
				}
			} 
			else if (isPlayerInMinAgroRange) 
			{
				stateMachine.ChangeState(boss.chargeState);
			}
			else if (isPlayerInMaxAgroRange)
			{
				if(rand1 == 1)
				{
					stateMachine.ChangeState(boss.castState);
				}
				if(rand1 == 2)
				{
					stateMachine.ChangeState(boss.chargeState);
				}
				if(rand1 == 3)
				{
					stateMachine.ChangeState(boss.castState);
				}
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