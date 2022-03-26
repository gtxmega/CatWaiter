using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Data.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Game/Wish list/Wish list", fileName = "Wish list data")]
    public class WishListData : ScriptableObject
    {
        [Header("Wish list items")]
        [SerializeField] private WishListItem[] _wishListItems;

        public WishListItem GetWishItem(int index)
        {
            if (index < 0 || index > _wishListItems.Length)
                throw new ArgumentOutOfRangeException(nameof(_wishListItems));
                
            return _wishListItems[index];
        }

        public int GetWishCounts()
        {
            return _wishListItems.Length;
        }
    }
}
