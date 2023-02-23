using DefaultNamespace.Map;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Progress
{
    public class SaveLoadService
    {
        private readonly ISceneObjectsFactory _gameFactory;
        private readonly IProgressService _progressService;
        private readonly ProgressServerHandler _progressServerHandler;

        public SaveLoadService(IProgressService progressService, ISceneObjectsFactory gameFactory,
            ProgressServerHandler progressServerHandler)
        {
            _gameFactory = gameFactory;
            _progressService = progressService;
            _progressServerHandler = progressServerHandler;
        }

        public void SaveProgress()
        {
            foreach (var progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);
            
            _progressServerHandler.SaveProgress(_progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress() => 
            _progressServerHandler.LoadProgress()?.ToDeserialized<PlayerProgress>();
    }
}