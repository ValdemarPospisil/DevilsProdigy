using System.Collections;
using System.Collections.Generic;
using Prodigy.CoreSystem;
using UnityEngine;

public class CatState
{
    protected CatFiniteStateMachine stateMachine;
    protected CatEntity entity;
    protected Core core;    

    public float startTime { get; protected set; }

    protected string animBoolName;

    public CatState(CatEntity catEntity, CatFiniteStateMachine catStateMachine, string catAnimBoolName)
    {
        this.entity = catEntity;
        this.stateMachine = catStateMachine;
        this.animBoolName = catAnimBoolName;
        core = entity.Core;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
        DoChecks();
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
}