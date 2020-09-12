using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EPAM_task_3._3._1.Extentions
{
    static class Int32ArrayExtention
    {
        public static void Modify (this int[] array, Func<int,int> function )
        {
            if (array.Length == 0|| array== null)
            {
                throw new ArgumentException("'array' as an argument can't be empty");
            }

            for (int i = 0 ; i < array.Length ; ++i)
            {
                array[i] = function(array[i]);
            }
        }

        public static int Summ(this int[] array)
        {
            int summOfElements = 0;

            if (array.Length == 0 || array == null)
            {
                throw new ArgumentException("'Array' as an argument can't be empty");
            }

            for (int i = 0; i < array.Length; ++i)
            {
                summOfElements += array[i];
            }
            return summOfElements;
        }

        public static int Average (this int[] array)
        {
            return array.Summ() / array.Length;
        }

        public static int MostOftenElement (this int[] array)
        {
            if (array.Length == 0 || array == null)
            {
                throw new ArgumentException("'Array' as an argument can't be empty");
            }

            int element = array[0];
            int count = 1;

            for (int i = 0; i < array.Length; ++i)
            {
                int tempCount = 1;

                for (int j = i+1; j < array.Length; ++j)
                {
                    if (array[i] == array[j]) tempCount++;
                }

                if (tempCount>count)
                {
                    element = array[i];
                    count = tempCount;
                }
            }

            return element;
        }

    }
}
