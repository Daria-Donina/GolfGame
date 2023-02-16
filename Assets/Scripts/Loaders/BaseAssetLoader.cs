using System.IO;
using UnityEngine;

namespace DefaultNamespace.Loaders
{
    public class BaseAssetLoader<T> : IAssetLoader<T> where T : UnityEngine.Object
    {
        private readonly string _pathStart;

        public BaseAssetLoader(string pathPrefix)
        {
            _pathStart = pathPrefix;
        }

        public T Load(string name)
        {
            var path = Path.Combine(_pathStart, name); 
            var go = Resources.Load<T>(path);
            return go;
        }
    }
}