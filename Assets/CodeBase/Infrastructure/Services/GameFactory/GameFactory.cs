using CodeBase.Infrastructure.AssetMenagment;
using CodeBase.Logic.Actors.Actors;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private IAssets _assets;

        [Inject]
        public void Construct(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreateGameObject(string path)
        {
            GameObject objectInstance = _assets.Instantiate(path);
            return objectInstance;
        }
        
        public GameObject CreateGameObject(string path, Vector3 position)
        {
            GameObject objectInstance = _assets.Instantiate(path, position);
            return objectInstance;
        }

        public Visitor CreateVisitor(Vector3 at)
        {
            GameObject visitorObject = _assets.Instantiate(AssetsPath.VisitorPath, at);
            return visitorObject.GetComponent<Visitor>();  
        }

        public T CreateUIElement<T>(string path, Transform parent)
        {
            return  _assets.InstantiateUI<T>(path, parent);
        }
    }
}