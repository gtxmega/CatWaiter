using CodeBase.Logic.Actors.Actors;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.GameFactory
{
    public interface IGameFactory
    {
        GameObject CreateGameObject(string path);
        GameObject CreateGameObject(string path, Vector3 position);

        Visitor CreateVisitor(Vector3 at);
    }
}