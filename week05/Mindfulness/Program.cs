using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all activities
class Activity
{
    protected string Name;
    protected string Description;

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    } 

    public void Start()
    {
        Console.WriteLine($"Starting {Name}...");
        Console.WriteLine(Description);
        Console.Write("Enter duration (seconds): ");
        int duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
        Run(duration);
        Console.WriteLine($"Good job! You completed {Name} for {duration} seconds.");
        Thread.Sleep(3000);
    }

    protected virtual void Run(int duration)
    {
        // Overridden in subclasses
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(". ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Breathing Activity
class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity helps you relax by breathing deeply.") { }

    protected override void Run(int duration)
    {
        for (int i = 0; i < duration / 2; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(2);
            Console.WriteLine("Breathe out...");
            ShowSpinner(2);
        }
    }
}

// Reflection Activity
class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    
    public ReflectionActivity() : base("Reflection Activity", "This activity helps you reflect on meaningful experiences.") { }

    protected override void Run(int duration)
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        ShowSpinner(5);
    }
}

// Listing Activity
class ListingActivity : Activity
{
    public ListingActivity() : base("Listing Activity", "This activity helps you list things you are grateful for.") { }

    protected override void Run(int duration)
    {
        Console.WriteLine("List as many items as you can:");
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("- ");
            responses.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {responses.Count} items!");
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };

            if (activity == null) break;
            activity.Start();
        }

        Console.WriteLine("Goodbye! Thanks for using the Mindfulness Program.");
    }
}
