using CodeBase.Infrastructure.LevelStates;
using CodeBase.Infrastructure.LevelStates.States;
using CodeBase.Infrastructure.Services.CoroutineRunner;
using UnityEngine;
using Zenject;

public class SceneBootstraper : MonoBehaviour, ICoroutineRunner
{
    [Inject] private DiContainer _diContainer;
    
    private LevelStateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new LevelStateMachine(_diContainer, this);
        _stateMachine.Enter<LoadLevelState>();
    }
}
