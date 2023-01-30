using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputService
{
    public class JoystickInput : FixedJoystick, IInputService
    {
        public event Action<Vector2> DragCompleted;

        public override void OnPointerUp(PointerEventData eventData)
        {
            DragCompleted?.Invoke(Direction);
            base.OnPointerUp(eventData);
        }
    }
}