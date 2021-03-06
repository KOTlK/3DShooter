using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    protected Player player;
    protected MovementStateMachine stateMachine;

    protected State(Player player, MovementStateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter()
    {
    }

    public virtual void HandleInput()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
