using System;
using System.Collections.Generic;
using System.Linq;
using ManeraiTest.Data;
using ManeraiTest.Item;
using ManeraiTest.Item.Configs;
using UnityEngine;

namespace ManeraiTest.Backpack.Views
{
    public class BackpackUiView : MonoBehaviour
    {
        public event Action<AimedItem> AimedUiItem;

        public bool CanvasIsEnabled => _canvas.enabled;

        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private List<BackpackUiSlot> _backpackUiSlots;

        private void Start()
        {
            foreach (var backpackUiSlot in _backpackUiSlots)
            {
                var storedItemUiView = backpackUiSlot.StoredItemUiView;
                storedItemUiView.SetItemType(backpackUiSlot.Type);
                storedItemUiView.Aimed += AimedItem;
            }
        }

        public void EnableCanvas()
        {
            _canvas.enabled = true;
        }

        public void DisableCanvas()
        {
            _canvas.enabled = false;
        }

        public void UpdateText(ItemConfig itemConfig)
        {
            var backpackUiSlot = GetBackpackUiSlot(itemConfig.Type);

            backpackUiSlot?.StoredItemUiView.SetText(itemConfig.Name);
        }

        public void ResetText(ItemType itemType)
        {
            var backpackUiSlot = GetBackpackUiSlot(itemType);

            backpackUiSlot?.StoredItemUiView.SetText(string.Empty);
        }

        private BackpackUiSlot GetBackpackUiSlot(ItemType itemType)
        {
            return _backpackUiSlots.FirstOrDefault(x => x.Type == itemType);
        }

        private void AimedItem(AimedItem aimedItem)
        {
            AimedUiItem?.Invoke(aimedItem);
        }
    }
}