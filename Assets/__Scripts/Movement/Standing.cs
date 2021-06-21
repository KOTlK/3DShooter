using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standing : Grounded
{
    public Standing(Player player, MovementStateMachine stateMachine) : base(player, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Input.isCrouching = false;
        Input.isJumping = false;
        player.controls.ChangeCrouch();
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
        } else if (Input.isRunning)
        {
            stateMachine.ChangeState(player.running);
        }
    }
}
