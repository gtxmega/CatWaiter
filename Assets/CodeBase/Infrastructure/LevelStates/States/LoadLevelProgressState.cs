using CodeBase.Infrastructure.Services.CoroutineRunner;
using CodeBase.Infrastructure.Services.PersistenceProgress;
using CodeBase.Infrastructure.Services.PoolWishWidgets;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.Stand;
using Zenject;

namespace CodeBase.Infrastructure.LevelStates.States
{
    public class LoadLevelProgressState : ILevelState
    {
        private readonly LevelStateMachine _stateMachine;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IPoolWishWidgetInitialize _poolWishWidgets;
        private readonly IBarCounterService _barCounterService;

        
        private IPersistenceProgressServices _persistenceProgress;
        private ISaveLoadService _saveLoadService;

        public LoadLevelProgressState(LevelStateMachine stateMachine, DiContainer diContainer)
        {
            _stateMachine = stateMachine;
            
            _persistenceProgress = diContainer.Resolve<IPersistenceProgressServices>();
            _saveLoadService = diContainer.Resolve<ISaveLoadService>();
        }


        public void Enter()
        {
            LoadPlayerProgress();
            
            _stateMachine.Enter<SceneLoopState>();
        }

        public void Exit()
        {
            
        }

        private void LoadPlayerProgress()
        {
            _persistenceProgress.Progress = _saveLoadService.LoadProgress();
        }
        
    }
}