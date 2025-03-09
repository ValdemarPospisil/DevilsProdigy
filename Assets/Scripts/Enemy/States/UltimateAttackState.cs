using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prodigy.CoreSystem;

public class UltimateAttackState : AttackState
{
    protected D_UltimateAttackState stateData;

    protected GameObject projectile;
    protected ProjectileOld projectileScript;
    protected Vector3 offset;
    protected int offsetInt;
    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }

	private Movement movement;

    public UltimateAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_UltimateAttackState stateData) : base(etity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        offset = new Vector3(0, 0, 0);
        offsetInt = 0;

        for(int i = 0; i < stateData.projectile.Length; i++) {
            projectile = GameObject.Instantiate(stateData.projectile[i], attackPosition.position + offset * Movement.FacingDirection, attackPosition.rotation);
            projectileScript = projectile.GetComponent<ProjectileOld>();
            projectileScript.FireProjectile(stateData.projectileSpeed, stateData.projectileTravelDistance, stateData.projectileDamage);
            offsetInt++;
            offset = new Vector3(offsetInt, 0, 0);
        }
    }
}