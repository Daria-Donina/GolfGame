using UniRx;
using UnityEngine;

namespace Movement
{
    public class CameraMovement : MonoBehaviour
    {
        private Vector3 _previousBallPosition;

        public void Initialize(IFollowable objectToFollow)
        {
            var initialPosition = objectToFollow.StaticPosition;
            _previousBallPosition = initialPosition;

            objectToFollow.Position.Subscribe(Follow);
            transform.LookAt(initialPosition);
        }

        private void Follow(Vector3 pos)
        {
            var diff = pos - _previousBallPosition;
            var startPosition = transform.position;
            var targetPosition = startPosition + diff;
            
            transform.position = targetPosition;
            _previousBallPosition = pos;
        }
    }
}