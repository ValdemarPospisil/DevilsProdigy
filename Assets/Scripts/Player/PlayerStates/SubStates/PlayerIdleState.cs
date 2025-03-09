using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, SoundManager soundManager, string animBoolName)
     : base(player, stateMachine, playerData, soundManager, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        Movement?.SetVelocityX(0f);
        player.RB.sharedMaterial = playerData.fullFriction;
        
    }

  
    public override void Exit()
    {
        base.Exit();
        player.RB.sharedMaterial = playerData.noFriction;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(xInput != 0 && !isExitingState)
        {
            stateMachine.ChangeState(player.MoveState);
            
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
