namespace CodeBase.Infrastructure.LevelStates.States
{
    public class SceneLoopState : ILevelState
    {
        private readonly LevelStateMachine _stateMachine;

        public SceneLoopState(LevelStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}