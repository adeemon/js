using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_2._1._2
{
    class Line : Figure
    {
        private int _endx;

        private int _endy;

        public int EndX
        {
            get { return _endx; }
            set { _endx = value; }
        }

        public int EndY
        {
            get { return _endy; }
            set { _endy = value; }
        }

        public Line(int InputX, int InputY, int InputEndX, int InputEndY)
        {
            X = InputX;
            Y = InputY;
            int tempOne = InputEndX;
            int tempTwo = InputEndY;
            while (tempOne == X || tempTwo == Y)
            {
                Console.WriteLine("Координаты начала и конца линии совпадают. Введите корретные координату конца линии.");
                tempOne = Convert.ToInt32(Console.ReadLine());
                tempTwo = Convert.ToInt32(Console.ReadLine());
            }
            EndX = tempOne;
            EndY = tempTwo;
        }

        public override void PrintFigure()
        {
            Console.WriteLine("Линия с началом в точке x={0} y={1} и концом в точке x={2} y={3}", X, Y, EndX, EndY);
        }
    }
}
