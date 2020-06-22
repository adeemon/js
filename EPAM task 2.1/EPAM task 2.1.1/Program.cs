using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Реализован дополнительный метод FixCapsLock, позволяющий изменить регистр всех символов. Суть в установлении: была ли ошибка ввода 
/// (подразумевается, что если предложение начинается с маленькой буквы, затем содержит только заглавные буквы, то в нем была допущена ошибка. Метод обрабатывает
/// только это предложение, чтобы избежать некорректного исправляния правильно написанных предложений. 
/// Удобно, когда печатаешь гору текста и обнаруживаешь в конце, что Caps Look был включен.
/// 
/// </summary>

namespace EPAM_task_2._1
{
    class CustomString
    {
        public char[] data=new char[100000];
        public int end = 0;

        public CustomString()
        {
            
        }


        public CustomString (char[] InputString)
        {
            int count = 0 ;
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
                if (element< SecondString.data[counter])
                {
                    return 1;
                }
                else
                {
                if (element> SecondString.data[counter])
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

        public int CustomFind (char symbol)
        {
            for (int i=0;i<end;++i)
            {
                if (data[i]== symbol)
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
            for (int i=0;i< FirstString.end; ++i)
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

        public static char[] StringToArr (CustomString InputString)
        {
            char[] temp = new char[InputString.end];
            for (int i=0;i< InputString.end; ++i)
            {
                temp[i] = InputString.data[i];
            }
            return temp;
        }

        public static CustomString ArrToString (char[] InputArr)
        {
            CustomString Temp = new CustomString();
            Temp.end = InputArr.Length;
            for (int i=0;i<InputArr.Length;++i)
            {
                Temp.data[i] = InputArr[i];
            }
            return Temp;
        }

        public char SwapRegisterOfChar (char symbol)
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

        private bool IsEndOfSentence (char symbol)
        {
            if (symbol=='.'|| symbol == '!'||symbol == '?')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void FixCapsLock ()
        {
            int SentenceBegin = 0;
            int SentenceEnd = 0;
            int counter = 0;
            int flag = 1;
            while (counter<end)
            {
                counter++;
                if (IsEndOfSentence(data[counter]))
                {
                    SentenceEnd = counter;
                    if (Char.IsLower(data[SentenceBegin]))
                    {
                        for (int i = SentenceBegin+1; i < SentenceEnd; ++i)
                        {
                            if (Char.IsLower(data[i]))
                            {
                                flag = 0;
                            }
                        }
                        if (flag==1)
                        {
                            for (int i = SentenceBegin; i < SentenceEnd; ++i)
                            {
                                data[i] = SwapRegisterOfChar(data[i]);
                            }
                            for (int j= SentenceEnd;j<end;++j)
                            {
                                if (Char.IsLetter(data[j]))
                                {
                                    SentenceBegin = j;
                                    SentenceEnd = j+1;
                                    counter = SentenceEnd;
                                }
                            }
                        }
                    }
                    if (Char.IsUpper(data[SentenceBegin]))
                    {
                        for (int i= SentenceBegin+1; i< end;++i)
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


    class Program
    {
        static void Main(string[] args)
        {
            //Задаем строки 2 способами
            char[] charArray = { 'q', 'w', 'e', ';', 'r', 't', 'y' };
            CustomString FirstString = new CustomString("qwe;rty awddwaawdwa");
            CustomString SecondString = new CustomString(charArray);
            //Сравнение
            Console.WriteLine("Результат сравнения двух строк равен: {0}",CustomString.CustomCompare(FirstString, SecondString));
            //Конкатенация
            CustomString TempString = CustomString.CustomConcatenation(FirstString, SecondString);
            Console.WriteLine("Конкатенация двух строк равна:");
            TempString.PrintString();

            //Поиск символа
            Console.WriteLine();
            Console.WriteLine("Первое вхождение символа '{0}' в строку производится по индексу {1}",'а',FirstString.CustomFind('a'));
            //Преобразование CustomString в массив символов
            char[] testArray = CustomString.StringToArr(FirstString);
            Console.WriteLine("Преобразованная из CustomString в массив символов, строка FirstString имеет вид:");
            for (int i=0;i<testArray.Length;++i)
            {
                Console.Write(testArray[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Изначально строка FirstString равна");
            FirstString.PrintString();

            //Преобразование charArray в строку
            CustomString BufString = CustomString.ArrToString(charArray);
            Console.WriteLine("\nМассив charArray, преобразованный в строку, имеет вид: ");
            BufString.PrintString();

            //Исправление CL
            CustomString WrongString = new CustomString("tEST STRING FOR THE TASK... I HOPE it will work and word HOPE will not be swapped.");
            Console.WriteLine("\nСтрока до исправления:");
            WrongString.PrintString();
            WrongString.FixCapsLock();
            Console.WriteLine("\nСтрока после исправления:");
            WrongString.PrintString();

            Console.ReadKey();

            
        }
    }
}
