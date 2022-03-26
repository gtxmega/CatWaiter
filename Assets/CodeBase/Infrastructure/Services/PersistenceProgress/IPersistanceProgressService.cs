using CodeBase.Infrastructure.Data;

namespace CodeBase.Infrastructure.Services.PersistenceProgress
{
    public interface IPersistenceProgressServices
    {
        PlayerProgress Progress { get; set; }
    }
}