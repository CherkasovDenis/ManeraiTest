using ManeraiTest.Aim.Controllers;
using ManeraiTest.Backpack.Controllers;
using ManeraiTest.Backpack.Models;
using ManeraiTest.Backpack.Views;
using ManeraiTest.CameraLogic;
using ManeraiTest.CameraLogic.Controllers;
using ManeraiTest.Drag.Controllers;
using ManeraiTest.Drag.Models;
using ManeraiTest.Input.Controllers;
using ManeraiTest.Input.Models;
using ManeraiTest.ServerInteraction;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace ManeraiTest
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private BackpackView _backpackView;

        [SerializeField]
        private BackpackUiView _backpackUiView;

        [SerializeField]
        private GraphicRaycaster _backpackUiRaycaster;

        [SerializeField]
        private CameraMovementData _cameraMovementData;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_camera);
            builder.RegisterInstance(_cameraMovementData);

            builder.Register<InputModel>(Lifetime.Singleton);
            builder.RegisterEntryPoint<InputController>();

            builder.RegisterEntryPoint<CameraRotationController>();
            builder.RegisterEntryPoint<CameraMovementController>();

            builder.RegisterEntryPoint<AimController>().WithParameter(_backpackUiRaycaster);

            builder.Register<DragModel>(Lifetime.Singleton);
            builder.RegisterEntryPoint<DragController>();

            builder.Register<BackpackModel>(Lifetime.Singleton);
            builder.RegisterEntryPoint<BackpackSelectController>();

            builder.RegisterInstance(_backpackView);
            builder.RegisterEntryPoint<BackpackStoreController>();
            builder.RegisterEntryPoint<BackpackTakeController>();

            builder.RegisterInstance(_backpackUiView);
            builder.RegisterEntryPoint<BackpackUiController>();

            builder.RegisterEntryPoint<BackpackEventsController>();

            builder.Register<ServerInteractionService>(Lifetime.Singleton);
        }
    }
}