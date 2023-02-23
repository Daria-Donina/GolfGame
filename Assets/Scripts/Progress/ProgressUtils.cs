using UnityEngine;

namespace DefaultNamespace.Progress
{
    public static class ProgressUtils
    {
        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);
        
        public static string ToJson(this object progress) =>
            JsonUtility.ToJson(progress);
    }
}