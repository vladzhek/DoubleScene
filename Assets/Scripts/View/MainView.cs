using Services;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Zenject;

public class MainView : MonoBehaviour
{
    private const string SceneADS = "Assets/Scenes/ADS.unity";
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private GameObject _anyIcon;
    [SerializeField] private Button _buyOnce;
    [SerializeField] private Button _nextScene;
    
    private Purchaser _purchaser;
    private AnalyticService _analyticService;
    private ProgressService _progressService;
    private bool _isBuyOnce;

    [Inject]
    void Construct(ProgressService progressService, Purchaser purchaser)
    {
        _progressService = progressService;
        _purchaser = purchaser;
        _analyticService = new AnalyticService(_progressService);
    }

    void Start()
    {
        _analyticService.SendLevelVisit("MainLevel");
        _nextScene.onClick.AddListener(NextScene);

        _purchaser.OnUpdateProductOnce += UpdateBuyOnceButton;
        _purchaser.OnUpdateCoins += UpdateCoins;
        
        UpdateBuyOnceButton();
        UpdateCoins();
    }

    private void UpdateBuyOnceButton()
    {
        _isBuyOnce = _progressService.PlayerProgress.IsOnceBuy;
        if (!_isBuyOnce) return;
        
        _anyIcon.SetActive(_progressService.PlayerProgress.IsOnceBuy);
        _buyOnce.interactable = false;
    }

    private void UpdateCoins()
    {
        _coinsText.text = _progressService.PlayerProgress.Coins.ToString();
    }

    private void NextScene()
    {
        Addressables.LoadSceneAsync(SceneADS);
    }
}
