using CodeBase.Logic.Actors.Actors;

namespace CodeBase.Infrastructure.Services.QueueVisitors
{
    public interface IQueueVisitors
    {
        Visitor DequeueVisitor();
        bool IsFirstInQueue(Visitor visitor);
    }
}