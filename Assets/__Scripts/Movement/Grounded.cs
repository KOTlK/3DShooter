using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : State
{

    public Grounded(Player player, MovementStateMachine stateMachine) : base(player, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

        
        
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

    
}
