using DefaultNamespace.Loaders;
using UnityEngine;

namespace DefaultNamespace.Map
{
    public class SceneObjectsFactory
    {
        private readonly IAssetLoader<GameObject> _prefabLoader;

        public SceneObjectsFactory(IAssetLoader<GameObject> prefabLoader)
        {
            _prefabLoader = prefabLoader;
        }
        
        public void Spawn(string name, Transform parent)
        {
            var go = _prefabLoader.Load(name);
            go.transform.SetParent(parent);
        }
    }
}