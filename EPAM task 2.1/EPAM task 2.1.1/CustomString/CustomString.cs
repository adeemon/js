using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_2._1._1
{
    class CustomString
    {
        public char[] data = new char[100000];
        public int end = 0;

        public CustomString()
        {

        }


        public CustomString(char[] InputString)
        {
            int count = 0;
            foreach (char element in InputString)
            {
                data[count] = element;
                count++;
            }
            end = count;
        }

        public CustomString(string InputString)
        {
            int count = 0;
            foreach (char element in InputString)
            {
                data[count] = element;
                count++;
            }
            end = count;
        }



        public static int CustomCompare(CustomString FirstString, CustomString SecondString)
        {
            int counter = 0;
            foreach (char element in FirstString.data)
            {
                if (element < SecondString.data[counter])
                {
                    return 1;
                }
                else
                {
                    if (element > SecondString.data[counter])
                    {
                        return -1;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }
            return 0;
        }

        public int CustomFind(char symbol)
        {
            for (int i = 0; i < end; ++i)
            {
                if (data[i] == symbol)
                {
                    return i;
                }
            }
            return -1;
        }


        public static CustomString CustomConcatenation(CustomString FirstString, CustomString SecondString)
        {
            int counter = 0;
            CustomString TempString = new CustomString();
            for (int i = 0; i < FirstString.end; ++i)
            {
                if (FirstString.data[i] > 1)
                {
                    TempString.data[counter] = FirstString.data[i];
                    counter++;
                }
            }
            for (int i = 0; i < SecondString.end; ++i)
            {
                if (SecondString.data[i] > 1)
                {
                    TempString.data[counter] = SecondString.data[i];
                    counter++;
                }
            }
            TempString.end = counter;
            return TempString;
        }

        public static char[] StringToArr(CustomString InputString)
        {
            char[] temp = new char[InputString.end];
            for (int i = 0; i < InputString.end; ++i)
            {
                temp[i] = InputString.data[i];
            }
            return temp;
        }

        public static CustomString ArrToString(char[] InputArr)
        {
            CustomString Temp = new CustomString();
            Temp.end = InputArr.Length;
            for (int i = 0; i < InputArr.Length; ++i)
            {
                Temp.data[i] = InputArr[i];
            }
            return Temp;
        }

        public char SwapRegisterOfChar(char symbol)
        {
            if (Char.IsUpper(symbol))
            {
                return Char.ToLower(symbol);
            }
            else
            {
                return Char.ToUpper(symbol);
            }
        }

        private bool IsEndOfSentence(char symbol)
        {
            if (symbol == '.' || symbol == '!' || symbol == '?')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void FixCapsLock()
        {
            int SentenceBegin = 0;
            int SentenceEnd = 0;
            int counter = 0;
            int flag = 1;
            while (counter < end)
            {
                counter++;
                if (IsEndOfSentence(data[counter]))
                {
                    SentenceEnd = counter;
                    if (Char.IsLower(data[SentenceBegin]))
                    {
                        for (int i = SentenceBegin + 1; i < SentenceEnd; ++i)
                        {
                            if (Char.IsLower(data[i]))
                            {
                                flag = 0;
                            }
                        }
                        if (flag == 1)
                        {
                            for (int i = SentenceBegin; i < SentenceEnd; ++i)
                            {
                                data[i] = SwapRegisterOfChar(data[i]);
                            }
                            for (int j = SentenceEnd; j < end; ++j)
                            {
                                if (Char.IsLetter(data[j]))
                                {
                                    SentenceBegin = j;
                                    SentenceEnd = j + 1;
                                    counter = SentenceEnd;
                                }
                            }
                        }
                    }
                    if (Char.IsUpper(data[SentenceBegin]))
                    {
                        for (int i = SentenceBegin + 1; i < end; ++i)
                        {
                            if (IsEndOfSentence(data[i]))
                            {
                                SentenceEnd = i;
                                for (int j = SentenceEnd; j < end; ++j)
                                {
                                    if (Char.IsLetter(data[j]))
                                    {
                                        SentenceBegin = j;
                                        SentenceEnd = j + 1;
                                    }
                                }
                                break;
                            }
                        }
                    }

                }
            }
        }

        public void PrintString()
        {
            for (int i = 0; i < end; ++i)
            {
                Console.Write(data[i]);
            }
        }

    }
}
