using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWarsExercise
{
    public class Coordinates
    {
        public Coordinates()
        {

        }

        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int Y { get; set; }
        public int X { get; set; }
    }
}
