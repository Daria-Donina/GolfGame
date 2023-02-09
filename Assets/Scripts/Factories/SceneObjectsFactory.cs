using DefaultNamespace.Loaders;
using InputService;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Map
{
    public class SceneObjectsFactory 
    {
        private readonly IAssetLoader<GameObject> _prefabLoader;

        public SceneObjectsFactory(IAssetLoader<GameObject> prefabLoader)
        {
            _prefabLoader = prefabLoader;
        }
        
        public GameObject Spawn(string name, Transform parent)
        {
            var prefab = _prefabLoader.Load(name);
            var go = Object.Instantiate(prefab, parent);
            return go;
        }
        
        public T Spawn<T>(string name, Transform parent) where T : MonoBehaviour
        {
            var go = Spawn(name, parent);
            return go.GetComponent<T>();
        }
    }
}