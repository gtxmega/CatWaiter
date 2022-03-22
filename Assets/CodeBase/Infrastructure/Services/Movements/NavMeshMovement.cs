using System;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Infrastructure.Services.Movements
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavMeshMovement : MonoBehaviour, IMovement
    {
        public event Action OnComplite;
        

        [Header("Maybe is null")]
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private Transform _followingTarget;

        private void Start()
        {
            if (_navMeshAgent == null)
                _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (_followingTarget != null)
                _navMeshAgent.SetDestination(_followingTarget.position);
        }

        public void SetMoveSpeed(float speed)
        {
            _navMeshAgent.speed = speed;
        }

        public void SetDestination(Vector3 point)
        {
            _navMeshAgent.SetDestination(point);
        }

        public void SetFollowing(Transform following)
        {
            _followingTarget = following;
        }

        public void StopFollowing()
        {
            _followingTarget = null;
        }
    }
}