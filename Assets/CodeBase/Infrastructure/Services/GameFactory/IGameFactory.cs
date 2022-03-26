using System.Collections.Generic;
using CodeBase.Infrastructure.Services.PersistenceProgress;
using CodeBase.Logic.Actors.Actors;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.GameFactory
{
    public interface IGameFactory
    {
        GameObject CreateGameObject(string path);
        GameObject CreateGameObject(string path, Vector3 position);

        Visitor CreateVisitor(Vector3 at);

        T CreateEntity<T>(string path, Transform parent);
        T CreateEntity<T>(string path, Vector3 position);
        List<ISavedProgress> ProgressWriters { get; }
        List<IProgressReader> ProgressReaders { get; }
    }
}