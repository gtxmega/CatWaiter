using CodeBase.Infrastructure.Data;

namespace CodeBase.Infrastructure.Services.PersistenceProgress
{
    public interface ISavedProgress : IProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }

    public interface IProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}