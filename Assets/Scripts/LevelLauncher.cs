using System.Collections.Generic;
using Camera;
using DefaultNamespace.Map;
using InputService;
using Movement;
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
        
        public void StartLevel(string mapName, List<string> playerNames, int thisPlayerIndex)
        {
            PrepareMap(mapName);
            var player = PreparePlayers(playerNames, thisPlayerIndex);
            PrepareCamera(player);
        }

        private void PrepareCamera(BallMovement ballMovement) => 
            CameraUtils.MainCamera.GetComponent<CameraMovement>().Initialize(ballMovement);

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
    }
}