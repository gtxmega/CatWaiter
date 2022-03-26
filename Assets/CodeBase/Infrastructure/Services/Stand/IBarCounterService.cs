using CodeBase.Infrastructure.Services.CoroutineRunner;

namespace CodeBase.Infrastructure.Services.Stand
{
    public interface IBarCounterService
    {
        void Initialize(ICoroutineRunner coroutineRunner);
    }
}