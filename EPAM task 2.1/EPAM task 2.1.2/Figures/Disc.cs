using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_2._1._2
{
    class Disc : Circle
    {
        public Disc(int InputX, int InputY, int InputR) : base(InputX, InputY, InputR)
        {
            X = InputX;
            Y = InputY;
            R = InputR;
        }


        public double Area
        {
            get { return R * R * Math.PI; }
        }

        public double Length
        {
            get { return 2 * Math.PI * R; }
        }

        public override void PrintFigure()
        {
            Console.WriteLine("Круг с параметрами:\nКоордината центра x={0}, координата центра y={1} и радиус r={2}", X, Y, R);
        }
    }
}
