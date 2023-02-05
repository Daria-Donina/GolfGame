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
        [SerializeField] private float impulseForce;
        [SerializeField] private float minSpeedConstraint;
    
        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.DragCompleted += GetImpulse;
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
            _inputService.Enable(true);
        }
    }
}