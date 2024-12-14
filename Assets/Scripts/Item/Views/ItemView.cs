using DG.Tweening;
using ManeraiTest.Aim;
using ManeraiTest.Drag;
using ManeraiTest.Item.Configs;
using UnityEngine;

namespace ManeraiTest.Item.Views
{
    public class ItemView : MonoBehaviour, IAimable, IDraggable, IStorableItem
    {
        public ItemConfig ItemConfig => _itemConfig;

        [SerializeField]
        private ItemConfig _itemConfig;

        [SerializeField]
        private Rigidbody _rigidbody;

        public Vector3 Position => transform.position;

        public bool ReadyToDrag { get; private set; }

        public bool ReadyToStore { get; private set; }

        private void Start()
        {
            ReadyToDrag = true;
            ReadyToStore = true;
        }

        public void OnAimed(float distance)
        {
            PrepareForDrag();
        }

        public void SetReadyToDrag(bool value)
        {
            ReadyToDrag = value;
        }

        public void PrepareForDrag()
        {
            DisableGravity();

            transform.parent = null;

            ReadyToStore = false;
        }

        public void RestoreDragChanges()
        {
            EnableGravity();

            ReadyToStore = true;
        }

        public void MovePosition(Vector3 position)
        {
            _rigidbody.MovePosition(position);
        }

        public Sequence AttachToTransform(Transform attachTransform, float duration)
        {
            ReadyToDrag = false;
            ReadyToStore = false;

            DisableGravity();

            transform.parent = attachTransform;

            var sequence = DOTween.Sequence()
                .Append(_rigidbody.DOMove(attachTransform.position, duration))
                .Join(_rigidbody.DORotate(attachTransform.eulerAngles, duration));

            return sequence;
        }

        private void DisableGravity()
        {
            _rigidbody.useGravity = false;
            _rigidbody.isKinematic = true;
        }

        private void EnableGravity()
        {
            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;
        }
    }
}