using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_2._1._2
{
    class Ring : Disc
    {
        private int _innerR;

        public int InnerR
        {
            get { return _innerR; }
            set
            {
                if (value < R)
                {
                    _innerR = value;
                }
                else
                {
                    int CorrectInput = value;
                    while (CorrectInput >= R)
                    {
                        Console.WriteLine("Введено некорректное значение внутреннего радиуса. Введите значение меньшее чем {0}", R);
                        CorrectInput = Convert.ToInt32(Console.ReadLine());
                    }
                    _innerR = CorrectInput;
                }
            }
        }

        public Ring(int InputX, int InputY, int InputR, int InputInnerR) : base(InputX, InputY, InputR)
        {
            if (InputR > InputInnerR)
            {
                InnerR = InputInnerR;
            }
            else
            {
                int CorrectInput = InputR;
                while (CorrectInput >= R)
                {
                    Console.WriteLine("Введено некорректное значение внутреннего радиуса. Введите значение меньшее чем {0}", InputR);
                    CorrectInput = Convert.ToInt32(Console.ReadLine());
                }
                InnerR = CorrectInput;
            }
        }

        public new double Area
        {
            get { return base.Area - Math.PI * InnerR * InnerR; }
        }

        public new double Length
        {
            get { return base.Length + 2 * Math.PI * InnerR; }
        }

        public override void PrintFigure()
        {
            Console.WriteLine("Кольцо с параметрами:\nКоордината центра x={0}, координата центра y={1}, внешний радиус кольца r={2} и внутренний радиус кольца inr={3}", X, Y, R, InnerR);
        }
    }
}
