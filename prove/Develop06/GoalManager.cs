public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    // Additional Content - Variable _level
    private int _level;

    public GoalManager(List<Goal> goals, int score)
    {
        _goals = goals;
        _score = score;
        _level = 1;
    }

    public void Start()
    {   
        while (true)
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoalDetails();
                    break;

                case "3":
                    SaveGoals();
                    break;

                case "4":
                    LoadGoals();
                    break;

                case "5":
                    RecordEvent();
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 20)));
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level {_level}");
        Console.WriteLine();
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetType().Name}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goal has been set...");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());


        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }

        else if (choice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }

        else if (choice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.WriteLine("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex];

            // Exit the method if the goal is already complete
            if (selectedGoal.IsComplete())
            {
                Console.WriteLine("This goal is already complete.");
                return;
            }

            selectedGoal.RecordEvent();

            // For Simple Goal
            if (selectedGoal is SimpleGoal)
            {
                SimpleGoal simpleGoal = (SimpleGoal)selectedGoal;
                _score += simpleGoal.GetPoints();
            }

            // For Eternal Goal
            else if (selectedGoal is EternalGoal)
            {
                EternalGoal eternalGoal = (EternalGoal)selectedGoal;
                _score += eternalGoal.GetPoints();
            }

            // For Checklist Goal
            else if (selectedGoal is ChecklistGoal)
            {
                ChecklistGoal checklistGoal = (ChecklistGoal)selectedGoal;
                _score += checklistGoal.IsComplete() ? checklistGoal.GetPoints() + checklistGoal.GetBonus() : checklistGoal.GetPoints();
            }

            // Additional Content - Calling CheckLevelUp()
            CheckLevelUp();

        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_level);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(fileName);

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);

        _goals.Clear();

        for (int i = 2; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string goalType = parts[0];
            string[] goalDetails = parts[1].Split(",");

            // For Simple Goal
            if (goalType == "SimpleGoal")
            {
                bool isComplete = bool.Parse(goalDetails[3]);
                SimpleGoal simpleGoal = new SimpleGoal(goalDetails[0], goalDetails[1], int.Parse(goalDetails[2]));

                if (isComplete)
                {
                    simpleGoal.MarkAsComplete();
                }

                _goals.Add(simpleGoal);
            }

            // For Eternal Goal
            else if (goalType == "EternalGoal")
            {
                EternalGoal eternalGoal = new EternalGoal(goalDetails[0], goalDetails[1], int.Parse(goalDetails[2]));
                _goals.Add(eternalGoal);
            }

            // For Checklist Goal
            else if (goalType == "ChecklistGoal")
            {
                ChecklistGoal checkGoal = new ChecklistGoal(goalDetails[0], goalDetails[1], int.Parse(goalDetails[2]), int.Parse(goalDetails[4]), int.Parse(goalDetails[3]));
                int amountCompleted = int.Parse(goalDetails[5]);

                checkGoal.SetAmountCompleted(amountCompleted);

                _goals.Add(checkGoal);
            }
        }
    }

    // Additional Content - New method for _level
    private void CheckLevelUp()
    {
        int levelUpTaget = 100;
        int newLevel = (_score / levelUpTaget) + 1;

        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"You've leveled up to Level {_level}!");
        }
    }
}