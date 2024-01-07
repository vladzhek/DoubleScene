using System;
using DefaultNamespace;

namespace Services
{
    public class ProgressService
    {
        public PlayerProgress PlayerProgress { get; private set; }
        public bool IsLoaded { get; set; } = false;
        public event Action OnLoaded;

        public void InitializeProgress(PlayerProgress playerProgress)
        {
            PlayerProgress = playerProgress;

            IsLoaded = true;
            OnLoaded?.Invoke();
        }
    }
}