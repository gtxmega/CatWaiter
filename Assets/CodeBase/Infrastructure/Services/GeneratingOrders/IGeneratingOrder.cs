using System;
using CodeBase.Logic.Actors.Actors;

namespace CodeBase.Infrastructure.Services.GeneratingOrders
{
    public interface IGeneratingOrder
    {
        void ViewingWishList(Visitor visitor, Action<WishListItem> viewed);
    }
}