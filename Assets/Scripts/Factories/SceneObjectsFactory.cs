using System.Collections.Generic;
using DefaultNamespace.Loaders;
using DefaultNamespace.Progress;
using InputService;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Map
{
    public class SceneObjectsFactory : ISceneObjectsFactory
    {
        private readonly IAssetLoader<GameObject> _prefabLoader;

        public List<ISavedProgressReader> ProgressReaders { get; } = new();
        public List<ISavedProgress> ProgressWriters { get; } = new();

        public SceneObjectsFactory(IAssetLoader<GameObject> prefabLoader)
        {
            _prefabLoader = prefabLoader;
        }

        public GameObject Spawn(string name, Transform parent)
        {
            var prefab = _prefabLoader.Load(name);
            var go = Object.Instantiate(prefab, parent);
            RegisterGameObject(go);
            return go;
        }

        public T Spawn<T>(string name, Transform parent) where T : MonoBehaviour
        {
            var go = Spawn(name, parent);
            return go.GetComponent<T>();
        }

        private void RegisterGameObject(GameObject instantiated)
        {
            foreach (var progressReader in instantiated.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }
    }
}