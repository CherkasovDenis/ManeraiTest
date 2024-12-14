using System;
using UnityEngine;

namespace ManeraiTest.Input.Models
{
    public class InputModel
    {
        public event Action<Vector2> AimDeltaChanged;
        public event Action ActionButtonPressed;
        public event Action ActionButtonReleased;
        public event Action<Vector2> Movement;

        public InputActions InputActions { get; private set; }

        public void SetInputActions(InputActions inputActions)
        {
            InputActions = inputActions;
        }

        public void OnAimDeltaChanged(Vector2 value)
        {
            AimDeltaChanged?.Invoke(value);
        }

        public void OnActionButtonPressed()
        {
            ActionButtonPressed?.Invoke();
        }

        public void OnActionButtonReleased()
        {
            ActionButtonReleased?.Invoke();
        }

        public void OnMovement(Vector2 value)
        {
            Movement?.Invoke(value);
        }
    }
}