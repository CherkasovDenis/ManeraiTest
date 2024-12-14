using System;
using System.Collections.Generic;
using System.Linq;
using ManeraiTest.Item;
using ManeraiTest.Item.Configs;

namespace ManeraiTest.Backpack.Models
{
    public class BackpackModel
    {
        public event Action<ItemConfig> ItemStored;

        public event Action<ItemConfig> ItemTaken;

        public event Action SelectedBackpack;

        public event Action DeselectedBackpack;

        private readonly List<IStorableItem> _storedItems = new List<IStorableItem>();

        public void StoreItem(IStorableItem storableItem)
        {
            _storedItems.Add(storableItem);
            ItemStored?.Invoke(storableItem.ItemConfig);
        }

        public IStorableItem TakeItem(ItemType itemType)
        {
            var storedItem = _storedItems.FirstOrDefault(x => x.ItemConfig.Type == itemType);

            if (storedItem != null)
            {
                _storedItems.Remove(storedItem);
            }

            return storedItem;
        }

        public void OnItemTaken(ItemConfig itemConfig)
        {
            ItemTaken?.Invoke(itemConfig);
        }

        public void OnSelectedBackpack()
        {
            SelectedBackpack?.Invoke();
        }

        public void OnDeselectedBackpack()
        {
            DeselectedBackpack?.Invoke();
        }
    }
}