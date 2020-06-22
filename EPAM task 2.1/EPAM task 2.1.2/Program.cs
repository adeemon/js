using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// В рамках реализации полноценного Paint уровней иерархии должно быть больше(банальный пример - разделение по измерениям), однако в условия ТЗ данной задачи
/// число фигур небольшое, а также действий с ними со стороны пользователя всего 3, поэтому иерархия реализована под данную задачу. Яркий пример - квадрат и прямоугольник.
/// В общем случае, их следовало бы оставить на одном уровне иерархии, т.к. различаются формулы для рассчета периметра. Однако в задаче не требуются подсчеты конкретных значений площади или периметра,
/// а значит в случае наследования прямоугольника от квадрата мы сохраним значение стороны квадрата, добавив еще одно поле для другой стороны. На практике, формула теперь уже площади
/// квадрата была бы некорректной для прямоугольника и такое наследование не было бы хорошим решением. Даже в данном случае это уже не совсем хорошо, т.к. нейминг поля, соответствующего стороне
/// квадрата можно было бы оставить как Side, но тогда непонятно будет что за Side у прямоугольника. Поэтому сторону квадрата назвал Height, что уменьшит число строк кода в данной работе, но
/// не сделает хорошо в реальном проекте.
/// Пару слов о иерархии в рабочем случае: после класса Figure следует провести разделение на 1D, 2D и 3D фигуры, и далее уже проводить грамотное наследование, которое работает
/// корректно для подсчетов в том числе.
/// </summary>


namespace EPAM_task_2._1._2
{

    abstract class Figure
    {
        private int _x;

        public int X
        {
            get { return _x; }
            set { _x=value; }
        }
        private int _y;

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public abstract void PrintFigure();
    }
    class Circle : Figure
    {
        private int _r;

        public int R
        {
            get { return _r; }
            set
            {
                if (value > 0)
                {
                    _r = value;
                }
                else
                {
                    int temp = value;
                    while (temp <= 0)
                    {
                        Console.WriteLine("Радиус должен быть положительным числом. Введите корректное значение.");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    _r = value;
                }
            }
        }
        public Circle(int InputX, int InputY, int InputR)
        {
            X = InputX;
            Y = InputY;
            int temp = InputR;
            while (temp <= 0)
            {
                Console.WriteLine("Радиус должен быть положительным числом. Введите корректное значение.");
                temp= Convert.ToInt32(Console.ReadLine());
            }
            R = temp;
        }
        public override void PrintFigure()
        {
            Console.WriteLine("Окружность с параметрами:\nКоордината центра x={0}, координата центра y={1} и радиус r={2}",X,Y,R);
        }

    }
    class Disc : Circle
    {
        public Disc(int InputX, int InputY, int InputR) : base(InputX, InputY, InputR)
        {
            X = InputX;
            Y = InputY;
            R = InputR;
        }


        public double Area
        {
            get { return R*R*Math.PI; }
        }

        public double Length
        {
            get { return 2 * Math.PI * R; }
        }

        public override void PrintFigure()
        {
            Console.WriteLine("Круг с параметрами:\nКоордината центра x={0}, координата центра y={1} и радиус r={2}", X, Y, R);
        }
    }
    class Ring : Disc
    {
        private int _innerR;

        public int InnerR
        {
            get { return _innerR; }
            set
            {
                if (value < R)
                {
                    _innerR = value;
                }
                else
                {
                    int CorrectInput = value;
                    while (CorrectInput >= R)
                    {
                        Console.WriteLine("Введено некорректное значение внутреннего радиуса. Введите значение меньшее чем {0}", R);
                        CorrectInput = Convert.ToInt32(Console.ReadLine());
                    }
                    _innerR = CorrectInput;
                }
            }
        }

        public Ring(int InputX, int InputY, int InputR,int InputInnerR) : base (InputX, InputY, InputR)
        {
            if (InputR > InputInnerR)
            {
                InnerR = InputInnerR;
            }
            else
            {
                int CorrectInput = InputR;
                while (CorrectInput >= R)
                {
                    Console.WriteLine("Введено некорректное значение внутреннего радиуса. Введите значение меньшее чем {0}", InputR);
                    CorrectInput = Convert.ToInt32(Console.ReadLine());
                }
                InnerR = CorrectInput;
            }
        }

        public new double Area
        {
            get { return base.Area - Math.PI * InnerR * InnerR; }
        }

        public new double Length
        {
            get { return base.Length + 2 * Math.PI * InnerR; }
        }

        public override void PrintFigure()
        {
            Console.WriteLine("Кольцо с параметрами:\nКоордината центра x={0}, координата центра y={1}, внешний радиус кольца r={2} и внутренний радиус кольца inr={3}", X, Y, R,InnerR);
        }
    }
    class Square : Figure
    {
        private int _height;

        public int Height
        {
            get { return _height; }
            set
            {
                if (value > 0)
                {
                    _height = value;
                }
                else
                {
                    int temp = value;
                    while (temp <= 0)
                    {
                        Console.WriteLine("Сторона не может быть равна или меньше нуля. Введите корректное значение");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    _height = temp;
                }
            }
        }

        public Square(int InputX, int InputY, int InputHeight)
        {
            X = InputX;
            Y = InputY;
            int temp = InputHeight;
            while (temp <= 0)
            {
                Console.WriteLine("Сторона не может быть равна или меньше нуля. Введите корректное значение");
                temp = Convert.ToInt32(Console.ReadLine());
            }
            Height = temp;
        }
        public override void PrintFigure()
        {
            Console.WriteLine("Квадрат с параметрами:\nКоордината центра x={0}, координата центра y={1}, стороны равны {2}", X, Y, Height);
        }
    }
    class Rectangle : Square
    {
        private int _width;
        
        public int Width
        {
            get { return _width; }
            set
            {
                if (value>0)
                {
                    _width = value;
                }
                else
                {
                    int temp = value;
                    while (temp <= 0)
                    {
                        Console.WriteLine("Сторона не может быть равна или меньше нуля. Введите корректное значение");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    _width = temp;
                }
            }
        }

        public Rectangle( int InputX, int InputY, int InputHeight, int InputWidth) : base (InputX, InputY, InputHeight)
        {
            X = InputX;
            Y = InputY;
            Height = InputHeight;
            int temp = InputWidth;
            while (temp <= 0)
            {
                Console.WriteLine("Сторона не может быть равна или меньше нуля. Введите корректное значение");
                temp = Convert.ToInt32(Console.ReadLine());
            }
            Width = temp;
        }
        public override void PrintFigure()
        {
            Console.WriteLine("Прямоугольник с параметрами:\nКоордината центра x={0}, координата центра y={1}, стороны равны {2} и {3}", X, Y, Height,Width);
        }
    }
    class Triangle : Figure
    {
        private int _firstSide;
        private int _secondSide;
        private int _thirdSide;

        public int FirstSide
        {
            get { return FirstSide; }
            set
            {
                if (value<=_secondSide+_thirdSide)
                {
                    _firstSide = value;
                }
                else
                {
                    int temp = value;
                    while (temp <=0)
                    {
                        Console.WriteLine("Введите корректное значение стороны треугольника.");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    _firstSide = temp;
                }
            }
        }

        public int SecondSide
        {
            get { return SecondSide; }
            set
            {
                if (value <= _firstSide + _thirdSide)
                {
                    _secondSide = value;
                }
                else
                {
                    int temp = value;
                    while (temp <= 0)
                    {
                        Console.WriteLine("Введите корректное значение стороны треугольника.");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    _secondSide = temp;
                }
            }
        }

        public int ThirdSide
        {
            get { return ThirdSide; }
            set
            {
                if (value <= _firstSide + _secondSide)
                {
                    _thirdSide = value;
                }
                else
                {
                    int temp = value;
                    while (temp <= 0)
                    {
                        Console.WriteLine("Введите корректное значение стороны треугольника.");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    _thirdSide = temp;
                }
            }
        }

        public Triangle(int InputX, int InputY, int a, int b, int c)
        {
            X = InputX;
            Y = InputY;
            if (a>b+c)
            {
                int temp = a;
                while (temp > b+c)
                {
                    Console.WriteLine("Введите корректное значение стороны треугольника.");
                    temp = Convert.ToInt32(Console.ReadLine());
                }
                a = temp;
            }
            if (b > a + c)
            {
                int temp = b;
                while (temp > a + c)
                {
                    Console.WriteLine("Введите корректное значение стороны треугольника.");
                    temp = Convert.ToInt32(Console.ReadLine());
                }
                b = temp;
            }

            if (c > a + b)
            {
                int temp = c;
                while (temp > a + b)
                {
                    Console.WriteLine("Введите корректное значение стороны треугольника.");
                    temp = Convert.ToInt32(Console.ReadLine());
                }
                c = temp;
            }
            FirstSide = a;
            SecondSide = b;
            ThirdSide = c;
        }

        public override void PrintFigure()
        {
            Console.WriteLine("Треугольник с параметрами:\nКоордината центра x={0}, координата центра y={1}, стороны равны {2}, {3} и {4}.", X, Y, FirstSide, SecondSide, ThirdSide);
        }
     
    }
    class Line : Figure
    {
        private int _endx;

        private int _endy;

        public int EndX
        {
            get { return _endx; }
            set { _endx = value;}
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
            while (tempOne==X||tempTwo==Y)
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

    class Paint
    {

        private static int ChoosingOfMethod()
        {
            Console.WriteLine("Выберите действие:\n1. Добавить фигуру \n2. Вывести фигуры \n3. Очистить холст \n4. Выход");
            int UserChoose = Convert.ToInt32(Console.ReadLine());
            return UserChoose;
        }
        private static void WipeOfList (ref List<Figure> ListOfFigures)
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
            if (flag==0)
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
            ListOfFigures.Add(new Triangle(X, Y, a,b,c));
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
            int UserChoose= ChoosingOfMethod();
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

    class Program
    {
        static void Main(string[] args)
        {
            Paint.Editor();
        }
    }
}
