using UnityEngine;
using UnityEngine.Advertisements;

namespace DefaultNamespace.ADS
{
    public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
    {
        [SerializeField] private string androidGameID = "5518782";
        [SerializeField] private string IOSGameID = "5518783";
        [SerializeField] private bool testMode = true;
        private string gameID;

        private void Awake()
        {
            InitializeAds();
            DontDestroyOnLoad(this);
        }

        private void InitializeAds()
        {
            gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? IOSGameID : androidGameID;
            Advertisement.Initialize(gameID, testMode, this);
        }

        public void OnInitializationComplete()
        {
            Debug.Log("Unity ADS Initialization Complete");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log("Unity ADS Initialization failed");
        }
    }
}