using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour
{
    public static PlayerInput input;
    public static Vector2 moveDirection;
    public static Vector2 rotateDirection;
    public static bool isCrouching;
    public static bool isJumping = false;
    public static bool isRunning;

    private void Awake()
    {
        input = new PlayerInput();

        input.Player.Crouch.performed += context => ChangeCrouch();
        input.Player.Jump.performed += context => Player.S.controls.Jump();
        input.Player.Sprint.performed += context => ChangeRunning();
        input.Player.Fire.performed += context => Player.S.controls.Shoot();
    }

    private void Update()
    {
        moveDirection = input.Player.Move.ReadValue<Vector2>();
        rotateDirection = input.Player.Rotate.ReadValue<Vector2>();
    }


    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void ChangeCrouch()
    {
        isCrouching = !isCrouching;
    }
    
    private void ChangeRunning()
    {
        isRunning = !isRunning;
    }

}
