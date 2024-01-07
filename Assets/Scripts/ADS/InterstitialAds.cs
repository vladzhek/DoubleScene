using UnityEngine;
using UnityEngine.Advertisements;

namespace DefaultNamespace.ADS
{
    public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        [SerializeField] private string androidAdID = "Interstitial_Android";
        [SerializeField] private string IOSAdID = "Interstitial_iOS";
        
        private string adID;

        private void Awake()
        {
            adID = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? IOSAdID
                : androidAdID;
            LoadAd();
            DontDestroyOnLoad(this);
        }

        private void LoadAd()
        {
            Advertisement.Load(adID, this);
        }

        public void ShowAd()
        {
            Advertisement.Show(adID, this);
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
        }

        public void OnUnityAdsShowStart(string placementId)
        {
        }

        public void OnUnityAdsShowClick(string placementId)
        {
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            LoadAd();
        }
    }
}