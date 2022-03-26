using CodeBase.Infrastructure.AssetMenagment;
using CodeBase.Infrastructure.Services.GameFactory;
using CodeBase.Logic.Actors.Actors;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.LevelStates.States
{
    public class SpawnEntityForLevelState : ILevelState
    {
        private static string PlayerSpawnPointTag = "PlayerSpawnPoint";
        
        private readonly LevelStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;

        public SpawnEntityForLevelState(LevelStateMachine stateMachine, DiContainer diContainer)
        {
            _stateMachine = stateMachine;

            _gameFactory = diContainer.Resolve<IGameFactory>();
        }

        public void Enter()
        {
            SpawnCatWaiter();
            
            _stateMachine.Enter<LoadLevelProgressState>();
        }

        public void Exit()
        {
            
        }

        private void SpawnCatWaiter()
        {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag(PlayerSpawnPointTag);
            CatAwaiter catAwaiter = _gameFactory.CreateEntity<CatAwaiter>(AssetsPath.CatWaiterPath, spawnPoint.transform.position);
        }
    }
}