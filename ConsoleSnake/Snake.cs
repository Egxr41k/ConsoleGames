using System.Collections.Generic;

namespace Snake
{
    public class Snaker
    {
        private readonly List<SnakePart> _parts;

        public List<SnakePart> Parts => _parts;

        public Snaker(int startX, int startY)
        {
            _parts = new List<SnakePart>
            {
                new SnakePart 
                { 
                    X = startX, 
                    Y = startY, 
                    OldX = startX, 
                    OldY = startY 
                }
            };
        }
    }

    public class SnakePart
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int OldX { get; set; }
        public int OldY { get; set; }
    }
}
