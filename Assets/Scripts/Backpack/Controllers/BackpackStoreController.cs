using DG.Tweening;
using ManeraiTest.Backpack.Models;
using ManeraiTest.Backpack.Views;
using ManeraiTest.Item;
using VContainer.Unity;

namespace ManeraiTest.Backpack.Controllers
{
    public class BackpackStoreController : IInitializable
    {
        private readonly BackpackView _backpackView;
        private readonly BackpackModel _backpackModel;

        public BackpackStoreController(BackpackView backpackView, BackpackModel backpackModel)
        {
            _backpackView = backpackView;
            _backpackModel = backpackModel;
        }

        public void Initialize()
        {
            _backpackView.AddedItemToBackpack += StoreItem;
        }

        private void StoreItem(IStorableItem storableItem)
        {
            var itemConfig = storableItem.ItemConfig;
            if (_backpackView.TryGetSlot(itemConfig.Type, out var backpackSlot))
            {
                storableItem.AttachToTransform(backpackSlot.AttachTransform, _backpackView.AttachDuration)
                    .OnComplete(() => _backpackModel.StoreItem(storableItem));
            }
        }
    }
}