using CodeBase.Infrastructure.Services.CoroutineRunner;

namespace CodeBase.Infrastructure.Services.Stand
{
    public class BarCounterService : IBarCounterService
    {
        private readonly IFoodPreparation _foodPreparation;
        
        private ICoroutineRunner _coroutineRunner;

        public BarCounterService(IFoodPreparation foodPreparation)
        {
            _foodPreparation = foodPreparation;
        }

        public void Initialize(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
    }
}