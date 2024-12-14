using System;
using System.Collections.Generic;
using System.Linq;
using ManeraiTest.Aim;
using ManeraiTest.Item;
using ManeraiTest.Item.Configs;
using UnityEngine;
using UnityEngine.Events;

namespace ManeraiTest.Backpack.Views
{
    public class BackpackView : MonoBehaviour, IAimable
    {
        public event Action Aimed;

        public event Action<IStorableItem> AddedItemToBackpack;

        public float AttachDuration => _attachDuration;

        [SerializeField]
        private float _attachDuration;

        [SerializeField]
        private List<BackpackSlot> _backpackSlots;

        [SerializeField]
        private UnityEvent<ItemConfig> _itemStored;

        [SerializeField]
        private UnityEvent<ItemConfig> _itemTaken;

        public void OnAimed(float distance)
        {
            Aimed?.Invoke();
        }

        public bool TryGetSlot(ItemType itemType, out BackpackSlot backpackSlot)
        {
            backpackSlot = _backpackSlots.FirstOrDefault(x => x.Type == itemType);

            return backpackSlot != null;
        }

        public void OnItemStored(ItemConfig itemConfig)
        {
            _itemStored?.Invoke(itemConfig);
        }

        public void OnItemTaken(ItemConfig itemConfig)
        {
            _itemTaken?.Invoke(itemConfig);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IStorableItem storableItem))
            {
                if (storableItem.ReadyToStore)
                {
                    AddedItemToBackpack?.Invoke(storableItem);
                }
            }
        }
    }
}