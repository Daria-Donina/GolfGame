using System.IO;
using UnityEngine;

namespace DefaultNamespace.Loaders
{
    public class PrefabLoader : IAssetLoader<GameObject>
    {
        private const string DefaultPathStart = "Prefabs";

        public GameObject Load(string name)
        {
            var path = Path.Combine(DefaultPathStart, name); 
            var go = Resources.Load<GameObject>(path);
            return go;
        }
    }
}