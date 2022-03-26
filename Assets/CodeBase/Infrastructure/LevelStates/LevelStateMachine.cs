using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.LevelStates.States;
using CodeBase.Infrastructure.Services.CoroutineRunner;
using Zenject;

namespace CodeBase.Infrastructure.LevelStates
{
    public class LevelStateMachine
    {
        private Dictionary<Type, ILevelState> _states;
        private ILevelState _currentState;
        
        public LevelStateMachine(DiContainer diContainer, ICoroutineRunner coroutineRunner)
        {
            _states = new Dictionary<Type, ILevelState>
            {
                [typeof(RegistrationServiceState)] = new RegistrationServiceState(this, diContainer, coroutineRunner),
                [typeof(SpawnEntityForLevelState)] = new SpawnEntityForLevelState(this, diContainer),
                [typeof(LoadLevelProgressState)] = new LoadLevelProgressState(this, diContainer),
                [typeof(SceneLoopState)] = new SceneLoopState(this)
            };
        }

        public void Enter<TLevelState>() where TLevelState : ILevelState
        {
            if (_currentState != null)
                _currentState?.Exit();

            ILevelState state = _states[typeof(TLevelState)];
            _currentState = state;
            state.Enter();
        }
    }
}
