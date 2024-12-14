using System.Collections.Generic;
using ManeraiTest.Backpack.Models;
using ManeraiTest.Drag;
using ManeraiTest.Drag.Models;
using ManeraiTest.Input.Models;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VContainer.Unity;

namespace ManeraiTest.Aim.Controllers
{
    public class AimController : IInitializable
    {
        private readonly Transform _cameraTransform;
        private readonly InputModel _inputModel;
        private readonly DragModel _dragModel;
        private readonly BackpackModel _backpackModel;
        private readonly GraphicRaycaster _backpackUiRaycaster;

        public AimController(Camera camera, InputModel inputModel, DragModel dragModel, BackpackModel backpackModel,
            GraphicRaycaster backpackUiRaycaster)
        {
            _cameraTransform = camera.transform;
            _inputModel = inputModel;
            _dragModel = dragModel;
            _backpackModel = backpackModel;
            _backpackUiRaycaster = backpackUiRaycaster;
        }

        public void Initialize()
        {
            _inputModel.ActionButtonPressed += CheckAim;
            _backpackModel.DeselectedBackpack += CheckUiAim;
        }

        private void CheckAim()
        {
            if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out var hit))
            {
                if (hit.transform.TryGetComponent(out IAimable aimable))
                {
                    if (aimable is IDraggable draggable)
                    {
                        _dragModel.SetDraggableInfo(draggable, hit.distance);
                        return;
                    }

                    aimable.OnAimed(hit.distance);
                }
            }
        }

        private void CheckUiAim()
        {
            var pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)
            };

            var raycastResults = new List<RaycastResult>();

            _backpackUiRaycaster.Raycast(pointerEventData, raycastResults);

            foreach (var raycastResult in raycastResults)
            {
                if (raycastResult.gameObject.TryGetComponent(out IAimable aimable))
                {
                    aimable.OnAimed(raycastResult.distance);
                    return;
                }
            }
        }
    }
}