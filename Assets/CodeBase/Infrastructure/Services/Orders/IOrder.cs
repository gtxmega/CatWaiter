using System;
using CodeBase.Logic.Actors.Actors;

namespace CodeBase.Infrastructure.Services.Orders
{
    public interface IOrder
    {
        public event Action CompleteOrder;
        public event Action FailedOrder;
        
        public bool IsComplite { get; }
        
        public void EnterOrder();
        public void ExitOrder();
    }
}