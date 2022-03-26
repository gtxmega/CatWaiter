using CodeBase.Infrastructure.Data;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}