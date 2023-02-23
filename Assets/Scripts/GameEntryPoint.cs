using System;
using System.Collections.Generic;
using DefaultNamespace.Configs;
using DefaultNamespace.Loaders;
using DefaultNamespace.Map;
using DefaultNamespace.Progress;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform mapContainer;
        [SerializeField] private Transform playersContainer;
        
        private ProgressServerHandler _progressServerHandler;

        private void Awake()
        {
            SingleGameSimpleStart();

            DontDestroyOnLoad(this);
        }

        private void SingleGameSimpleStart()
        {
            var prefabLoader = new BaseAssetLoader<GameObject>("Prefabs");
            var sceneObjectsFactory = new SceneObjectsFactory(prefabLoader);

            var progressService = new ProgressService();
            _progressServerHandler = new ProgressServerHandler();
            var saveLoadService = new SaveLoadService(progressService, sceneObjectsFactory, _progressServerHandler);
            var progress = LoadProgressOrInitNew(progressService, saveLoadService);

            var configsLoader = new BaseAssetLoader<BaseConfig>("Configs");
            var configsService = new ConfigsService(configsLoader);
            
            var levelLauncher = new LevelLauncher(sceneObjectsFactory,
                mapContainer,
                playersContainer,
                saveLoadService,
                configsService);
            levelLauncher.StartLevel(progress.playerInfo.level);
        }
        
        private PlayerProgress LoadProgressOrInitNew(ProgressService progressService, SaveLoadService saveLoadService)
        {
            var loadedProgress = saveLoadService.LoadProgress();
            return progressService.Progress = loadedProgress 
                                              ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            var progress = new PlayerProgress(levelId: 1);
            return progress;
        }

        private void OnDestroy()
        {
            _progressServerHandler?.Dispose();
        }
    }
}