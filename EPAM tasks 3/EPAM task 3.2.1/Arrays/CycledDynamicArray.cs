using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_3._2._1.Arrays
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray() : base() { }

        public CycledDynamicArray(int Capacity) : base(Capacity) { }

        public CycledDynamicArray(IEnumerable<T> inputCollection) : base(inputCollection) { }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; ; i = (i + 1) % Length)
            {
                yield return Data[i];
            }
        }
    }
}
