using DG.Tweening;
using ManeraiTest.Item.Configs;
using UnityEngine;

namespace ManeraiTest.Item
{
    public interface IStorableItem
    {
        public bool ReadyToStore { get; }

        public ItemConfig ItemConfig { get; }

        public Sequence AttachToTransform(Transform attachTransform, float duration);
    }
}