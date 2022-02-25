using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public sealed class CameraController
{
    private readonly string _mouseAxisX = "Mouse X";

    private Transform _player;
    private Transform _mainCamera;

    private float _cameraMoveSpeed = 3.0f;
    private float _rotationSpeed = 1.5f;
    private float _rotationY = 0.0f;
    private Vector3 _offset;

    public CameraController(Transform player, Transform mainCamera)
    {
        _player = player;
        _mainCamera = mainCamera;

        _rotationY = _mainCamera.eulerAngles.y;
        _offset = _player.position - _mainCamera.position;
    }

    public void LateExecute()
    {
        CameraUpdater();
    }

    private void CameraUpdater()
    {
        _rotationY += CrossPlatformInputManager.GetAxis(_mouseAxisX) * _rotationSpeed * _cameraMoveSpeed;

        Quaternion rotation = Quaternion.Euler(0, _rotationY, 0);
        _mainCamera.position = _player.position - (rotation * _offset);
        _mainCamera.LookAt(_player);
    }
}
