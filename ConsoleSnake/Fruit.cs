using System;

namespace Snake
{
    public class Fruit
    {
        public int X { get; set; }
        public int Y { get; set; }
        private readonly Random _random;

        public Fruit(int maxX, int maxY)
        {
            _random = new Random();
            X = _random.Next(1, maxX - 1);
            Y = _random.Next(1, maxY - 1);
        }

        public void Respawn(int maxX, int maxY)
        {
            X = _random.Next(1, maxX - 1);
            Y = _random.Next(1, maxY - 1);
        }
    }
}
