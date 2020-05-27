using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._8
{
    class Program
    {
        static void print3D (int [,,] array)
        {
            Console.Write(Environment.NewLine); 
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    Console.Write("В ячейке i={0} j={1} лежит массив:", i, j);
                    for (int k = 0; k < 4; ++k)
                    {
                        Console.Write("{0} ",array[i,j,k]);
                    }
                    Console.Write(Environment.NewLine);
                }
            }
        }
        static void Main(string[] args)
        {
            int[,,] array = 
                {
                   {
                       { 1, -2, 3, -4 },
                       { 5, -6, 7, 8 },
                       { 9, 10, -11, -12 }
                   },
                   {
                       { 13, -14, 15, 16 },
                       { 17, -18, -19, 20 },
                       { -21, 22, 23, 24 }
                   }
               };
            print3D(array);
            for (int i=0;i<2;++i)
            {
                for (int j=0;j<3;++j)
                {
                    for (int k=0;k<4;++k)
                    {
                        if (array[i, j, k] > 0) array[i, j, k] = 0;
                    }
                }
            }
            print3D(array);
            Console.ReadKey();
        }
    }
}
