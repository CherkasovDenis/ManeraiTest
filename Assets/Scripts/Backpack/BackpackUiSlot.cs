using System;
using ManeraiTest.Backpack.Views;
using ManeraiTest.Item;
using UnityEngine;

namespace ManeraiTest.Data
{
    [Serializable]
    public class BackpackUiSlot
    {
        public ItemType Type => _type;

        public StoredItemUiView StoredItemUiView => _storedItemUiView;

        [SerializeField]
        private ItemType _type;

        [SerializeField]
        private StoredItemUiView _storedItemUiView;
    }
}