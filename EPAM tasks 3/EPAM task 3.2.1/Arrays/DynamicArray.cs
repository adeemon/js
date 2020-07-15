using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_3._2._1.Arrays
{
    class DynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable
    {
        public int Length;
        public int Capacity
        {
            get { return Data.Length; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The capacity of a dynamic array cannot be less than zero.");
                }

                T[] tempArray = new T[value];
                int counter = Math.Min(Length, value);

                for (int i=0;i< counter; ++i)
                {
                    tempArray[i] = Data[i];
                }

                Data = tempArray;
                Capacity = counter;
                Length = counter;
            }
        }
        public T[] Data;

        public DynamicArray()
        {
            Length = 0;
            Capacity = 8;
            Data = new T[Capacity];
        }

        public DynamicArray(int capacityInput)
        {
            Capacity = capacityInput;
            Data = new T[Capacity];
        }

        public DynamicArray(IEnumerable<T> inputCollection)
        {
            Capacity = inputCollection.Count();
            Length = 0;
            Data = new T[Capacity];
            foreach (var element in inputCollection)
            {
                Data[Length] = element;
                Length++;
            }
        }

        public void Add(T value)
        {
            if (Length + 1 > Capacity)
            {
                int newCapacity = Capacity * 2;
                T[] tempArray = new T[newCapacity];

                Data.CopyTo(tempArray, 0);
                Data = tempArray;
            }

            Data[Length] = value;
            Length++;
        }

        public void AddRange(IEnumerable<T> inputCollection)
        {
            if (Length + inputCollection.Count() > Capacity)
            {
                int newCapacity = Capacity + inputCollection.Count() + 5;

                T[] tempArray = new T[newCapacity];

                Data.CopyTo(tempArray, 0);
                Data = tempArray;
            }

            int counter = Length;
            foreach (var element in inputCollection)
            {
                Data[counter] = element;
                counter++;
            }
            Length = counter;
        }

        public bool Remove(T itemToRemove)
        {
            for (int i = 0; i < Length; i++)
            {
                if (Equals(itemToRemove, Data[i]))
                {
                    for (int j = i; j < Length - 1; j++)
                    {
                        Data[j] = Data[j + 1];
                    }

                    Length--;
                    return true;
                }
            }

            return false;
        }

        public bool Insert (int indexOfElement, T element)
        {
            if (indexOfElement < 0 || indexOfElement > Capacity)
            {
                //that moment makes me sad - will it work or not ? :D
                return false;
                throw new ArgumentOutOfRangeException("Index of inserted element isn't correct.");
            }

            if (Length == Capacity)
            {
                int newCapacity = Capacity*2;

                T[] tempArray = new T[newCapacity];

                Data.CopyTo(tempArray, 0);
                Data = tempArray;
            }

            for (int i = Length; i > indexOfElement; --i)
            {
                Data[i] = Data[i - 1];
            }

            Data[indexOfElement] = element;
            Length++;

            return true;
        }

        public T this[int index]
        {
            get
            {
                if (index >= -Length && index <= Length - 1)
                {
                    return Data[(index + Length) % Length];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index goes beyond array.");
                }
            }

            set
            {
                if (index >= -Length && index <= Length - 1)
                {
                    Data[(index + Length) % Length] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index goes beyond array.");
                }
            }
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return Data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        public object Clone()
        {
            var clonedArray = (DynamicArray<T>)this.MemberwiseClone();

            return clonedArray;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[Capacity];
            
            for (int i=0;i<Length;++i)
            {
                newArray[i] = Data[i];
            }

            return newArray;
        }

    }
}
