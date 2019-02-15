using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWarsExercise.Test
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;

        [TestCase("0,2,E", "MLMRMMMRMMRR", "4,1,N,0")]
        [TestCase("4,4,S", "LMLLMMLMMMRMM", "0,1,W,1")]
        [TestCase("2,2,W", "MLMLMLM RMRMRMRM", "2,2,N,0")]
        [TestCase("1,3,N", "MMLMMLMMMMM", "0,0,S,3")]
        public void Lunch_MovementInstructions_ReturnExpectedReportValues(string robotInitialValues, string movementInstructions, string expected)
        {
            // Arrange
            string[] initvuales = robotInitialValues.Split(',');

            _game = new Game(new StandardRobot
                (Convert.ToInt32(initvuales[0]),
                Convert.ToInt32(initvuales[1]),
                Convert.ToChar(initvuales[2]),
                new Arena5x5()));

            // Act
            var result = _game.Launch(movementInstructions);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
