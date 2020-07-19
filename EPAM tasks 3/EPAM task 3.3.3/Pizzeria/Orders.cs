using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_3._3._3.Pizzeria
{
    class Orders
    {
        public int Number { get; set; }
        public int TimeToCook { get; set; }

        List<Pizza> Pizzas;

        public delegate void СookingHandler(string message);
        public event СookingHandler Notify;

        public Orders(int [] orderedPizzasArray, int orderNumber)
        {
            Pizzas = new List<Pizza>();
            Number = orderNumber;
            this.Notify += OutputHandler.ConsolePrint;
            foreach (var choosedPizza in orderedPizzasArray)
            {
                Notify?.Invoke("New pizza started to cook");
                Pizzas.Add(new Pizza(choosedPizza));
            }
            TimeToCook = orderedPizzasArray.Length * 5;

            this.Notify -= OutputHandler.ConsolePrint;
        }
    }
}
