using System;
using ManeraiTest.Aim;
using ManeraiTest.Item;
using TMPro;
using UnityEngine;

namespace ManeraiTest.Backpack.Views
{
    public class StoredItemUiView : MonoBehaviour, IAimable
    {
        public event Action<AimedItem> Aimed;

        [SerializeField]
        private TMP_Text _text;

        private ItemType _itemType;

        public void SetText(string text)
        {
            _text.text = text;
            EnableText();
        }

        public void SetItemType(ItemType itemType)
        {
            _itemType = itemType;
        }

        public void EnableText()
        {
            _text.gameObject.SetActive(true);
        }

        public void DisableText()
        {
            _text.gameObject.SetActive(false);
        }

        public void OnAimed(float distance)
        {
            Aimed?.Invoke(new AimedItem(_itemType, distance));
        }
    }
}