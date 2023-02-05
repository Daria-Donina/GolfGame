using System;
using UnityEngine;

namespace Movement
{
    public class PositionFollower : MonoBehaviour
    {
        [SerializeField] private Transform objectToFollow;
        [SerializeField] private float distanceZ;
        [SerializeField] private float distanceX;
        
        [Space]
        [Tooltip("The less, the smoother")]
        [SerializeField] private float smoothness;

        private void Start()
        {
            transform.LookAt(objectToFollow.position);
        }

        private void Update()
        {
            Follow();
        }

        private void Follow()
        {
            var startPosition = transform.position;
            var targetPosition = objectToFollow.position;

            targetPosition.y = startPosition.y;
            targetPosition.z -= distanceZ;
            targetPosition.x -= distanceX;

            transform.position = Vector3.Lerp(startPosition, targetPosition, Time.deltaTime * smoothness);
        }
    }
}