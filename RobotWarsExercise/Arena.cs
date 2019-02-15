using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWarsExercise
{
    public class Arena5x5 : IArena
    {
        public Arena5x5()
        {
            this.XLenght = 5;
            this.YLenght = 5;
        }

        public int XLenght { get; set; }
        public int YLenght { get; set; }
    }
}
