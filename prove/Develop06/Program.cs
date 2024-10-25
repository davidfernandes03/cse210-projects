using System;

// Additional Content - New variable (_level) and method (CheckLevelUp)
// For each 100 points, the user levels up.
// Some other methods received additional content for this.
class Program
{
    static void Main(string[] args)
    {
        GoalManager startProgram = new GoalManager(new List<Goal>(), 0);
        startProgram.Start();
    }
}