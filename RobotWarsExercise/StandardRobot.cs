using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWarsExercise
{
    public class StandardRobot : IRobot
    {
        private readonly Coordinates _arenaBoundaries;
        private readonly INavigationSystem _navigationSystem;
        private int _x;
        private int _y;

        public StandardRobot(int xStartingPos, int yStartingPos, char startingHeadingDirection, IArena arena)
        {
            this.SetX(xStartingPos);
            this.SetY(yStartingPos);
            this.CurrentHeading = startingHeadingDirection;
            this._navigationSystem = new FourPointsNavigationSystem();
            this._arenaBoundaries = new Coordinates { X = arena.XLenght, Y = arena.YLenght };
        }

        public char CurrentHeading { get; set; }

        public int GetX()
        {
            return _x;
        }

        public void SetX(int value)
        {
            if (value >= 0 && value < 5)
                _x = value;
            else
                OnRobotReachedArenaBoundaries();
        }

        public int GetY()
        {
            return _y;
        }

        public void SetY(int value)
        {
            if (value >= 0 && value < 5)
                _y = value;
            else
                OnRobotReachedArenaBoundaries();
        }

        public void ExecuteInstruction(char instruction)
        {
            switch (instruction)
            {
                case 'M':
                    Move();
                    break;
                case 'R':
                    TurnRight();
                    break;
                case 'L':
                    TurnLeft();
                    break;
            }
        }


        private void Move()
        {
            var newPosition = this._navigationSystem.GetNewCoords(this.GetX(), this.GetY(), this.CurrentHeading);
            this.SetX(newPosition.X);
            this.SetY(newPosition.Y);
        }

        private void TurnLeft()
        {
            this.CurrentHeading = this._navigationSystem.GetNextHeadingDirection(this.CurrentHeading, 'L');
        }

        private void TurnRight()
        {
            this.CurrentHeading = this._navigationSystem.GetNextHeadingDirection(this.CurrentHeading, 'R');
        }


        public delegate void RobotReachedArenaBoundariesEventHandler(object source, EventArgs args);
        public event RobotReachedArenaBoundariesEventHandler RobotReachedArenaBoundaries;

        protected virtual void OnRobotReachedArenaBoundaries()
        {
            if (RobotReachedArenaBoundaries != null)
                RobotReachedArenaBoundaries(this, new EventArgs());
        }
    }
}
