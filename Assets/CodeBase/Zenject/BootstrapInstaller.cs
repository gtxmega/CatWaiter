using CodeBase.Infrastructure.AssetMenagment;
using CodeBase.Infrastructure.Services.GameFactory;
using CodeBase.Infrastructure.Services.Movements;
using Zenject;

namespace CodeBase.Zenject
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //General services
            AssetProvider();
            GameFactory();
            
            //Actors services
            Movement();
        }

        private void AssetProvider()
        {
            Container.Bind<IAssets>()
                .To<AssetProvider>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void GameFactory()
        {
            Container.Bind<IGameFactory>()
                .To<GameFactory>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void Movement()
        {
            Container
                .Bind<IMovement>()
                .To<NavMeshMovement>()
                .FromComponentInParents();
        }
    }
}