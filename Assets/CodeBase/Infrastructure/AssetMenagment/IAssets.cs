using UnityEngine;

namespace CodeBase.Infrastructure.AssetMenagment
{
    public interface IAssets
    {
        GameObject Instantiate(string filePath);
        GameObject Instantiate(string filePath, Vector3 at);
        T InstantiateEntity<T>(string path, Transform parent);
        T InstantiateEntity<T>(string path, Vector3 position);
    }
}