using System;
using UnityEngine;

namespace ManeraiTest.CameraLogic
{
    [Serializable]
    public class CameraMovementData
    {
        public float MoveSpeed => _moveSpeed;

        public float Sensitivity => _sensitivity;

        public float MinVerticalAngle => _minVerticalAngle;

        public float MaxVerticalAngle => _maxVerticalAngle;

        [SerializeField]
        private float _moveSpeed;
        
        [SerializeField]
        private float _sensitivity;

        [SerializeField]
        private float _minVerticalAngle;

        [SerializeField]
        private float _maxVerticalAngle;
    }
}