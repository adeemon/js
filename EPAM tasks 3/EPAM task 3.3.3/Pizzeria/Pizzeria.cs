using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EPAM_task_3._3._3.Pizzeria
{
    class Pizzeria
    {
        public event Action<Orders> OnNewOrder = delegate { };
        public event Action<Orders> OnOrderCompleted = delegate { };

        public List<Orders> logOfOrders;
        public List<Orders> currentOrders;

        public Pizzeria ()
        {
            logOfOrders = new List<Orders>();
            currentOrders = new List<Orders>();
            this.OnNewOrder += LogOrder;
            this.OnOrderCompleted += CompletedOrderShowing;
        }

        public void AddOrder()
        {
            var userChoise = User.UserChoose();
            Orders newOrder = new Orders(userChoise, logOfOrders.Count+1);
            OnNewOrder?.Invoke(newOrder);
            currentOrders.Add(newOrder);
        }

        public void CurrentOrdersPrint()
        {
            foreach (var order in currentOrders)
            {
                OutputHandler.ConsolePrint(order.Number);
            }
        }

        public void OrdersCooking()
        {
            OutputHandler.ConsolePrint("We are working!");
            Thread.Sleep(500);
            for (int i=0; i<currentOrders.Count; ++i)
            {
                currentOrders[i].TimeToCook--;
                if (currentOrders[i].TimeToCook == 0)
                {
                    RemoveOrder(currentOrders[i]);
                }
            }

        }

        public void RemoveOrder (Orders order)
        {
            OnOrderCompleted?.Invoke(order);
            currentOrders.Remove(order);
        }

        private void CompletedOrderShowing (Orders order)
        {
            Console.WriteLine("Please, take the order number {0}", order.Number);
        }

        private void LogOrder (Orders newOrder)
        {
            logOfOrders.Add(newOrder);
        }
    }
}
