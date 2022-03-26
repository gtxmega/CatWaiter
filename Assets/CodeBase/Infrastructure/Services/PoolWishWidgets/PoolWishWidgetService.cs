using System.Collections.Generic;
using CodeBase.Infrastructure.AssetMenagment;
using CodeBase.Infrastructure.Services.GameFactory;
using CodeBase.Logic.UI.WishItemWidget;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.PoolWishWidgets
{
    public class PoolWishWidgetService : MonoBehaviour, IPoolWishWidgetService, IPoolWishWidgetInitialize
    {
        [SerializeField] private RectTransform _widgetsParentTransform;

        private int _countWidgets;
        private Queue<WishItemWidget> _poolWidgetsQueue;
        
        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        public void Initialize(int countWidgets)
        {
            _countWidgets = countWidgets;
            _poolWidgetsQueue = new Queue<WishItemWidget>();
            
            for (int i = 0; i < _countWidgets; ++i)
            {
                AddWidgetToPool();
            }
        }

        public WishItemWidget GetWishItemWidget()
        {
            if (_poolWidgetsQueue.Count == 0)
            {
                AddWidgetToPool();
                return _poolWidgetsQueue.Dequeue();
            }

            return _poolWidgetsQueue.Dequeue();
        }

        public void ReturnWishItemWidget(WishItemWidget wishItemWidget)
        {
            wishItemWidget.Hide();
            _poolWidgetsQueue.Enqueue(wishItemWidget);
        }

        private void AddWidgetToPool()
        {
            WishItemWidget wishWidget = _gameFactory.CreateUIElement<WishItemWidget>(
                AssetsPath.WishItemWidgetPath, _widgetsParentTransform);

            ReturnWishItemWidget(wishWidget);
        }
    }
}