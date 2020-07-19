using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_3._3._3.Pizzeria
{
    enum TypesOfPizza
    {
        Margherita,
        Pepperoni,
        Hawaiian,
        Meat
    }

    class Pizza
    {
        public TypesOfPizza Type { get; set; }

        public Pizza(int userChoose)
        {
            switch (userChoose)
            {
                case 1:
                    Type = TypesOfPizza.Margherita;
                    break;
                case 2:
                    Type = TypesOfPizza.Pepperoni;
                    break;
                case 3:
                    Type = TypesOfPizza.Hawaiian;
                    break;
                case 4:
                    Type = TypesOfPizza.Meat;
                    break;
            }
        }
    }
}
