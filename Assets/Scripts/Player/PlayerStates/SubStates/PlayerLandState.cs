using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, SoundManager soundManager, string animBoolName)
     : base(player, stateMachine, playerData, soundManager, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            if (xInput != 0 )
            {
            stateMachine.ChangeState(player.MoveState);
            }
            else if (isAnimationFinished)
            {
            stateMachine.ChangeState(player.IdleState);
            }

        }
    }

    public override void Enter()
    {
        base.Enter();

        soundManager.Play("Land");
        player.RB.sharedMaterial = playerData.fullFriction;
    }

    public override void Exit()
    {
        base.Exit();
        player.RB.sharedMaterial = playerData.noFriction;
    }

}
