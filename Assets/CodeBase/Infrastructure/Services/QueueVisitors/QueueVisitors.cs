using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services.GameFactory;
using CodeBase.Logic.Actors.Actors;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.QueueVisitors
{
    public class QueueVisitors : MonoBehaviour
    {
        [SerializeField] private int _maxQueueCount;
        [SerializeField] private float _generalTimeSpawn;
        [SerializeField] private float _visitorTimeSpawn;

        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _enterPoint;

        [SerializeField] private Visitor _visitorPrefab;

        private List<Visitor> _visitors = new List<Visitor>();

        private float _generalTimer;
        private Coroutine _spawnCoroutine;
        private IGameFactory _gameFactory;

        
        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Start()
        {
            _spawnCoroutine = StartCoroutine(GeneratingVisitors());
        }

        private void Update()
        {
            if (_generalTimer <= _generalTimeSpawn)
            {
                _generalTimer += Time.deltaTime;
            }
            else
            {
                if(_spawnCoroutine != null)
                    StopCoroutine(_spawnCoroutine);
            }
        }

        public Visitor DequeueVisitor()
        {
            Visitor visitor = _visitors[0];
            
            _visitors.RemoveAt(0);
            
            ResizeQueue();
            
            return visitor;
        }

        public bool IsFirstInQueue(Visitor visitor)
        {
            return _visitors.IndexOf(visitor) == 0;
        }

        private IEnumerator GeneratingVisitors()
        {
            float visitorTimer = _visitorTimeSpawn;

            while (true)
            {
                while (visitorTimer >= 0.0f)
                {
                    visitorTimer -= Time.deltaTime;
                    yield return null;
                }

                visitorTimer = _visitorTimeSpawn;

                Visitor visitor = _gameFactory.CreateVisitor(_spawnPoint.position);

                if (_visitors.Count > 0)
                {
                    visitor.SetFollowTransform(_visitors[_visitors.Count - 1].ThisTransform);
                }
                else
                {
                    visitor.SetDestination(_enterPoint.position);
                }

                _visitors.Add(visitor);
            }

        }

        private void ResizeQueue()
        {
            for (int i = 0; i < _visitors.Count; ++i)
            {
                if (i == 0)
                {
                    _visitors[i].SetDestination(_spawnPoint.position);
                    continue;
                }
                _visitors[i].SetFollowTransform(_visitors[i - 1].ThisTransform);
            }
        }
    }
}