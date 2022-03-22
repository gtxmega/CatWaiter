using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.AssetMenagment
{
    public class AssetProvider : IAssets
    {
        [Inject] private DiContainer _diContainer;
        
        public GameObject Instantiate(string filePath)
        {
            return SpawnFromDI(filePath, Vector3.zero);
        }

        public GameObject Instantiate(string filePath, Vector3 at)
        {
            return SpawnFromDI(filePath, at);
        }

        private GameObject SpawnFromDI(string path, Vector3 position)
        {
            return _diContainer.InstantiatePrefabResource(path, position, quaternion.identity, null);
        }
    }
}