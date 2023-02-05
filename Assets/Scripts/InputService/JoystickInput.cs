using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace InputService
{
    public class JoystickInput : FixedJoystick, IInputService
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string animatorTriggerPrefix;
        
        public event Action<Vector2> DragCompleted;

        public override void OnPointerUp(PointerEventData eventData)
        {
            DragCompleted?.Invoke(Direction);
            Enable(false);
            base.OnPointerUp(eventData);
        }

        public void Enable(bool value)
        {
            if (value)
            {
                gameObject.SetActive(true);
                animator.SetTrigger($"{animatorTriggerPrefix}_{value}");
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}