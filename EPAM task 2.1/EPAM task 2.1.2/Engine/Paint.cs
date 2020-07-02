using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_2._1._2
{
    class Paint
    {

        private static int ChoosingOfMethod()
        {
            Console.WriteLine("Выберите действие:\n1. Добавить фигуру \n2. Вывести фигуры \n3. Очистить холст \n4. Выход");
            int UserChoose = Convert.ToInt32(Console.ReadLine());
            return UserChoose;
        }
        private static void WipeOfList(ref List<Figure> ListOfFigures)
        {
            ListOfFigures.Clear();
        }

        private static void FiguresPrint(List<Figure> ListOfFigures)
        {
            int flag = 0;
            foreach (Figure Fig in ListOfFigures)
            {
                Fig.PrintFigure();
                flag = 1;
            }
            if (flag == 0)
            {
                Console.WriteLine("Холст чист.");
            }
        }

        private static void FigureAdd(ref List<Figure> ListOfFigures)
        {
            Console.WriteLine("Выберите тип фигуры: \n1. Кольцо \n2. Окружность \n3. Круг \n4. Прямоугольник \n5. Квадрат \n6. Треугольник \n7. Линия");
            int UserChoose = Convert.ToInt32(Console.ReadLine()); ;
            switch (UserChoose)
            {
                case 1:
                    AddRing(ListOfFigures);
                    Console.Write("\nФигура Кольцо создана!\n");
                    break;
                case 2:
                    AddCircle(ListOfFigures);
                    Console.Write("\nФигура Окружность создана!\n");
                    break;
                case 3:
                    AddDisc(ListOfFigures);
                    Console.Write("\nФигура Круг создана!\n");
                    break;
                case 4:
                    AddRectangle(ListOfFigures);
                    Console.Write("\nФигура Прямоугольник создана!\n");
                    break;
                case 5:
                    AddSquare(ListOfFigures);
                    Console.Write("\nФигура Квадрат создана!\n");
                    break;
                case 6:
                    AddTriangle(ListOfFigures);
                    Console.Write("\nФигура Треугольник создана!\n");
                    break;
                case 7:
                    AddLine(ListOfFigures);
                    Console.Write("\nФигура Линия создана!\n");
                    break;
            }
        }

        public static void AddRing(List<Figure> ListOfFigures)
        {
            Console.WriteLine("Введите координату X центра кольца\n");
            int X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату Y центра кольца\n");
            int Y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите внешний радиус кольца\n");
            int R = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите внутренний радиус кольца\n");
            int InnerR = Convert.ToInt32(Console.ReadLine());
            ListOfFigures.Add(new Ring(X, Y, R, InnerR));
        }

        public static void AddCircle(List<Figure> ListOfFigures)
        {
            Console.WriteLine("Введите координату X центра окружности\n");
            int X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату Y центра окружности\n");
            int Y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите радиус окружности\n");
            int R = Convert.ToInt32(Console.ReadLine());
            ListOfFigures.Add(new Circle(X, Y, R));
        }

        public static void AddDisc(List<Figure> ListOfFigures)
        {
            Console.WriteLine("Введите координату X центра круга\n");
            int X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату Y центра круга\n");
            int Y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите внешний радиус круга\n");
            int R = Convert.ToInt32(Console.ReadLine());
            ListOfFigures.Add(new Disc(X, Y, R));
        }

        public static void AddRectangle(List<Figure> ListOfFigures)
        {
            Console.WriteLine("Введите координату X центра прямоугольника\n");
            int X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату Y центра прямоугольника\n");
            int Y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите высоту прямоугольника\n");
            int InputHeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите ширину прямоугольника\n");
            int InputWidth = Convert.ToInt32(Console.ReadLine());
            ListOfFigures.Add(new Rectangle(X, Y, InputHeight, InputWidth));
        }

        public static void AddSquare(List<Figure> ListOfFigures)
        {
            Console.WriteLine("Введите координату X центра квадрата\n");
            int X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату Y центра квадрата\n");
            int Y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сторону квадрата\n");
            int InputHeight = Convert.ToInt32(Console.ReadLine());
            ListOfFigures.Add(new Square(X, Y, InputHeight));
        }

        public static void AddTriangle(List<Figure> ListOfFigures)
        {
            Console.WriteLine("Введите координату X центра треугольника\n");
            int X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату Y центра треугольника\n");
            int Y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите стороны треугольника разделяя их клавишей Enter\n");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            ListOfFigures.Add(new Triangle(X, Y, a, b, c));
        }

        public static void AddLine(List<Figure> ListOfFigures)
        {
            Console.WriteLine("Введите координату X начала линии\n");
            int X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату Y начала линии\n");
            int Y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату X конца линии\n");
            int EndX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату Y конца линии\n");
            int EndY = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сторону квадрата\n");
            ListOfFigures.Add(new Line(X, Y, EndX, EndY));
        }
        public static void Editor()
        {
            int UserChoose = ChoosingOfMethod();
            List<Figure> Image = new List<Figure>();
            while (UserChoose != 4)
            {
                switch (UserChoose)
                {
                    case 1:
                        FigureAdd(ref Image);
                        UserChoose = ChoosingOfMethod();
                        break;
                    case 2:
                        FiguresPrint(Image);
                        UserChoose = ChoosingOfMethod();
                        break;
                    case 3:
                        WipeOfList(ref Image);
                        UserChoose = ChoosingOfMethod();
                        break;
                }
            }
        }
    }
}
