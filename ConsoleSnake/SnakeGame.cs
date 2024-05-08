using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    public class Snake
    {
        public class Part
        {
            public int X, Y, OldX, OldY;
        }

        public int HeadX, HeadY;
        public List<Part> parts = new List<Part>();
    }

    public class SnakeGame
    {
        private bool isStarted;
        private int width;
        private int height;
        private Snake snake;
        private Direction direction = Direction.Stop;
        private int futX = 0, futY = 0;
        private Random random = new Random();
        static int fps = 10;

        public SnakeGame(int height, int width)
        {
            this.height = height;
            this.width = width;
            Init();
        }

        private void Init()
        {
            snake = new Snake()
            {
                HeadX = width / 2,
                HeadY = height / 2,
                parts = new List<Snake.Part>()
                {
                    new Snake.Part() { X = (width / 2) - 1, Y = height / 2, OldX = (width / 2) - 1, OldY = height / 2 }
                }
            };

            Console.CursorVisible = false;
            isStarted = true;
            direction = Direction.Stop;

            DrawBorder();
            SetFruit();
            Game();
        }

        private void SetFruit()
        {
            futX = random.Next(1, width - 1);
            futY = random.Next(1, height - 1);
        }

        private void DrawBorder()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.SetCursorPosition(j, i);
                    if (j == 0 && i == 0) 
                    { 
                        Console.Write("╔"); 
                        continue; 
                    }
                    if (j == width - 1 && i == 0)
                    {
                        Console.Write("╗");
                        continue;
                    }
                    if (j == 0 && i == height - 1) 
                    { 
                        Console.Write("╚"); 
                        continue; 
                    }
                    if (j == width - 1 && i == height - 1)
                    {
                        Console.Write("╝");
                        continue;
                    }
                    if (i == 0 || i == height - 1)
                    {
                        Console.Write("═");
                        continue;
                    }
                    if ((j == 0 || j == width - 1))
                    {
                        Console.Write("║");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
        }

        private void Draw()
        {
            Console.SetCursorPosition(snake.HeadX, snake.HeadY);
            Console.Write("*");

            foreach (var part in snake.parts)
            {
                Console.SetCursorPosition(part.OldX, part.OldY);
                Console.Write(" ");
                Console.SetCursorPosition(part.X, part.Y);
                Console.Write("*");
            }

            Console.SetCursorPosition(futX, futY);
            Console.Write("@");
        }

        private void Input()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (direction != Direction.Down &&
                            direction != Direction.Up)
                            direction = Direction.Up;
                        else if (direction == Direction.Up)
                            fps += 5;
                        else if (direction == Direction.Down)
                            fps -= 5;
                        break;
                    case ConsoleKey.DownArrow:
                        if (direction != Direction.Up && 
                            direction != Direction.Down)
                            direction = Direction.Down;
                        else if (direction == Direction.Down)
                            fps += 5;
                        else if (direction == Direction.Up)
                            fps -= 5;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (direction != Direction.Right &&
                            direction != Direction.Left)
                            direction = Direction.Left;
                        else if (direction == Direction.Left)
                            fps += 5;
                        else if (direction == Direction.Right)
                            fps -= 5;
                        break;
                    case ConsoleKey.RightArrow:
                        if (direction != Direction.Left && 
                            direction != Direction.Right)
                            direction = Direction.Right;
                        else if (direction == Direction.Right)
                            fps += 5;
                        else if (direction == Direction.Left)
                            fps -= 5;
                        break;
                }
            }
        }

        private void Logic()
        {
            if (direction != Direction.Stop)
            {
                if (snake.parts.Exists(part => 
                part.X == snake.HeadX && 
                part.Y == snake.HeadY))
                {
                    isStarted = false;
                }
            }

            int oldX = snake.HeadX, oldY = snake.HeadY;

            if (direction == Direction.Up)
                snake.HeadY--;
            else if (direction == Direction.Down)
                snake.HeadY++;
            else if (direction == Direction.Left)
                snake.HeadX--;
            else if (direction == Direction.Right)
                snake.HeadX++;

            if (direction != Direction.Stop)
            {
                if (snake.HeadX == width || snake.HeadX == 0 || snake.HeadY == 0 || snake.HeadY == height - 1)
                {
                    isStarted = false;
                }

                for (int i = 0; i < snake.parts.Count; i++)
                {
                    if (i == 0)
                    {
                        snake.parts[i].OldX = snake.parts[i].X;
                        snake.parts[i].OldY = snake.parts[i].Y;
                        snake.parts[i].X = oldX;
                        snake.parts[i].Y = oldY;
                        continue;
                    }

                    snake.parts[i].OldX = snake.parts[i].X;
                    snake.parts[i].OldY = snake.parts[i].Y;

                    snake.parts[i].X = snake.parts[i - 1].OldX;
                    snake.parts[i].Y = snake.parts[i - 1].OldY;
                }

                Console.SetCursorPosition(0, height + 2);
                Console.Write(snake.parts.Count + "    Контроль - Стрелки");

                if (snake.HeadX == futX && snake.HeadY == futY)
                {
                    snake.parts.Add(new Snake.Part() 
                    { 
                        X = snake.parts[snake.parts.Count - 1].OldX, 
                        Y = snake.parts[snake.parts.Count - 1].OldY 
                    });
                    SetFruit();
                }
            }
        }

        private void Game()
        {
            while (isStarted)
            {
                Draw();
                Input();
                Logic();
                try
                {
                    Thread.Sleep(1000 / fps);
                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Начать заново? Для повтора нажмите ENTER для выхода ESC");

            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter)
                {
                    Init();
                    Game();
                    break;
                }
                if (key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
