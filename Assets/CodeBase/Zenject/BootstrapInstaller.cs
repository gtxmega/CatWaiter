using CodeBase.Infrastructure.AssetMenagment;
using CodeBase.Infrastructure.Services.GameFactory;
using CodeBase.Infrastructure.Services.GeneratingOrders;
using CodeBase.Infrastructure.Services.Movements;
using CodeBase.Infrastructure.Services.PersistenceProgress;
using CodeBase.Infrastructure.Services.PoolWishWidgets;
using CodeBase.Infrastructure.Services.QueueVisitors;
using CodeBase.Infrastructure.Services.RandomService;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.Selector;
using CodeBase.Infrastructure.Services.Stand;
using CodeBase.Infrastructure.Services.UIFollow;
using CodeBase.Infrastructure.Services.WishList;
using Zenject;

namespace CodeBase.Zenject
{
    public class BootstrapInstaller : MonoInstaller
    {
        public SelectorService _selectorService;
        public QueueVisitors _queueVisitors;
        public WishListService _wishListService;
        public GeneratingOrder _generatingOrder;
        public UIFollowService _uiFollowService;
        public PoolWishWidgetService _poolWishWidgetService;
        
        
        private BarCounterService barCounterService;
        private FoodPreparation foodPreparation;
        private PersistenceProgress _persistenceProgress;
        private SaveLoadService _saveLoadService;


        public override void InstallBindings()
        {
            //General services
            SelectorService();
            QueueVisitors();
            WishList();
            UIFollow();

            //Generators data
            AssetProvider();
            GameFactory();
            RandomService();
            GenerationOrder();
            PoolWishWidgets();

            SaveLoadServiceRegistration();
            BarCounterRegistration();

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
        
        private void WishList()
        {
            Container.Bind<IWishListService>()
                .To<WishListService>()
                .FromInstance(_wishListService)
                .AsSingle()
                .NonLazy();
        }
        
        private void UIFollow()
        {
            Container.Bind<IUIFollowService>()
                .To<UIFollowService>()
                .FromInstance(_uiFollowService)
                .AsSingle()
                .NonLazy();
        }
        
        private void BarCounterRegistration()
        {
            foodPreparation = new FoodPreparation(Container.Resolve<IGameFactory>());
            barCounterService = new BarCounterService(foodPreparation);

            Container
                .Bind<IFoodPreparation>()
                .To<FoodPreparation>()
                .FromInstance(foodPreparation)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IBarCounterService>()
                .To<BarCounterService>()
                .FromInstance(barCounterService)
                .AsSingle()
                .NonLazy();
        }
        
        private void SaveLoadServiceRegistration()
        {
            _persistenceProgress = new PersistenceProgress();
            _saveLoadService = new SaveLoadService(_persistenceProgress, Container.Resolve<IGameFactory>());

            Container
                .Bind<IPersistenceProgressServices>()
                .To<PersistenceProgress>()
                .FromInstance(_persistenceProgress)
                .AsSingle();

            Container
                .Bind<ISaveLoadService>()
                .To<SaveLoadService>()
                .FromInstance(_saveLoadService)
                .AsSingle();
        }

        private void RandomService()
        {
            Container.Bind<IRandomizer>()
                .To<Randomizer>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void GenerationOrder()
        {
            Container.Bind<IGeneratingOrder>()
                .To<GeneratingOrder>()
                .FromInstance(_generatingOrder)
                .AsSingle()
                .NonLazy();
        }

        private void PoolWishWidgets()
        {
            Container.Bind<IPoolWishWidgetService>()
                .To<PoolWishWidgetService>()
                .FromInstance(_poolWishWidgetService)
                .NonLazy();
            
            Container.Bind<IPoolWishWidgetInitialize>()
                .To<PoolWishWidgetService>()
                .FromInstance(_poolWishWidgetService)
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