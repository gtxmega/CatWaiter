using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Movements
{
    public interface IMovement
    {
        event Action OnComplite; 
        void SetMoveSpeed(float speed);
        void SetDestination(Vector3 point);
        void SetFollowing(Transform following);
        void StopFollowing();
        void DisableAgent();
        void EnableAgent();
    }
}