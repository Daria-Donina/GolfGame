using DefaultNamespace.Map;
using Zenject;

namespace DefaultNamespace.Progress
{
    public class SaveLoadService
    {
        private const string ProgressKey = "Progress";
        
        private readonly ISceneObjectsFactory _gameFactory;
        private readonly IProgressService _progressService;

        public SaveLoadService(IProgressService progressService, ISceneObjectsFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void SaveProgress()
        {
            foreach (var progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);
            
            //PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return null;
            //return PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();
        }
    }
}