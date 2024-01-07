using DefaultNamespace.ADS;
using UnityEngine;
using Zenject;

namespace Services
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private Purchaser _purchaser;
        [SerializeField] private InterstitialAds _interstitialAds;
        
        public override void InstallBindings()
        {
            BindService();
            BindMono();
        }

        private void BindMono()
        {
            Container.Bind<Purchaser>().FromInstance(_purchaser).AsSingle();
            Container.Bind<InterstitialAds>().FromInstance(_interstitialAds).AsSingle();
        }

        private void BindService()
        {
            Container.Bind<ProgressService>().AsSingle();
            Container.Bind<SaveLoadService>().AsSingle();
        }
    }
}