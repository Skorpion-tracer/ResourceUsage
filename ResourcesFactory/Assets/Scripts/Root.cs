using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private PlayerModel _playerModel;
    [SerializeField] private PlayerView _playerView;

    private CameraController _cameraController;
    private PlayerController _playerController;

    private void Awake()
    {
        _cameraController = new CameraController(_playerView.transform, Camera.main.transform);
        _playerController = new PlayerController(_playerModel, _playerView);
    }

    private void Update()
    {
        _playerController.Execute();
    }

    private void FixedUpdate()
    {
        _playerController.FixedExecute();
    }

    private void LateUpdate()
    {
        _cameraController.LateExecute();
    }
}
