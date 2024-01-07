using GameAnalyticsSDK;
using Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace infastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private const string MainScene = "Assets/Scenes/Main.unity";
        private Game _game;
        private SaveLoadService _saveLoadService;

        [Inject]
        public void Construct(SaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        private void Awake()
        {
            _game = new Game();
            _saveLoadService.LoadProgress();
            GameAnalytics.Initialize();
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            Addressables.LoadSceneAsync(MainScene);
        }

        private void OnApplicationQuit()
        {
            _saveLoadService.SaveProgress();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            _saveLoadService.SaveProgress();
        }
    }
}