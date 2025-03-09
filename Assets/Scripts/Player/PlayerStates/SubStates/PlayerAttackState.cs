using System.Collections;
using System.Collections.Generic;
using Prodigy.Weapons;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapon weapon;
    
    private int inputIndex;

    public PlayerAttackState(
        Player player,
        PlayerStateMachine stateMachine,
        PlayerData playerData,
         SoundManager soundManager,
        string animBoolName,
        Weapon weapon,
        
        CombatInputs input
        
    ) : base(player, stateMachine, playerData,soundManager, animBoolName)
    {
        this.weapon = weapon;
        inputIndex = (int)input;

        weapon.OnExit += ExitHandler;
    }

    public override void Enter()
    {
        base.Enter();
        
        weapon.Enter();
      //  soundManager.Play("Attack");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        weapon.CurrentInput = player.InputHandler.AttackInputs[inputIndex];
    }


    private void ExitHandler()
    {
        AnimationFinishTriger();
        isAbilityDone = true;
    }
}