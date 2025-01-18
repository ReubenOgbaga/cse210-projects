using System;

class Program
{
    static void Main(string[] args)  
    {
        Journal journal = new Journal();
        string[] prompts = new string[]
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "Did you study your scriptures today?",
            "What did you do today that youu regret doing?",
            "What can you do to improve today's work?"
        };

        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Search the journal");
            Console.WriteLine("4. Save the journal to a JSON file");
            Console.WriteLine("5. Load the journal from a JSON file");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Random rand = new Random();
                    string prompt = prompts[rand.Next(prompts.Length)];
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(prompt, response);
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter a date or keyword to search: ");
                    string searchTerm = Console.ReadLine();
                    journal.SearchEntries(searchTerm);
                    break;

                case "4":
                    Console.Write("Enter filename to save (e.g., journal.json): ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToJson(saveFilename);
                    break;

                case "5":
                    Console.Write("Enter filename to load (e.g., journal.json): ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromJson(loadFilename);
                    break;

                case "6":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
