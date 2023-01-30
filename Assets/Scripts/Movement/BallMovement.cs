using Camera;
using InputService;
using UnityEngine;
using Zenject;

namespace Movement
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float impulseForce;
    
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
        }
    }
}