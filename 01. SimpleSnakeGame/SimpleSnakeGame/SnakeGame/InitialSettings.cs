using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public enum Direction { Up, Down, Left, Right };
    class InitialSettings
    {
        public InitialSettings()
        {
            Width = 15;
            Height = 15;
            Speed = 17;
            Score = 0;
            HighestScore = 0;
            Points = 1;
            GameOver = false;
            direction = Direction.Down;
        }
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int HighestScore { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Direction direction { get; set; }
    }
}
