using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController
{
    private readonly string HORIZONTAL = "Horizontal";
    private readonly string VERTICAL = "Vertical";
    private readonly string MOUSEX = "Mouse X";

    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private Camera _camera;

    private Vector3 _direction;

    public PlayerController(PlayerModel playerModel, PlayerView playerView)
    {
        _playerModel = playerModel;
        _playerView = playerView;

        _camera = Camera.main;
        _direction = new Vector3();
    }

    public void FixedExecute()
    {
        float horizontalInput = CrossPlatformInputManager.GetAxis(HORIZONTAL);
        float verticalInput = CrossPlatformInputManager.GetAxis(VERTICAL);

        Vector3 forward = _camera.transform.forward;
        Vector3 right = _camera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * verticalInput + right * horizontalInput;

        _playerView.RigidBody.velocity = new Vector3(moveDirection.x * _playerModel.Speed, 
                                                     _playerView.RigidBody.velocity.y,
                                                     moveDirection.z * _playerModel.Speed);

    }

    public void Execute()
    {
        Rotation();
    }

    private void Rotation()
    {
        Vector3 movement = Vector3.zero;
        movement = _camera.transform.TransformDirection(movement);

        Quaternion direction = Quaternion.LookRotation(movement);
        _playerView.RigidBody.rotation = Quaternion.Lerp(_playerView.transform.rotation, direction,
            _playerModel.Speed * Time.deltaTime);

    }
}
