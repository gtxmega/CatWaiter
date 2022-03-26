using CodeBase.Infrastructure.Data.ScriptableObjects;
using CodeBase.Infrastructure.Services.RandomService;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.WishList
{
    public class WishListService : MonoBehaviour, IWishListService
    {
        [SerializeField] private WishListData _wishListData;
        
        private IRandomizer _randomizer;

        [Inject]
        private void Construct(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }
        public WishListItem GetWishItem(int index)
        {
            return _wishListData.GetWishItem(index);
        }

        public WishListItem GetRandomWishItem()
        {
            int countWishItems = _wishListData.GetWishCounts();
            int randomIndex = _randomizer.GetRandomInt(0, countWishItems - 1);
            return _wishListData.GetWishItem(randomIndex);
        }
    }
}