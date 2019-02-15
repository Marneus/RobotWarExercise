namespace RobotWarsExercise
{
    public interface IRobot
    {
        char CurrentHeading { get; set; }

        event StandardRobot.RobotReachedArenaBoundariesEventHandler RobotReachedArenaBoundaries;

        void ExecuteInstruction(char instruction);
        int GetX();
        int GetY();
        void SetX(int value);
        void SetY(int value);
    }
}