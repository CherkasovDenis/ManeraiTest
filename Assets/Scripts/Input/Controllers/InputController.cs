using ManeraiTest.Input.Models;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace ManeraiTest.Input.Controllers
{
    public class InputController : IInitializable, ITickable
    {
        private readonly InputModel _inputModel;

        private InputAction _movementAction;

        public InputController(InputModel inputModel)
        {
            _inputModel = inputModel;
        }

        public void Initialize()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _inputModel.SetInputActions(new InputActions());

            var map = _inputModel.InputActions.KeyboardAndMouse;
            map.Enable();

            map.AimDelta.performed += AimDeltaPerformed;
            map.ActionButton.started += ActionButtonPressed;
            map.ActionButton.canceled += ActionButtonReleased;

            _movementAction = map.Movement;
        }

        public void Tick()
        {
            _inputModel.OnMovement(_movementAction.ReadValue<Vector2>());
        }

        private void AimDeltaPerformed(InputAction.CallbackContext callbackContext)
        {
            var delta = callbackContext.ReadValue<Vector2>();

            _inputModel.OnAimDeltaChanged(delta);
        }

        private void ActionButtonPressed(InputAction.CallbackContext callbackContext)
        {
            _inputModel.OnActionButtonPressed();
        }

        private void ActionButtonReleased(InputAction.CallbackContext callbackContext)
        {
            _inputModel.OnActionButtonReleased();
        }
    }
}