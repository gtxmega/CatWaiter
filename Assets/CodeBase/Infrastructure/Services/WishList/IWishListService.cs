namespace CodeBase.Infrastructure.Services.WishList
{
    public interface IWishListService
    {
        WishListItem GetWishItem(int index);
        WishListItem GetRandomWishItem();
    }
}