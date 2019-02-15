using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWarsExercise
{
    public class Game
    {
        public Game(IRobot robot)
        {
            this.Robot = robot;
            this.Robot.RobotReachedArenaBoundaries += OnRobotWentOutOfTheArena;
        }

        public string Launch(string instructionsString)
        {
            var instructions = instructionsString.Replace(" ", string.Empty).ToCharArray();

            foreach (var instruction in instructions)
            {
                this.Robot.ExecuteInstruction(instruction);
            }

            return string.Format("{0},{1},{2},{3}",
                Robot.GetX(), Robot.GetY(), Robot.CurrentHeading, RobotPenaltyPoints);
        }

        private IRobot Robot { get; set; }
        private int RobotPenaltyPoints { get; set; }

        private void OnRobotWentOutOfTheArena(object source, EventArgs e)
        {
            RobotPenaltyPoints++;
        }
    }
}
