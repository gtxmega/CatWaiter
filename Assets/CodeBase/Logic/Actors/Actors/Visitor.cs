using CodeBase.Infrastructure.Services.GeneratingOrders;
using CodeBase.Infrastructure.Services.Movements;
using CodeBase.Infrastructure.Services.Selector;
using CodeBase.Logic.Table;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Actors.Actors
{
    public class Visitor : Actor, ISelectable
    {
        public float TimeViewWishList => _timerViewWishList;
        
        [Header("Wish list")]
        [SerializeField] private float _timerViewWishList;

        private LittleTable _littleTable;

        private IMovement _movement;
        private IGeneratingOrder _generatingOrder;
        private Chair _chair;


        [Inject]
        private void Construct(IMovement movement, IGeneratingOrder generatingOrder)
        {
            _movement = movement;
            _generatingOrder = generatingOrder;
        }

        public void Initialize(float timeViewWishList)
        {
            _timerViewWishList = timeViewWishList;
        }
        
        public void SetDestination(Vector3 point)
        {
            _movement.SetDestination(point);
        }

        public void SetFollowTransform(Transform following)
        {
            _movement.SetFollowing(following);
        }

        public void Selected(CatAwaiter catAwaiter)
        {
            
        }

        public void Unselect()
        {
            
        }

        public void SitDownOnLittleTable(LittleTable littleTable)
        {
            _movement.DisableAgent();
            
            ThisTransform.position = _chair.ThisTransform.position;
            ThisTransform.rotation = _chair.ThisTransform.rotation;
            
            StartViewingWishList();
        }

        public void SetChair(Chair chair)
        {
            _chair = chair;
        }

        private void StartViewingWishList()
        {
            _generatingOrder.ViewingWishList(this, _chair.OnViewedWishList);
        }

        public void StandUp()
        {
            _chair = null;
        }
        
        
    }
}