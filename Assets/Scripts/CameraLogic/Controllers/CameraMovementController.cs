using ManeraiTest.Input.Models;
using UnityEngine;
using VContainer.Unity;

namespace ManeraiTest.CameraLogic.Controllers
{
    public class CameraMovementController : IInitializable
    {
        private readonly Transform _cameraTransform;
        private readonly CameraMovementData _cameraMovementData;
        private readonly InputModel _inputModel;

        public CameraMovementController(Camera camera, CameraMovementData cameraMovementData, InputModel inputModel)
        {
            _cameraMovementData = cameraMovementData;
            _inputModel = inputModel;
            _cameraTransform = camera.transform;
        }

        public void Initialize()
        {
            _inputModel.Movement += MoveCamera;
        }

        private void MoveCamera(Vector2 movement)
        {
            var forward = _cameraTransform.forward;
            var right = _cameraTransform.right;

            forward.y = 0f;
            right.y = 0f;

            var targetDirection = (forward * movement.y + right * movement.x).normalized;

            var targetPosition = _cameraTransform.position +
                                 targetDirection * _cameraMovementData.MoveSpeed * Time.deltaTime;

            _cameraTransform.position = targetPosition;
        }
    }
}