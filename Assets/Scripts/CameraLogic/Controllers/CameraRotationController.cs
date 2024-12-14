using ManeraiTest.Input.Models;
using UnityEngine;
using VContainer.Unity;

namespace ManeraiTest.CameraLogic.Controllers
{
    public class CameraRotationController : IInitializable
    {
        private readonly Transform _cameraTransform;
        private readonly CameraMovementData _cameraMovementData;
        private readonly InputModel _inputModel;

        private float _vertical;
        private float _horizontal;

        public CameraRotationController(Camera camera, CameraMovementData cameraMovementData, InputModel inputModel)
        {
            _cameraTransform = camera.transform;
            _cameraMovementData = cameraMovementData;
            _inputModel = inputModel;
        }

        public void Initialize()
        {
            _inputModel.AimDeltaChanged += UpdateCameraRotation;
        }

        private void UpdateCameraRotation(Vector2 mouseDelta)
        {
            var dt = Time.deltaTime;

            _horizontal += _cameraMovementData.Sensitivity * mouseDelta.x * dt;

            _vertical -= _cameraMovementData.Sensitivity * mouseDelta.y * dt;

            _vertical = Mathf.Clamp(_vertical,
                _cameraMovementData.MinVerticalAngle, _cameraMovementData.MaxVerticalAngle);

            _cameraTransform.rotation = Quaternion.Euler(_vertical, _horizontal, 0f);
        }
    }
}