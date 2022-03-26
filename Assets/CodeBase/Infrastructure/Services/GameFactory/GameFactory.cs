using System.Collections.Generic;
using CodeBase.Infrastructure.AssetMenagment;
using CodeBase.Infrastructure.Services.PersistenceProgress;
using CodeBase.Logic.Actors.Actors;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private IAssets _assets;
        
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();
        public List<IProgressReader> ProgressReaders { get; } = new List<IProgressReader>();

        [Inject]
        public void Construct(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreateGameObject(string path)
        {
            GameObject objectInstance = _assets.Instantiate(path);
            AddToProgressSaving(objectInstance);
            
            return objectInstance;
        }
        
        public GameObject CreateGameObject(string path, Vector3 position)
        {
            GameObject objectInstance = _assets.Instantiate(path, position);
            AddToProgressSaving(objectInstance);
            
            return objectInstance;
        }

        public Visitor CreateVisitor(Vector3 at)
        {
            GameObject visitorObject = _assets.Instantiate(AssetsPath.VisitorPath, at);
            AddToProgressSaving(visitorObject);
            
            return visitorObject.GetComponent<Visitor>();  
        }

        public T CreateEntity<T>(string path, Transform parent)
        {
            T entity = _assets.InstantiateEntity<T>(path, parent);
            
            MonoBehaviour mono = entity as MonoBehaviour;
            AddToProgressSaving(mono.gameObject);
            
            return  entity;
        }
        
        public T CreateEntity<T>(string path, Vector3 position)
        {
            T entity = _assets.InstantiateEntity<T>(path, position);
            
            MonoBehaviour mono = entity as MonoBehaviour;
            AddToProgressSaving(mono.gameObject);
            
            return  entity;
        }
        
        private void AddToProgressSaving(GameObject target)
        {
            foreach (IProgressReader progress in target.GetComponentsInChildren<IProgressReader>())
            {
                if (progress is ISavedProgress savedProgress)
                    ProgressWriters.Add(savedProgress);

                ProgressReaders.Add(progress);
            }
        }
    }
}