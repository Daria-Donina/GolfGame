using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Movement
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float distanceZ;
        [SerializeField] private float distanceX;
        
        [Space]
        [Tooltip("The less, the smoother")]
        [SerializeField] private float smoothness;

        private BallMovement _objectToFollow;
        private bool _isMoving;

        private void Update()
        {
            //TODO link it with the ball with UniRX
            Follow();
        }

        public void Initialize(BallMovement objectToFollow)
        {
            _objectToFollow = objectToFollow;
            
            transform.LookAt(objectToFollow.transform.position);
        }

        private void Follow()
        {
            var startPosition = transform.position;
            var targetPosition = _objectToFollow.transform.position;

            targetPosition.y = startPosition.y;
            targetPosition.z -= distanceZ;
            targetPosition.x -= distanceX;

            transform.position = Vector3.Lerp(startPosition, targetPosition, Time.deltaTime * smoothness);
        }
    }
}