using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_3._3._3.Pizzeria
{
    static class User
    {
        public static int[] UserChoose ()
        {
            OutputHandler.MenuPrint();
            List <int> choosedPizzas = new List<int>();
            int choose = 0;
            while (choose!= 6)
            {
                Int32.TryParse(Console.ReadLine(),out choose);
                if (choose <= 4 && choose >= 1)
                {
                    choosedPizzas.Add(choose);
                }
            }
            return choosedPizzas.ToArray();
        }
    }
}
