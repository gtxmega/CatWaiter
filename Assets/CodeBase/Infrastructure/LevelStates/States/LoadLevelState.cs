using Zenject;

namespace CodeBase.Infrastructure.LevelStates.States
{
    public class LoadLevelState : ILevelState
    {
        private readonly LevelStateMachine _stateMachine;
        private readonly DiContainer _diContainer;

        public LoadLevelState(LevelStateMachine stateMachine, DiContainer diContainer)
        {
            _stateMachine = stateMachine;
            _diContainer = diContainer;
        }


        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}