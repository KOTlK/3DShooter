using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl
{
    public float sensitivity = 10f;

    private Player _player;
    private static float _yLookAngle;
    private static float _xLookAngle;
    private readonly float _crouchSpeed = 5f;
    private readonly float _defaultSpeed = 10f;
    private readonly float _runningSpeed = 13f;
    private float _speed = 10f;
    private float _bulletStartForce = 10f;
    private float _maxVerticalAngle = 89f;
    
    
    

    public PlayerControl(Player player)
    {
        _player = player;
        
    }


    public void Jump()
    {
        if (!Input.isJumping)
        {
            _player.playerRB.AddForce(0, 370, 0, ForceMode.Impulse);
        }
        
    }

    public void MovePlayer(Vector2 direction)
    {
        float multSpeed = _speed * Time.deltaTime;
        _player.transform.position += _player.transform.forward * direction.y * multSpeed;
        _player.transform.position += _player.transform.right * direction.x * multSpeed;
    }

    public void RotateCamera(Vector2 direction)
    {
        _yLookAngle += sensitivity * -direction.y * Time.deltaTime;
        _yLookAngle = Mathf.Clamp(_yLookAngle, -_maxVerticalAngle, _maxVerticalAngle);
        Camera.main.transform.localRotation = Quaternion.Euler(_yLookAngle, 0, 0);

    }

    public void RotatePlayer(Vector2 direction)
    {
        _xLookAngle += sensitivity * direction.x * Time.deltaTime;
        _player.transform.rotation = Quaternion.Euler(0, _xLookAngle, 0);
    }
    
    public void Shoot()
    {
        var projectile = MonoBehaviour.Instantiate<GameObject>(Player.S.projectile, Player.S.projectileHolder);
        projectile.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
        projectile.transform.rotation = Camera.main.transform.rotation;
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * _bulletStartForce, ForceMode.Impulse);
    }

    public void ChangeCrouch()
    {
        _speed = Input.isCrouching ? _crouchSpeed : _defaultSpeed;
    }

    public void ChangeRunning()
    {
        _speed = Input.isRunning ? _runningSpeed : _defaultSpeed;
    }
}
