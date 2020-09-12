using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_3._3._3.Pizzeria
{
    enum TypesOfPizza
    {
        Margherita = 1,
        Pepperoni = 2,
        Hawaiian = 3,
        Meat = 4
    }

    class Pizza
    {
        public TypesOfPizza Type { get; set; }

        public Pizza(int userChoose)
        {
            Type = (TypesOfPizza)userChoose;
        }
    }
}
