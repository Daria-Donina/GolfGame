using System;
using System.Threading;
using Camera;
using Cysharp.Threading.Tasks;
using InputService;
using UniRx;
using UnityEngine;
using Zenject;

namespace Movement
{
    public class BallMovement : MonoBehaviour, IFollowable
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private JoystickInput input;
        [SerializeField] private float impulseForce;
        [SerializeField] private float minSpeedConstraint;
        
        private CancellationTokenSource _cancellationTokenSource;

        public Vector3 StaticPosition => transform.position;
        public IObservable<Vector3> Position { get; private set; }

        private void Awake()
        {
            Position = transform.ObserveEveryValueChanged(x => x.position);
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
            _cancellationTokenSource = new CancellationTokenSource();
            await UniTask.NextFrame();
            await UniTask.WaitWhile(() => rb.velocity.magnitude > minSpeedConstraint,
                cancellationToken: _cancellationTokenSource.Token);

            if (_cancellationTokenSource.IsCancellationRequested)
                return;
            
            rb.velocity = Vector3.zero;
            input.Enable(true);
        }

        private void OnDestroy()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }
    }
}