using System;
using System.Collections.Generic;
using DefaultNamespace.Loaders;
using DefaultNamespace.Map;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform mapContainer;
        [SerializeField] private Transform playersContainer;

        private void Awake()
        {
            SingleGameSimpleStart();

            DontDestroyOnLoad(this);
        }

        private void SingleGameSimpleStart()
        {
            var prefabLoader = new PrefabLoader();
            var sceneObjectsFactory = new SceneObjectsFactory(prefabLoader);
            var levelLauncher = new LevelLauncher(sceneObjectsFactory, mapContainer, playersContainer);

            //TODO load info about the levels from configs
            levelLauncher.StartLevel("test_map", new List<string>() {"ball"});
        }
    }
}