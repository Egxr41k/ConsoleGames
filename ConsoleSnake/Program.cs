using Snake;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    class Program
    {
        private static int width = 80;
        private static int height = 40;

        public static void Main(string[] args)
        {
            Console.SetWindowSize(width, height + 5);
            SnakeGame snakeGame = new SnakeGame(height, width);
        }
    }
}