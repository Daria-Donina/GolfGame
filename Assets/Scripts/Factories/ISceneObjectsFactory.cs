using System.Collections.Generic;
using DefaultNamespace.Progress;
using UnityEngine;

namespace DefaultNamespace.Map
{
    public interface ISceneObjectsFactory
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        GameObject Spawn(string name, Transform parent);
        T Spawn<T>(string name, Transform parent) where T : MonoBehaviour;
    }
}