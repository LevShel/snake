using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Programm
    {
        static void Main(string[] args)
        {
            // Размеры консоли
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(100, 50);
            Console.CursorVisible = false;


            // Отрисовка игрового поля
            Walls walls = new Walls(100, 50);
            walls.Draw();
            /*
            HorLine upLine = new HorLine(5, 95, 5, '-');
            upLine.Draw();
            HorLine downLine = new HorLine(5, 95, 45, '-');
            downLine.Draw();
            VertLine leftLine = new VertLine(5, 5, 45, '|');
            leftLine.Draw();
            VertLine rightLine = new VertLine(95, 5, 45, '|');
            rightLine.Draw();
            */

            // Спавн змейки
            Point p = new Point(25, 25, 'O');
            Snake snake = new Snake(p, 2, Direction.RIGHT);
            snake.Draw();

            // Спавн еды
            FoodCreator foodCreator = new FoodCreator(90, 40, '*');
            Point food = foodCreator.CreateFood();
            food.Draw();

            // Управление и еда
            while (true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                    {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(45, 15);
                    Console.WriteLine("THE END");
                    Console.SetCursorPosition(45, 17);
                    Console.WriteLine("by ШелЛ");
                    Thread.Sleep(-1);
                    //break;
                    }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandJob(key.Key);
                }
            }


        }
    }
}