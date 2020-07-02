using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_2._1._2
{
    class Triangle : Figure
    {
        private int _firstSide;
        private int _secondSide;
        private int _thirdSide;

        public int FirstSide
        {
            get { return FirstSide; }
            set
            {
                if (value <= _secondSide + _thirdSide)
                {
                    _firstSide = value;
                }
                else
                {
                    int temp = value;
                    while (temp <= 0)
                    {
                        Console.WriteLine("Введите корректное значение стороны треугольника.");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    _firstSide = temp;
                }
            }
        }

        public int SecondSide
        {
            get { return SecondSide; }
            set
            {
                if (value <= _firstSide + _thirdSide)
                {
                    _secondSide = value;
                }
                else
                {
                    int temp = value;
                    while (temp <= 0)
                    {
                        Console.WriteLine("Введите корректное значение стороны треугольника.");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    _secondSide = temp;
                }
            }
        }

        public int ThirdSide
        {
            get { return ThirdSide; }
            set
            {
                if (value <= _firstSide + _secondSide)
                {
                    _thirdSide = value;
                }
                else
                {
                    int temp = value;
                    while (temp <= 0)
                    {
                        Console.WriteLine("Введите корректное значение стороны треугольника.");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    _thirdSide = temp;
                }
            }
        }

        public Triangle(int InputX, int InputY, int a, int b, int c)
        {
            X = InputX;
            Y = InputY;
            if (a > b + c)
            {
                int temp = a;
                while (temp > b + c)
                {
                    Console.WriteLine("Введите корректное значение стороны треугольника.");
                    temp = Convert.ToInt32(Console.ReadLine());
                }
                a = temp;
            }
            if (b > a + c)
            {
                int temp = b;
                while (temp > a + c)
                {
                    Console.WriteLine("Введите корректное значение стороны треугольника.");
                    temp = Convert.ToInt32(Console.ReadLine());
                }
                b = temp;
            }

            if (c > a + b)
            {
                int temp = c;
                while (temp > a + b)
                {
                    Console.WriteLine("Введите корректное значение стороны треугольника.");
                    temp = Convert.ToInt32(Console.ReadLine());
                }
                c = temp;
            }
            FirstSide = a;
            SecondSide = b;
            ThirdSide = c;
        }

        public override void PrintFigure()
        {
            Console.WriteLine("Треугольник с параметрами:\nКоордината центра x={0}, координата центра y={1}, стороны равны {2}, {3} и {4}.", X, Y, FirstSide, SecondSide, ThirdSide);
        }

    }
}
