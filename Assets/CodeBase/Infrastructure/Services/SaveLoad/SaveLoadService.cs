using CodeBase.Infrastructure.Data;
using CodeBase.Infrastructure.Services.GameFactory;
using CodeBase.Infrastructure.Services.PersistenceProgress;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string PROGRESS_KEY = "PlayerProgress";
        
        private readonly IPersistenceProgressServices _progressServices;
        private readonly IGameFactory _gameFactory;


        public SaveLoadService(IPersistenceProgressServices progressServices, IGameFactory gameFactory)
        {
            _progressServices = progressServices;
            _gameFactory = gameFactory;
        }
        
        public void SaveProgress()
        {
            if (_progressServices.Progress == null)
                _progressServices.Progress = new PlayerProgress();
            
            _gameFactory.ProgressWriters.ForEach(
                x => x.UpdateProgress(_progressServices.Progress));
            

            Debug.Log("Saved progress: " + _progressServices.Progress.ToJson());
            
            PlayerPrefs.SetString(PROGRESS_KEY, _progressServices.Progress.ToJson());
            PlayerPrefs.Save();
        }

        public PlayerProgress LoadProgress()
        {
            PlayerProgress playerProgress = GetPlayerProgress();
            
            _gameFactory.ProgressReaders.ForEach(x => x.LoadProgress(playerProgress));

            return playerProgress;
        }

        private PlayerProgress GetPlayerProgress()
        {
            if (PlayerPrefs.HasKey(PROGRESS_KEY))
            {
                string progressJson = PlayerPrefs.GetString(PROGRESS_KEY);
                
                Debug.Log("Loaded progress: " + progressJson);
                
                return progressJson.ToDeserialize<PlayerProgress>();
            }

            return new PlayerProgress();
        }
    }
}