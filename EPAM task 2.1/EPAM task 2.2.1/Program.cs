using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
/// <summary>
//Разнообразие NPC:
//1)простые зомби (@) ходят в случайном направлении (может быть, и на месте... Они же зомби); 
//2) некроманты (N) - раз в 10 секунд возрождает в центре поля простого зомби, для избавления подбирается '+';
//3) разнообразие закончилось.
//Также на поле есть 3 ключа (K), подобрав которые игрок побеждает.
//Таким образом, все сводится к основной задаче - разобраться с опасными NPC и свободно пройти к выходу либо попытаться собрать ключи до того, как убежать от зомби и охотников
//будет невозможно. Уровни прописываются заранее посредством таблицы со всеми точками поля данного уровня.
//На данный момент реализовано: главный герой (&) и его возможность ходить в рамках поля.
///
/// Логика классов следующая:
/// Все недвижимые объекты будут унаследованы от абстрактного клласса Point с разделением типов объекта в каждом подклассе.
/// Бонусы как таковые реализованы в 3 типах: ключ (3 ключа необходимо для того, чтобы выйграть), выходной пункт и книга - нейтрализует некроманта.
/// Все они наследуются от абстрактного класса MapObjects.
/// Для ГГ и НПС написан абстрактный класс с реализованым методом для отрисовки и с абстрактными методами для перемещения, т.к. они различаются.За гг отвечает
/// класс MainHero, за нпс NPC и его наследуемые (одноименные с типами монстров).
/// 
/// 
/// Проблемы, которые вылезли во время разработки:
/// 1) Правая стена работает не так, как все остальные. Если подойти в упор к ней, то её элемент удаляется. Было решено не давать игроку возможность подойти к ней.
/// 2) Рандомайзер определяет направление движения зомби. Несовершенство рандомайзера вызывает проблемы с направлением движения нпс - оно не настолько хаотичное, как хотелось бы.
///     По причине этого, все зомби уползают в один из углов и из него не выходят. Возможно дело в несовсем грамотном подходе к выбору их направления и движению в целом, но как исправить
///     - не придумал.
/// 3) Класс Point реализован для отрисовки точек, в то время как MapObjects - для опредления объектов на карте внутри границ. Не знаю, стоило ли их ставить на одном уровне иерархии, но показалось,
///     что так будет оптимальнее в возможных условихя дальнейшего развития проекта.
/// 4) Отрисовка в целом не идеальна и требует переработки. Но в целом, играбельно :D
/// </summary>



namespace EPAM_task_2._2._1
{
    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    enum TypesOfNPC
    {
        Zombie,
        Necromant
    }

    enum TypeOfMapObjects
    {
        Key,   
        Column
    }
    abstract class Character
    {
        public List<Point> charater;
        public Direction direction;
        public int step { get; set; }
        public Point body;
        public bool rotate = true;
        public Point GetMove() => charater.Last();
        public abstract void Move(List<MapObjects> list);
        public abstract Point GetNextPoint(List<MapObjects> list);

    }

    class MainHero : Character
    {
        bool rotate = true;
        public MainHero(int x, int y, char image)
        {
            direction = Direction.RIGHT;
            charater = new List<Point>();
            Point p = new Point(x, y, image);
            this.body = p;
            charater.Add(p);
            p.Draw();
            step = 1;
        }
        public Point GetMove() => charater.Last();
        public override void Move(List<MapObjects> list)
        {
            body.Clear();
            body = GetNextPoint(list);
            body.Draw();
            charater.Add(body);
            rotate = true;
        }
        public override Point GetNextPoint(List<MapObjects> list)
        {
            Point p = new Point(GetMove().x, GetMove().y, GetMove().ch);
            switch (direction)
            {
                case Direction.LEFT:
                    p.x -= step;
                    if (p.x == 0)
                    {
                        p.x = 1;
                    }
                    if (LogicMethods.IsHitColumns(p, list))
                    {
                        p.x += step;
                    }
                    break;
                case Direction.RIGHT:
                    p.x += step;
                    if (p.x == Game.WidthOfBattleGround - 1)
                    {
                        p.x = Game.WidthOfBattleGround - 2;
                    }
                    if (LogicMethods.IsHitColumns(p, list))
                    {
                        p.x -= step;
                    }
                    break;
                case Direction.UP:
                    p.y -= step;
                    if (p.y == 0)
                    {
                        p.y = 1;
                    }
                    if (LogicMethods.IsHitColumns(p, list))
                    {
                        p.y += step;
                    }
                    break;
                case Direction.DOWN:
                    p.y += step;
                    if (p.y == Game.HeightOfBattleGround)
                    {
                        p.y = Game.HeightOfBattleGround - 1;
                    }
                    if (LogicMethods.IsHitColumns(p, list))
                    {
                        p.y -= step;
                    }
                    break;
            }
            return p;
        }
        public void Rotation(ConsoleKey key)
        {
            if (rotate)
            {
                if (key == ConsoleKey.DownArrow)
                    direction = Direction.DOWN;
                else if (key == ConsoleKey.UpArrow)
                    direction = Direction.UP;
                else if (key == ConsoleKey.LeftArrow)
                    direction = Direction.LEFT;
                else if (key == ConsoleKey.RightArrow)
                    direction = Direction.RIGHT;
                rotate = false;
            }
        }

    }

    class NPC : Character
    {
        public Point GetMove() => charater.Last();
        public TypesOfNPC NPCType;
        public override void Move(List<MapObjects> list)
        {
            body.Clear();
            body = GetNextPoint(list);
            body.Draw();
            charater.Add(body);
            rotate = true;
        }
        public override Point GetNextPoint(List<MapObjects> list)
        {
            Point p = new Point(GetMove().x, GetMove().y, GetMove().ch);
            switch (direction)
            {
                case Direction.LEFT:
                    p.x -= step;
                    if (p.x == 0)
                    {
                        p.x = 1;
                    }
                    if (LogicMethods.IsHitMapObjects(p,list))
                    {
                        p.x += step;
                    }
                    break;
                case Direction.RIGHT:
                    p.x += step;
                    if (p.x == Game.WidthOfBattleGround - 1)
                    {
                        p.x = Game.WidthOfBattleGround - 2;
                    }
                    if (LogicMethods.IsHitMapObjects(p, list))
                    {
                        p.x -= step;
                    }
                    break;
                case Direction.UP:
                    p.y -= step;
                    if (p.y == 0)
                    {
                        p.y = 1;
                    }
                    if (LogicMethods.IsHitMapObjects(p, list))
                    {
                        p.y += step;
                    }
                    break;
                case Direction.DOWN:
                    p.y += step;
                    if (p.y == Game.HeightOfBattleGround)
                    {
                        p.y = Game.HeightOfBattleGround - 1;
                    }
                    if (LogicMethods.IsHitMapObjects(p, list))
                    {
                        p.y -= step;
                    }
                    break;
            }
            return p;
        }
        public void Rotation(int number)
        {
            Random rnd = new Random(number);

            if (rotate)
            {
                int choose = rnd.Next(1, 150);

                if (choose <= 25 && choose >= 1)
                    direction = Direction.DOWN;

                if (choose <= 50 && choose >= 26)
                    direction = Direction.UP;

                if (choose <= 75 && choose >= 51)
                    direction = Direction.LEFT;

                if (choose <= 76 && choose >= 150)
                    direction = Direction.RIGHT;
                rotate = false;
            }
        }
    }


    class Zombie : NPC
    {

        bool rotate = true;
        public Zombie(int x, int y, char image)
        {
            direction = Direction.RIGHT;
            charater = new List<Point>();
            Point p = new Point(x, y, image);
            this.body = p;
            charater.Add(p);
            p.Draw();
            step = 1;
            NPCType = TypesOfNPC.Zombie;
        }
    }

    class Necromant : NPC
    {
        bool rotate = true;
        public Necromant(int x, int y, char image)
        {
            direction = Direction.RIGHT;
            charater = new List<Point>();
            Point p = new Point(x, y, image);
            this.body = p;
            charater.Add(p);
            p.Draw();
            step = 1;
            NPCType = TypesOfNPC.Necromant;
        }

        public static void SpawnZombie(List<NPC> List, int x, int y)
        {
            List.Add(new Zombie(x, y, '@'));
        }

    }
    
    abstract class MapObjects
    {
        public int x;
        public int y;
        public List<Point> objects;

        public char image;
        public TypeOfMapObjects Type;
    } 

    class Keys: MapObjects
    {
        public Keys (int inputx, int inputy, char image)
        {
            objects = new List<Point>();
            Point p = new Point(inputx, inputy, image);
            objects.Add(p);
            p.Draw();
            Type = TypeOfMapObjects.Key;
            x = inputx;
            y = inputy;
        }
    }

    class Column:MapObjects
    {
        public Column(int inputx, int inputy, char image)
        {
            objects = new List<Point>();
            Point p = new Point(inputx, inputy, image);
            objects.Add(p);
            p.Draw();
            Type = TypeOfMapObjects.Column;
            x = inputx;
            y = inputy;
        }
    }

    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public char ch { get; set; }

        public Point(int XInput, int YInput, char CharImput)
        {
            x = XInput;
            y = YInput;
            ch = CharImput;
        }

        public void Draw()
        {
            DrawPoint(ch);
        }
        public void Clear()
        {
            DrawPoint(' ');
        }

        private void DrawPoint(char ch)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }

    }

    class Walls
    {
        private char ch;
        private List<Point> wall = new List<Point>();

        public Walls(int x, int y, char ch)
        {
            this.ch = ch;
            DrawHorizontal(x, 0);
            DrawHorizontal(x, y);
            DrawVertical(0, y);
            DrawVertical(x, y);
        }

        private void DrawHorizontal(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Point p = new Point(i, y, ch);
                p.Draw();
                wall.Add(p);
            }
        }
        private void DrawVertical(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Point p = new Point(x, i, ch);
                p.Draw();
                wall.Add(p);
            }
        }
    }

    class LogicMethods
    {
        public static void AddOfGameName (ref List<MapObjects> MapObject)
        {
            MapObject.Add(new Column(2, 0, 'E'));
            MapObject.Add(new Column(3, 0, 'S'));
            MapObject.Add(new Column(4, 0, 'C'));
            MapObject.Add(new Column(5, 0, 'A'));
            MapObject.Add(new Column(6, 0, 'P'));
            MapObject.Add(new Column(7, 0, 'E'));
            MapObject.Add(new Column(8, 0, '#'));
            MapObject.Add(new Column(9, 0, 'F'));
            MapObject.Add(new Column(10, 0, 'R'));
            MapObject.Add(new Column(11, 0, 'O'));

            MapObject.Add(new Column(12, 0, 'M'));
            MapObject.Add(new Column(13, 0, '#'));
            MapObject.Add(new Column(14, 0, 'D'));
            MapObject.Add(new Column(15, 0, 'U'));
            MapObject.Add(new Column(16, 0, 'N'));
            MapObject.Add(new Column(17, 0, 'G'));
            MapObject.Add(new Column(18, 0, 'E'));
            MapObject.Add(new Column(19, 0, 'O'));
            MapObject.Add(new Column(20, 0, 'N'));
        }

        public static bool IsHitListZombies(Point p, List<NPC> list)
        {            
            foreach (var w in list)
            {
                if ((p.x == w.body.x)&&(p.y==w.body.y))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsHitMapObjects(Point p, List<MapObjects> list)
        {
            foreach (var w in list)
            {
                if ((p.x == w.x) && (p.y == w.y))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsHitKeys(Point p, List<MapObjects> list)
        {
            foreach (var w in list)
            {
                if ((p.x == w.x) && (p.y == w.y)&& w.Type==TypeOfMapObjects.Key)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsHitColumns(Point p, List<MapObjects> list)
        {
            foreach (var w in list)
            {
                if ((p.x == w.x) && (p.y == w.y) && w.Type == TypeOfMapObjects.Column)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsHit(Point p, Point b)
        {
                if ((p.x == b.x) && (p.y == b.y))
                {
                    return true;
                }
            return false;
        }
    }

    class Game
    {

        public static readonly int WidthOfBattleGround = 50;
        public static readonly int HeightOfBattleGround = 25;

        public static void Lose()
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine("Кажется, Вас съели.");
            Thread.Sleep(2000);
            Console.WriteLine("Или нет.");
            Thread.Sleep(1000);
            Console.WriteLine("Последнее что Вы помните - \nМозгиииии(читать в интонации зомби)");
            Thread.Sleep(3500);
            Console.WriteLine("В любом случае, Вам это не понравилось и игра завершена.");
            Thread.Sleep(3500);
        }

        public static void Win()
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine("Отлично, Вы выбрались из темного подземелья!.");
            Thread.Sleep(2000);
            Console.WriteLine("Вы задумчиво осматриваете открывшийся вид.");
            Thread.Sleep(1000);
            Console.WriteLine("Кажется, в том подземелье было не так уж и плохо.");
            Thread.Sleep(3500);
        }
        static void BattleGroundInitialize()
        {
            Console.SetWindowSize(WidthOfBattleGround + 1, HeightOfBattleGround + 1);
            Console.SetBufferSize(WidthOfBattleGround + 1, HeightOfBattleGround + 1);
            Console.CursorVisible = false;
        }

        public static int GameLaunch(Walls walls, MainHero Hero, List<NPC> NPC, List<MapObjects> MapObject)
        {
            int timer = 0;
            int i = 1;
            int keys = 0;
            while (true)
            {
                timer++;
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    Hero.Rotation(key.Key);
                    {
                        Hero.Move(MapObject);
                        if (LogicMethods.IsHitListZombies(Hero.body, NPC)) { Lose(); return 0; }
                        if (LogicMethods.IsHitKeys(Hero.body, MapObject))
                        {
                            keys++;
                            if (keys == 3)
                            {
                                Win();
                                break;
                            }
                        }
                    }
                }
                if (LogicMethods.IsHitListZombies(Hero.body, NPC)) { Lose(); return 0; }
                if (timer == 20000)
                {
                    foreach (NPC z in NPC)
                    {
                        z.Rotation((DateTime.Now.Millisecond));
                        z.Move(MapObject);
                        Thread.Sleep(1);
                        if (LogicMethods.IsHit(z.body, Hero.body)) { Lose(); return 0; }
                    }
                    timer = 0;
                    i++;
                    if (i == 10)
                    {
                        int countOfSpawnedZombie = 0;
                        foreach (NPC N in NPC)
                        {
                            if (N.NPCType == TypesOfNPC.Necromant)
                            {
                                countOfSpawnedZombie++;
                            }
                        }
                        while (countOfSpawnedZombie > 0)
                        {
                            Necromant.SpawnZombie(NPC, 15, 15);
                            countOfSpawnedZombie--;
                        }
                        i = 0;
                    }
                }

            }
            return 0;
        }

        public static void LevelOne()
        {
            BattleGroundInitialize();
            Walls walls = new Walls(WidthOfBattleGround, HeightOfBattleGround, '#');
            MainHero Hero = new MainHero(1, 1, '&');
            List<NPC> NPC = new List<NPC>();
            List<MapObjects> MapObject = new List<MapObjects>();

            LogicMethods.AddOfGameName(ref MapObject);
            NPC.Add(new Zombie(10, 10, '@'));
            NPC.Add(new Zombie(6, 11, '@'));
            NPC.Add(new Zombie(12, 18, '@'));
            NPC.Add(new Zombie(14, 5, '@'));
            NPC.Add(new Zombie(6, 8, '@'));
            NPC.Add(new Zombie(20, 20, '@'));
            NPC.Add(new Necromant(15, 15, 'N'));

            MapObject.Add(new Keys(22, 1, 'K'));
            MapObject.Add(new Keys(15,8, 'K'));
            MapObject.Add(new Keys(1, 24, 'K'));

            MapObject.Add(new Column(1, 10, 'O'));
            MapObject.Add(new Column(1, 11, 'O'));
            MapObject.Add(new Column(2, 10, 'O'));
            MapObject.Add(new Column(1, 11, 'O'));

            MapObject.Add(new Column(20, 18, 'O'));
            MapObject.Add(new Column(18, 1, 'O'));
            MapObject.Add(new Column(13, 13, 'O'));



            GameLaunch(walls, Hero, NPC, MapObject);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game.LevelOne();
            Console.ReadKey();
        }
    }
}
