using System;
using ManeraiTest.Item;
using UnityEngine;

namespace ManeraiTest.Backpack
{
    [Serializable]
    public class BackpackSlot
    {
        public ItemType Type => _type;

        public Transform AttachTransform => _attachTransform;

        [SerializeField]
        private ItemType _type;

        [SerializeField]
        private Transform _attachTransform;
    }
}