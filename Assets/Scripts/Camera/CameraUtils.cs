using UnityEngine;

namespace Camera
{
    public static class CameraUtils
    {
        private static UnityEngine.Camera MainCamera => UnityEngine.Camera.main;
        
        public static Vector3 InputToWorldDirection(Vector2 point)
        {
            return MainCamera.transform.TransformDirection(point);
        }
    }
}