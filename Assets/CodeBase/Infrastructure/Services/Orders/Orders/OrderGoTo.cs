using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Orders.Orders
{
    public class OrderGoTo : MonoBehaviour, IOrder
    {
        
        
        public event Action CompleteOrder;
        public event Action FailedOrder;


        public bool IsComplite { get; }

        public void EnterOrder()
        {

        }

        public void ExitOrder()
        {
            
        }
    }

}