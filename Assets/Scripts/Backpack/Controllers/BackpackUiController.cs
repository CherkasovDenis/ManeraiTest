using System;
using ManeraiTest.Backpack.Models;
using ManeraiTest.Backpack.Views;
using ManeraiTest.Item.Configs;
using UnityEngine;
using VContainer.Unity;

namespace ManeraiTest.Backpack.Controllers
{
    public class BackpackUiController : IInitializable, IDisposable, IStartable, ITickable
    {
        private readonly Transform _cameraTransform;
        private readonly BackpackUiView _backpackUiView;
        private readonly BackpackModel _backpackModel;

        public BackpackUiController(Camera camera, BackpackUiView backpackUiView, BackpackModel backpackModel)
        {
            _cameraTransform = camera.transform;
            _backpackUiView = backpackUiView;
            _backpackModel = backpackModel;
        }

        public void Initialize()
        {
            _backpackModel.ItemStored += UpdateText;
            _backpackModel.ItemTaken += ResetText;
            _backpackModel.SelectedBackpack += EnableCanvas;
            _backpackModel.DeselectedBackpack += DisableCanvas;
        }

        public void Dispose()
        {
            _backpackModel.ItemStored -= UpdateText;
            _backpackModel.ItemTaken -= ResetText;
            _backpackModel.SelectedBackpack -= EnableCanvas;
            _backpackModel.DeselectedBackpack -= DisableCanvas;
        }

        public void Start()
        {
            DisableCanvas();
        }

        public void Tick()
        {
            if (_backpackUiView.CanvasIsEnabled)
            {
                RotateCanvasTowardsCamera();
            }
        }

        private void UpdateText(ItemConfig itemConfig)
        {
            _backpackUiView.UpdateText(itemConfig);
        }

        private void ResetText(ItemConfig itemConfig)
        {
            _backpackUiView.ResetText(itemConfig.Type);
        }

        private void EnableCanvas()
        {
            _backpackUiView.EnableCanvas();
        }

        private void DisableCanvas()
        {
            _backpackUiView.DisableCanvas();
        }

        private void RotateCanvasTowardsCamera()
        {
            var lookRotation = Quaternion.LookRotation(_cameraTransform.forward).eulerAngles;

            _backpackUiView.transform.eulerAngles = new Vector3(0f, lookRotation.y, 0f);
        }
    }
}