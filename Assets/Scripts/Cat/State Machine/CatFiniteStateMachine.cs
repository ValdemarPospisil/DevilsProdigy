using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFiniteStateMachine
{
    public CatState currentState { get; private set; }

    public void Initialize(CatState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(CatState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}