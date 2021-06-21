using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : Grounded
{
    public Running(Player player, MovementStateMachine stateMachine) : base(player, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        player.controls.ChangeRunning();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Input.isCrouching)
        {
            stateMachine.ChangeState(player.ducking);
        } else if (Input.isJumping)
        {
            stateMachine.ChangeState(player.jumping);
        } else if (!Input.isRunning)
        {
            stateMachine.ChangeState(player.standing);
        }

    }
}
