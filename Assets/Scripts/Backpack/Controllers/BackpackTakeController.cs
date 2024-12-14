using System;
using ManeraiTest.Backpack.Models;
using ManeraiTest.Backpack.Views;
using ManeraiTest.Drag;
using ManeraiTest.Drag.Models;
using ManeraiTest.Item;
using VContainer.Unity;

namespace ManeraiTest.Backpack.Controllers
{
    public class BackpackTakeController : IInitializable, IDisposable
    {
        private readonly BackpackUiView _backpackUiView;
        private readonly BackpackView _backpackView;
        private readonly BackpackModel _backpackModel;
        private readonly DragModel _dragModel;

        public BackpackTakeController(BackpackUiView backpackUiView, BackpackView backpackView,
            BackpackModel backpackModel, DragModel dragModel)
        {
            _backpackUiView = backpackUiView;
            _backpackView = backpackView;
            _backpackModel = backpackModel;
            _dragModel = dragModel;
        }

        public void Initialize()
        {
            _backpackUiView.AimedUiItem += TakeItem;
        }

        public void Dispose()
        {
            _backpackUiView.AimedUiItem -= TakeItem;
        }

        private void TakeItem(AimedItem aimedItem)
        {
            var storedItem = _backpackModel.TakeItem(aimedItem.ItemType);

            if (storedItem is IDraggable draggable)
            {
                draggable.SetReadyToDrag(true);

                _dragModel.SetDraggableInfo(draggable, aimedItem.Distance);

                var itemConfig = storedItem.ItemConfig;
                _backpackModel.OnItemTaken(itemConfig);
            }
        }
    }
}