using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_DashAttackState : DashAttackState
{
    private Hero boss;
    public H_DashAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_DashAttackState stateData, Hero boss) : base(etity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.boss = boss;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAbilityDone)
        {   
            if(performCloseRangeAction)
            {
                stateMachine.ChangeState(boss.attack1State);
            }
            else if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(boss.playerDetectedState);
            }else if (!isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(boss.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}