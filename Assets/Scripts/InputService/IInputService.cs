using System;
using UnityEngine;

namespace InputService
{
    public interface IInputService
    {
        event Action<Vector2> DragCompleted;
        void Enable(bool value);
    }
}