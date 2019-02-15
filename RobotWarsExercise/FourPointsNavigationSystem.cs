using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotWarsExercise
{
    public class FourPointsNavigationSystem : INavigationSystem
    {
        public Coordinates GetNewCoords(int x, int y, char currentHeading)
        {
            Coordinates coords = new Coordinates(x, y);

            switch (currentHeading)
            {
                case 'N':
                    coords.Y++;
                    break;
                case 'E':
                    coords.X++;
                    break;
                case 'S':
                    coords.Y--;
                    break;
                case 'W':
                    coords.X--;
                    break;
            }
            return coords;
        }

        public char GetNextHeadingDirection(char currentHeading, char turnOption)
        {
            var value = getCardinalPointKey(currentHeading);

            if (turnOption == 'R')
            {
                if (value == (CardinalPointKeyValueDictionary.Count() - 1))
                    value = 0;
                else
                    value++;
            }

            if (turnOption == 'L')
            {
                if (value == (0))
                    value = CardinalPointKeyValueDictionary.Count() - 1;
                else
                    value--;
            }

            return getCardinalPointValue(value);
        }

        private Dictionary<int, char> CardinalPointKeyValueDictionary = new Dictionary<int, char>()
        {
            { 0, 'N' },
            { 1, 'E' },
            { 2, 'S' },
            { 3, 'W' },
        };

        private int getCardinalPointKey(char value)
        {
            return CardinalPointKeyValueDictionary.FirstOrDefault(d => d.Value == value).Key;
        }

        private char getCardinalPointValue(int key)
        {
            return CardinalPointKeyValueDictionary.FirstOrDefault(d => d.Key == key).Value;
        }
    }
}
