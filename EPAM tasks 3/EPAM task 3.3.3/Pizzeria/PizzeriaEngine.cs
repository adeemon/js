using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_3._3._3.Pizzeria
{
    static class PizzeriaEngine
    {
        public static void Start()
        {
            {
                var pizzeria = new Pizzeria();

                pizzeria.AddOrder();

                while (pizzeria.currentOrders.Any())
                {
                    pizzeria.OrdersCooking();
                }


            }

        }
    }
}
