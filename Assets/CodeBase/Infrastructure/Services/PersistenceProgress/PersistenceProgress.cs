using CodeBase.Infrastructure.Data;

namespace CodeBase.Infrastructure.Services.PersistenceProgress
{
    public class PersistenceProgress : IPersistenceProgressServices
    {
        public PlayerProgress Progress {get; set;}
    }
}