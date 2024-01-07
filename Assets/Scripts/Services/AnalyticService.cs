using System.Collections.Generic;
using GameAnalyticsSDK;

namespace Services
{
    public class AnalyticService
    {
        private ProgressService _progressService;
        public AnalyticService(ProgressService progressService)
        {
            _progressService = progressService;
        }

        public void SendLevelVisit(string level)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete,"VisitOn" + level );
        }
        
        public void SendPurchasesCounter(string purchase)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete,"Purchases",
                new Dictionary<string, object>
                {
                    {purchase, _progressService.PlayerProgress.purchaseCounter}
                });
        }
    }
}