using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ducking : Grounded
{

    public Ducking(Player player, MovementStateMachine stateMachine) : base(player, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        player.controls.ChangeCrouch();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!Input.isCrouching)
        {
            stateMachine.ChangeState(player.standing);
        }
    }
}
