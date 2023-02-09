using System;
using Camera;
using Cysharp.Threading.Tasks;
using InputService;
using UnityEngine;
using Zenject;

namespace Movement
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private JoystickInput input;
        [SerializeField] private float impulseForce;
        [SerializeField] private float minSpeedConstraint;

        private void Start()
        {
            input.DragCompleted += GetImpulse;
        }

        private void GetImpulse(Vector2 direction)
        {
            var worldDirection = CameraUtils.InputToWorldDirection(direction);
            rb.AddForce(worldDirection * impulseForce, ForceMode.Impulse);
            MovingCoroutine().Forget();
        }

        private async UniTaskVoid MovingCoroutine()
        {
            await UniTask.NextFrame();
            await UniTask.WaitWhile(() => rb.velocity.magnitude > minSpeedConstraint);

            rb.velocity = Vector3.zero;
            input.Enable(true);
        }
    }
}