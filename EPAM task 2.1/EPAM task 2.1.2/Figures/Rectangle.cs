using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_2._1._2
{
    class Rectangle : Square
    {
        private int _width;

        public int Width
        {
            get { return _width; }
            set
            {
                if (value > 0)
                {
                    _width = value;
                }
                else
                {
                    int temp = value;
                    while (temp <= 0)
                    {
                        Console.WriteLine("Сторона не может быть равна или меньше нуля. Введите корректное значение");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    _width = temp;
                }
            }
        }

        public Rectangle(int InputX, int InputY, int InputHeight, int InputWidth) : base(InputX, InputY, InputHeight)
        {
            X = InputX;
            Y = InputY;
            Height = InputHeight;
            int temp = InputWidth;
            while (temp <= 0)
            {
                Console.WriteLine("Сторона не может быть равна или меньше нуля. Введите корректное значение");
                temp = Convert.ToInt32(Console.ReadLine());
            }
            Width = temp;
        }
        public override void PrintFigure()
        {
            Console.WriteLine("Прямоугольник с параметрами:\nКоордината центра x={0}, координата центра y={1}, стороны равны {2} и {3}", X, Y, Height, Width);
        }
    }
}
