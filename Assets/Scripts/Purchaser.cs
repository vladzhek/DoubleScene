using System;
using Services;
using UnityEngine;
using UnityEngine.Purchasing;
using Zenject;

public class Purchaser : MonoBehaviour
{
    public event Action OnUpdateCoins; 
    public event Action OnUpdateProductOnce; 
    
    private AnalyticService _analyticService;
    private ProgressService _progressService;
    private SaveLoadService _saveLoadService;

    [Inject]
    public void Construct(ProgressService progressService, SaveLoadService saveLoadService)
    {
        _progressService = progressService;
        _saveLoadService = saveLoadService;
        _analyticService = new AnalyticService(_progressService);
    }

    public void OnPurchaseCompleted(Product product)
    {
        _progressService.PlayerProgress.purchaseCounter += 1;
        
        switch (product.definition.id)
        {
            case "coins":
                ProductAddCoins();
                _analyticService.SendPurchasesCounter("coins");
                break;
            case "once":
                ProductOnce();
                _analyticService.SendPurchasesCounter("once");
                break;
        }
        
        _saveLoadService.SaveProgress();
    }

    private void ProductAddCoins()
    {
        _progressService.PlayerProgress.Coins += 100;
        OnUpdateCoins?.Invoke();
    }
    
    private void ProductOnce()
    {
        _progressService.PlayerProgress.IsOnceBuy = true;
        OnUpdateProductOnce?.Invoke();
    }
}
