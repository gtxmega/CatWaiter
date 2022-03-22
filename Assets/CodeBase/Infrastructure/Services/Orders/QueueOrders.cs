using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.Services.Orders
{
    public class QueueOrders
    {
        private Queue<IOrder> _queueOrders;
        private Dictionary<Type, IOrder> _orders;


        public void AddOrder(IOrder order)
        {
            
        }
        
        
    }
}