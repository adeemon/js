using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_2._1._2
{
    abstract class Figure
    {
        private int _x;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        private int _y;

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public abstract void PrintFigure();
    }
}
