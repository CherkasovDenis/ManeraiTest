using System;

namespace ManeraiTest.Drag.Models
{
    public class DragModel
    {
        public event Action UpdatedCurrentDraggable;

        public IDraggable Draggable { get; private set; }
        public float GrabDistance { get; private set; }

        public void SetDraggableInfo(IDraggable draggable, float grabDistance)
        {
            if (!draggable.ReadyToDrag)
            {
                return;
            }

            Draggable = draggable;
            GrabDistance = grabDistance;

            UpdatedCurrentDraggable?.Invoke();
        }

        public void ResetDraggableInfo()
        {
            Draggable = null;
            GrabDistance = 0f;
        }
    }
}