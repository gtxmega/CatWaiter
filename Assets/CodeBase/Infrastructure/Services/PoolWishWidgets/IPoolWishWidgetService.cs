using CodeBase.Logic.UI.WishItemWidget;

namespace CodeBase.Infrastructure.Services.PoolWishWidgets
{
    public interface IPoolWishWidgetService
    {
        WishItemWidget GetWishItemWidget();
        void ReturnWishItemWidget(WishItemWidget wishItemWidget);
    }

    public interface IPoolWishWidgetInitialize
    {
        void Initialize(int countWidgets);
    }
}