using CodeBase.Infrastructure.Services.PoolWishWidgets;
using Zenject;

namespace CodeBase.Infrastructure.LevelStates.States
{
    public class LoadLevelState : ILevelState
    {
        private readonly LevelStateMachine _stateMachine;
        private readonly DiContainer _diContainer;
        private readonly IPoolWishWidgetInitialize _poolWishWidgets;

        public LoadLevelState(LevelStateMachine stateMachine, DiContainer diContainer)
        {
            _stateMachine = stateMachine;
            _diContainer = diContainer;

            _poolWishWidgets = diContainer.Resolve<IPoolWishWidgetInitialize>();
        }


        public void Enter()
        {
            _poolWishWidgets.Initialize(4);
        }

        public void Exit()
        {
            
        }
    }
}