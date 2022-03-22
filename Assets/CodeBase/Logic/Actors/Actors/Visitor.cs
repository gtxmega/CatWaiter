using CodeBase.Infrastructure.Services.Movements;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Actors.Actors
{
    public class Visitor : Actor
    {
        private IMovement _movement;

        [Inject]
        private void Cunstruct(IMovement movement)
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
    }
}