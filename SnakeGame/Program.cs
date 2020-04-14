﻿using System;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        private static Snake snake;
        private static PlayGround ground;

        static async Task Main()
        {
            GameSetup();
            SetupConsole();

            while (true)
            {
                DrawAllComponents();

                var key = Console.ReadKey(true).Key;
                ClearSnakeTail();
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        snake.MoveingSnake(Direction.Down,ground);
                        break;
                    case ConsoleKey.UpArrow:
                        snake.MoveingSnake(Direction.Up, ground);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.MoveingSnake(Direction.Left, ground);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.MoveingSnake(Direction.Right, ground);
                        break;
                    case ConsoleKey.F1:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }

                await Task.Delay(100);
            }
        }

        private static void GameSetup()
        {
            ground = new PlayGround(25, 50, 20);
            snake = new Snake(new Point(40, 15));
        }

        private static void SetupConsole()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WindowWidth = 51;
            Console.BufferWidth = 51;
            Console.WindowHeight = 26;
            Console.BufferHeight = 26;
        }

        private static void DrawAllComponents()
        {
            DrawVerticalBoarders();
            DrawHorisantalBoarders();
            DrawFoods();
            DrawSnake();
        }

        private static void ClearSnakeTail()
        {
            var Last = snake.SnakeBodyPoints.ToList().Last();
            Console.SetCursorPosition(Last.Left, Last.Top);
            Console.Write(" ");
        }

        private static void DrawFoods()
        {
            foreach (var item in ground.FoodPoints.ToList())
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(item.Left, item.Top);
                Console.Write("+");
            }
        }

        private static void DrawSnake()
        {
            var list = snake.SnakeBodyPoints.ToList();
            foreach (var item in list)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(item.Left, item.Top);
                if (item == list.First())
                {
                    Console.Write("O");
                }
                else
                {
                    Console.Write("o");
                }
            }
        }

        private static void DrawHorisantalBoarders()
        {
            for (int w = 1; w < ground.Width; w++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(w, 0);
                Console.Write("_");
                Console.SetCursorPosition(w, ground.Height - 1);
                Console.Write("_");
            }
        }

        private static void DrawVerticalBoarders()
        {
            for (int h = 1; h < ground.Height; h++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, h);
                Console.Write("|");
                Console.SetCursorPosition(ground.Width, h);
                Console.Write("|");
            }
        }

    }
}
