using CodeBase.Infrastructure.AssetMenagment;
using CodeBase.Infrastructure.Services.GameFactory;
using CodeBase.Infrastructure.Services.Movements;
using CodeBase.Infrastructure.Services.QueueVisitors;
using CodeBase.Infrastructure.Services.Selector;
using Zenject;

namespace CodeBase.Zenject
{
    public class BootstrapInstaller : MonoInstaller
    {
        public SelectorService _selectorService;
        public QueueVisitors _queueVisitors;


        public override void InstallBindings()
        {
            //General services
            AssetProvider();
            GameFactory();
            SelectorService();
            QueueVisitors();

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

        private void SelectorService()
        {
            Container.Bind<ISelectorService>()
                .To<SelectorService>()
                .FromInstance(_selectorService)
                .AsSingle()
                .NonLazy();
        }
        
        private void QueueVisitors()
        {
            Container.Bind<IQueueVisitors>()
                .To<QueueVisitors>()
                .FromInstance(_queueVisitors)
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