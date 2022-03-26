using CodeBase.Infrastructure.Services.CoroutineRunner;

namespace CodeBase.Infrastructure.Services.Stand
{
    public interface IFoodPreparation
    {
        void Initialize(ICoroutineRunner coroutineRunner);
    }
}