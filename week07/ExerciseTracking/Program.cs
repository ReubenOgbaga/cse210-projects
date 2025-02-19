using System;
using System.Collections.Generic;

abstract class Activity
{
    protected string _date;
    protected int _duration; // in minutes

    public Activity(string date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public abstract double GetDistance();
    public double GetSpeed() => (GetDistance() / _duration) * 60;
    public double GetPace() => _duration / GetDistance();

    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_duration} min): Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace {GetPace():0.0} min per km";
    }
}

class Running : Activity
{
    private double _distance; // in km

    public Running(string date, int duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
}

class Cycling : Activity
{
    private double _speed; // in kph

    public Cycling(string date, int duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * _duration) / 60;
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int duration, int laps) : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * 50) / 1000.0; // Convert meters to km
}

class Program
{
    static void Main()
    {   
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
        string date = DateTime.Now.ToString("dd MMM yyyy");

        List<Activity> activities = new List<Activity>
        {
            new Running(date, 30, 4.8),
            new Cycling(date, 45, 20),
            new Swimming(date, 25, 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
