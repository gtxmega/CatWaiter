using CodeBase.Infrastructure.Services.Orders;
using Zenject;

namespace CodeBase.Logic.Actors.Actors
{
    public class CatAwaiter : Actor
    {
        private QueueOrders _queueOrders;

        [Inject]
        private void Construct()
        {
            _queueOrders = new QueueOrders();
        }

        public void AddOrder<TOrder>() where TOrder : IOrder
        {
            
        }
    }
}