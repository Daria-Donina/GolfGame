using System.Collections.Generic;
using Camera;
using DefaultNamespace.Configs;
using DefaultNamespace.Map;
using DefaultNamespace.Progress;
using InputService;
using Movement;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelLauncher : ISavedProgress
    {
        private readonly ISceneObjectsFactory _factory;
        private readonly Transform _mapContainer;
        private readonly Transform _playerContainer;
        private readonly SaveLoadService _saveLoadService;
        private readonly ConfigsService _configsService;
        private int _currentLevel;

        public LevelLauncher(ISceneObjectsFactory factory,
            Transform mapContainer,
            Transform playerContainer,
            SaveLoadService saveLoadService, 
            ConfigsService configsService)
        {
            _configsService = configsService;
            _saveLoadService = saveLoadService;
            _playerContainer = playerContainer;
            _mapContainer = mapContainer;
            _factory = factory;
        }
        
        public void StartLevel(int levelId)
        {
            _currentLevel = levelId;
            _saveLoadService.SaveProgress();

            var mapData = _configsService.GetStaticData<MapsStaticData>().GetDataBy(levelId);
            
            PrepareMap(mapData.mapName);
            var player = PreparePlayers(new List<string> {mapData.playerPrefab}, 0);
            PrepareCamera(player);
        }

        private void PrepareCamera(BallMovement following) => 
            CameraUtils.MainCamera.GetComponent<CameraMovement>().Initialize(following);

        private void PrepareMap(string mapName) => _factory.Spawn(mapName, _mapContainer);

        private BallMovement PreparePlayers(IReadOnlyList<string> playerNames, int thisPlayerIndex)
        {
            BallMovement thisPlayer = null;
            for (var index = 0; index < playerNames.Count; index++)
            {
                var player = _factory.Spawn<BallMovement>(playerNames[index], _playerContainer);
                if (index == thisPlayerIndex) 
                    thisPlayer = player;
            }

            return thisPlayer;
        }

        public void LoadProgress(PlayerProgress progress) { }

        public void UpdateProgress(PlayerProgress progress) => 
            progress.playerInfo.level = _currentLevel;
    }
}