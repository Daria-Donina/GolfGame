using System;
using UnityEngine;

namespace Movement
{
    public class RotationStabilizer : MonoBehaviour
    {
        [SerializeField] private RectTransform rect;
        [SerializeField] private Vector3 rotation;

        private void Update() => rect.rotation = Quaternion.Euler(rotation);
    }
}