using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des_Attack3State : UltimateAttackState
{
    private Destroyer boss;
    public Des_Attack3State(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_UltimateAttackState stateData, Destroyer boss) : base(etity, stateMachine, animBoolName, attackPosition, stateData)
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

        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
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
        SoundManager.instance.Play("SpecialMove");
    }
}