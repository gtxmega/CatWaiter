using CodeBase.Infrastructure.Services.CoroutineRunner;
using CodeBase.Infrastructure.Services.GameFactory;
using CodeBase.Infrastructure.Services.PoolWishWidgets;
using CodeBase.Infrastructure.Services.Stand;
using Zenject;

namespace CodeBase.Infrastructure.LevelStates.States
{
    public class RegistrationServiceState : ILevelState
    {
        private readonly LevelStateMachine _stateMachine;
        private readonly ICoroutineRunner _coroutineRunner;

        private readonly IPoolWishWidgetInitialize _poolWishWidgets;
        private readonly IFoodPreparation _foodPreparation;
        private readonly IBarCounterService _barCounter;


        public RegistrationServiceState(LevelStateMachine stateMachine, DiContainer diContainer, ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _coroutineRunner = coroutineRunner;

            _barCounter = diContainer.Resolve<IBarCounterService>();
            _foodPreparation = diContainer.Resolve<IFoodPreparation>();
            _poolWishWidgets = diContainer.Resolve<IPoolWishWidgetInitialize>();
        }

        public void Enter()
        {
            _poolWishWidgets.Initialize(4);
            _foodPreparation.Initialize(_coroutineRunner);
            _barCounter.Initialize(_coroutineRunner);

            _stateMachine.Enter<SpawnEntityForLevelState>();
        }

        public void Exit()
        {
            
        }
        
        
    }
}