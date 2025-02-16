
using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    protected string _name;
    protected int _points;

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
    public int GetPoints() => _points;
}

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, int points) : base(name, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Goal '{_name}' completed! You earned {_points} points.");
    }

    public override string GetDetailsString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {_name}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_name}|{_points}|{_isComplete}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded: {_name}. You earned {_points} points.");
    }

    public override string GetDetailsString()
    {
        return $"[∞] {_name}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_name}|{_points}";
    }
}

class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, int points, int target, int bonus) : base(name, points)
    {
        _timesCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
        Console.WriteLine($"Recorded: {_name}. You earned {_points} points.");
        if (_timesCompleted == _target)
        {
            Console.WriteLine($"Bonus achieved! Extra {_bonus} points awarded.");
        }
    }

    public override string GetDetailsString()
    {
        return $"[{(_timesCompleted >= _target ? "X" : " ")}] {_name} (Completed {_timesCompleted}/{_target})";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_points}|{_timesCompleted}|{_target}|{_bonus}";
    }
}

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\nEternal Quest - Goal Tracker");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            
            string choice = Console.ReadLine();
            Console.Clear();
            
            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": RecordEvent(); break;
                case "3": DisplayGoals(); break;
                case "4": Console.WriteLine($"Your Score: {_score} points"); break;
                case "5": SaveGoals(); break;
                case "6": LoadGoals(); break;
                case "7": return;
                default: Console.WriteLine("Invalid option, try again."); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter choice: ");
        
        string choice = Console.ReadLine();
        Console.Write("Enter Goal Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1": _goals.Add(new SimpleGoal(name, points)); break;
            case "2": _goals.Add(new EternalGoal(name, points)); break;
            case "3":
                Console.Write("Enter Target Completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter Bonus Points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid selection.");
                break;
        }

        Console.WriteLine("Goal added successfully!");
    }

    private void RecordEvent()
    {
        Console.WriteLine("Select a goal to record progress:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.Write("Enter goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
            _score += _goals[index].GetPoints();
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    private void DisplayGoals()
    {
        Console.WriteLine("Your Goals:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    private void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        _goals.Clear();
        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            _score = int.Parse(reader.ReadLine());
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts[0] == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(parts[1], int.Parse(parts[2])));
                }
                else if (parts[0] == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(parts[1], int.Parse(parts[2])));
                }
                else if (parts[0] == "ChecklistGoal")
                {
                    _goals.Add(new ChecklistGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[4]), int.Parse(parts[5])));
                }
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }
}

class Program
{
    static void Main()
    {
        
        Console.WriteLine("Hello World! This is the EternalQuest Project.");
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
