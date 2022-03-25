using CodeBase.Infrastructure.Services.Movements;
using CodeBase.Infrastructure.Services.Selector;
using CodeBase.Logic.Table;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Actors.Actors
{
    public class Visitor : Actor, ISelectable
    {
        private IMovement _movement;

        [Inject]
        private void Construct(IMovement movement)
        {
            _movement = movement;
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

        public void SitDownOnChair(Chair chair)
        {
            _movement.DisableAgent();
            ThisTransform.position = chair.ThisTransform.position;
            ThisTransform.rotation = chair.ThisTransform.rotation;
        }
    }
}