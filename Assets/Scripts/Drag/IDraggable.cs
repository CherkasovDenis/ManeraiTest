using UnityEngine;

namespace ManeraiTest.Drag
{
    public interface IDraggable
    {
        public bool ReadyToDrag { get; }

        public Vector3 Position { get; }

        public void SetReadyToDrag(bool value);

        public void PrepareForDrag();

        public void RestoreDragChanges();

        public void MovePosition(Vector3 position);
    }
}