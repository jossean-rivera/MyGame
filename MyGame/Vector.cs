using System;

namespace MyGame
{
    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Length
        {
            get
            {
                return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            }
        }
    }
}
