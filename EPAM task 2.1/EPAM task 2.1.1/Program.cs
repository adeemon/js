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

namespace EPAM_task_2._1._1
{

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
