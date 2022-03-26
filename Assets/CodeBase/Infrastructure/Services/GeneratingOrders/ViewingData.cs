using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.GeneratingOrders
{
    public class ViewingData
    {
        private readonly Action<WishListItem> _onViewing;
        private readonly WishListItem _wishListItem;
        
        private float _timer;

        public ViewingData(Action<WishListItem> onViewing, float timer, WishListItem wishListItem)
        {
            _onViewing = onViewing;
            _timer = timer;
            _wishListItem = wishListItem;
        }

        public void UpdateTimer(float deltaTime)
        {
            _timer -= deltaTime;
        }

        public bool CheckTimer()
        {
            return _timer <= 0.0f;
        }

        public void ExecuteCallBack()
        {
            _onViewing?.Invoke(_wishListItem);
        }
        
        
    }
}