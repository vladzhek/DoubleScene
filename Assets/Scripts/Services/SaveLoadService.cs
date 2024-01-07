using DefaultNamespace;
using UnityEngine;

namespace Services
{
    public class SaveLoadService
    {
        private const string SavesKey = "Saves";
        private ProgressService _progressService;
        
        public SaveLoadService(ProgressService progressService)
        {
            _progressService = progressService;
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(SavesKey, JsonUtility.ToJson(_progressService.PlayerProgress));
            Debug.Log("[Save] \n" + JsonUtility.ToJson(_progressService.PlayerProgress));
        }
        
        public void LoadProgress()
        {
            Debug.Log("[Load] \n" + JsonUtility.ToJson(_progressService.PlayerProgress));
            _progressService.InitializeProgress(GetOrCreate());
        }
        
        private PlayerProgress GetOrCreate()
        {
            if (PlayerPrefs.HasKey(SavesKey))
            {
                var saves = PlayerPrefs.GetString(SavesKey);
                return JsonUtility.FromJson<PlayerProgress>(saves);
            }
            
            return new PlayerProgress();
        }
    }
}