using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private string password = "zAch3us123"; 

    public void AddEntry(string prompt, string response)
    {
        entries.Add(new Entry(prompt, response));
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries available.");
            return;
        }

        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SearchEntries(string searchTerm)
    {
        Console.WriteLine("\nSearch Results:");
        bool found = false;

        foreach (Entry entry in entries)
        {
            if (entry.Date.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                entry.Prompt.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                entry.Response.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(entry);
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No entries found matching the search term.");
        }
    }

    public void SaveToFile(string filename)
    {
        if (!ValidatePassword())
        {
            Console.WriteLine("Incorrect password. Unable to save the journal.");
            return;
        }

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                outputFile.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }

        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile(string filename)
    {
        if (!ValidatePassword())
        {
            Console.WriteLine("Incorrect password. Unable to load the journal.");
            return;
        }

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                entries.Add(new Entry(parts[1], parts[2]) { Date = parts[0] });
            }
        }

        Console.WriteLine("Journal loaded successfully!");
    }

    private bool ValidatePassword()
    {
        Console.Write("Enter the password: ");
        string inputPassword = Console.ReadLine();
        return inputPassword == password;
    }
}
