using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_2._1._2
{
    class Square : Figure
    {
        private int _height;

        public int Height
        {
            get { return _height; }
            set
            {
                if (value > 0)
                {
                    _height = value;
                }
                else
                {
                    int temp = value;
                    while (temp <= 0)
                    {
                        Console.WriteLine("Сторона не может быть равна или меньше нуля. Введите корректное значение");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    _height = temp;
                }
            }
        }

        public Square(int InputX, int InputY, int InputHeight)
        {
            X = InputX;
            Y = InputY;
            int temp = InputHeight;
            while (temp <= 0)
            {
                Console.WriteLine("Сторона не может быть равна или меньше нуля. Введите корректное значение");
                temp = Convert.ToInt32(Console.ReadLine());
            }
            Height = temp;
        }
        public override void PrintFigure()
        {
            Console.WriteLine("Квадрат с параметрами:\nКоордината центра x={0}, координата центра y={1}, стороны равны {2}", X, Y, Height);
        }
    }
}
