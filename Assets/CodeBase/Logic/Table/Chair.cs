using CodeBase.Infrastructure.Services.PoolWishWidgets;
using CodeBase.Infrastructure.Services.UIFollow;
using CodeBase.Logic.Actors.Actors;
using CodeBase.Logic.UI.WishItemWidget;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Table
{
    public class Chair : MonoBehaviour
    {
        [Header("Widget parameters")] 
        [SerializeField] private Vector2 _widgetOffset;
        
        public Transform ThisTransform { get; private set; }
        public bool IsFree => _isFree;

        private bool _isFree;
        private Visitor _currentVisitor;
        private IUIFollowService _uiFollowService;
        private IPoolWishWidgetService _poolWishWidgets;

        [Inject]
        private void Construct(IUIFollowService uiFollowService, IPoolWishWidgetService poolWishWidgetService)
        {
            _uiFollowService = uiFollowService;
            _poolWishWidgets = poolWishWidgetService;
        }
        
        private void Start()
        {
            ThisTransform = GetComponent<Transform>();
            _isFree = true;
        }

        public void SitDownVisitor(Visitor visitor)
        {
            _currentVisitor = visitor;
            _isFree = false;
        }

        public void StandUpVisitor()
        {
            _currentVisitor = null;
            _isFree = true;
        }
        
        public void OnViewedWishList(WishListItem wishItem)
        {
            WishItemWidget wishItemWidget = _poolWishWidgets.GetWishItemWidget();
            
            wishItemWidget.SetWidgetSprite(wishItem.Icone);
            
            _uiFollowService.TryAddUIFollowObject(wishItemWidget.OwnerRectTransform, ThisTransform, _widgetOffset);
            
            wishItemWidget.Show();
        }
    }
}