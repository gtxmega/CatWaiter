using CodeBase.Logic.Actors.Actors;

namespace CodeBase.Infrastructure.Services.Selector
{
    public interface ISelectable
    {
        void Selected(CatAwaiter catAwaiter);
        void Unselect();
    }
}