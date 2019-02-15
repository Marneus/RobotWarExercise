namespace RobotWarsExercise
{
    public interface INavigationSystem
    {
        char GetNextHeadingDirection(char currentHeading, char turnOption);
        Coordinates GetNewCoords(int x, int y, char currentHeading);
    }
}