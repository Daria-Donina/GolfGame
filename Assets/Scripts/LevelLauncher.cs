using System.Collections.Generic;
using DefaultNamespace.Map;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelLauncher
    {
        private readonly SceneObjectsFactory _factory;
        private readonly Transform _mapContainer;
        private readonly Transform _playerContainer;

        public LevelLauncher(SceneObjectsFactory factory, Transform mapContainer, Transform playerContainer)
        {
            _playerContainer = playerContainer;
            _mapContainer = mapContainer;
            _factory = factory;
        }
        
        public void StartLevel(string mapName, List<string> playerNames)
        {
            PrepareMap(mapName);
            PreparePlayers(playerNames);
        }

        private void PrepareMap(string mapName)
        {
            _factory.Spawn(mapName, _mapContainer);
        }

        private void PreparePlayers(List<string> playerNames)
        {
            foreach (var name in playerNames) 
                _factory.Spawn(name, _playerContainer);
        }
    }
}