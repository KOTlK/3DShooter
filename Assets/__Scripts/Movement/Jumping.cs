using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : State
{
    public Jumping(Player player, MovementStateMachine stateMachine) : base(player, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        player.controls.Jump();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        player.controls.RotateCamera(Input.rotateDirection);
        player.controls.RotatePlayer(Input.rotateDirection);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.controls.MovePlayer(Input.moveDirection);

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!Input.isJumping)
        {
            stateMachine.ChangeState(player.standing);
        }
    }

    
}
