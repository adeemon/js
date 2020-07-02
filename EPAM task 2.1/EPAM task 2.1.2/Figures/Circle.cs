using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_2._1._2
{
    class Circle : Figure
    {
        private int _r;

        public int R
        {
            get { return _r; }
            set
            {
                if (value > 0)
                {
                    _r = value;
                }
                else
                {
                    int temp = value;
                    while (temp <= 0)
                    {
                        Console.WriteLine("Радиус должен быть положительным числом. Введите корректное значение.");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    _r = value;
                }
            }
        }
        public Circle(int InputX, int InputY, int InputR)
        {
            X = InputX;
            Y = InputY;
            int temp = InputR;
            while (temp <= 0)
            {
                Console.WriteLine("Радиус должен быть положительным числом. Введите корректное значение.");
                temp = Convert.ToInt32(Console.ReadLine());
            }
            R = temp;
        }
        public override void PrintFigure()
        {
            Console.WriteLine("Окружность с параметрами:\nКоордината центра x={0}, координата центра y={1} и радиус r={2}", X, Y, R);
        }

    }
}
