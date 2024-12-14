using ManeraiTest.Drag.Models;
using ManeraiTest.Input.Models;
using UnityEngine;
using VContainer.Unity;

namespace ManeraiTest.Drag.Controllers
{
    public class DragController : IInitializable, IFixedTickable
    {
        private readonly Transform _cameraTransform;
        private readonly DragModel _dragModel;
        private readonly InputModel _inputModel;

        private bool _hasDraggable;

        public DragController(Camera camera, DragModel dragModel, InputModel inputModel)
        {
            _cameraTransform = camera.transform;
            _dragModel = dragModel;
            _inputModel = inputModel;
        }

        public void Initialize()
        {
            _dragModel.UpdatedCurrentDraggable += StartDrag;
            _inputModel.ActionButtonReleased += StopDrag;
        }

        private void StartDrag()
        {
            _hasDraggable = true;

            _dragModel.Draggable.PrepareForDrag();
        }

        private void StopDrag()
        {
            if (!_hasDraggable)
            {
                return;
            }

            _hasDraggable = false;

            _dragModel.Draggable?.RestoreDragChanges();

            _dragModel.ResetDraggableInfo();
        }

        public void FixedTick()
        {
            if (!_hasDraggable)
            {
                return;
            }

            var targetPosition = _cameraTransform.position + _cameraTransform.forward * _dragModel.GrabDistance;

            var draggable = _dragModel.Draggable;

            var newPosition = Vector3.Lerp(draggable.Position, targetPosition, Time.fixedDeltaTime * 5f);

            draggable.MovePosition(newPosition);
        }
    }
}