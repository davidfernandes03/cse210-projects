public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name,string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted += 1;
        if (_amountCompleted >= _target)
        {
            Console.WriteLine($"Congratulations! You have earned {_points + _bonus} points!");
            
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {_points} points!");
        }
    }

    public override bool IsComplete()
    {
        if (_amountCompleted >= _target) 
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }

    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }
}