using CodeBase.Infrastructure.Services.CoroutineRunner;
using CodeBase.Infrastructure.Services.GameFactory;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Stand
{
    public class FoodPreparation : IFoodPreparation
    {
        private readonly IGameFactory _gameFactory;
        
        private ICoroutineRunner _coroutineRunner;

        private Coroutine _preparingFoodProcess;

        public FoodPreparation(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Initialize(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
    }
}