using DefaultNamespace.ADS;
using Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class SceneADSController : MonoBehaviour
{
    private const string MainScene = "Assets/Scenes/Main.unity";
    
    [SerializeField] private GameObject _buttonADS;
    [SerializeField] private GameObject _buttonMenu;
    private AnalyticService _analyticService;
    private ProgressService _progressService;
    private InterstitialAds _ad;

    [Inject]
    public void Construct(ProgressService progressService, InterstitialAds interstitialAds)
    {
        _progressService = progressService;
        _ad = interstitialAds;
        _analyticService = new AnalyticService(_progressService);
    }
    private void Start()
    {
        _analyticService.SendLevelVisit("ADSLevel");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == _buttonADS)
                {
                    OnClickADS();
                }
                else if (hit.collider.gameObject == _buttonMenu)
                {
                    OnClickMenu();
                }
            }
        }
    }

    private void OnClickMenu()
    {
        Addressables.LoadSceneAsync(MainScene);
    }

    private void OnClickADS()
    {
        _ad.ShowAd();
    }
}
