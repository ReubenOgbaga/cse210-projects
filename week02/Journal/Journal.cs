using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private string password = "zAch3us!123"; // Default password (can be customized)

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

    public void SaveToJson(string filename)
    {
        if (!ValidatePassword())
        {
            Console.WriteLine("Incorrect password. Unable to save the journal.");
            return;
        }

        string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);

        Console.WriteLine("Journal saved successfully to JSON!");
    }

    public void LoadFromJson(string filename)
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

        string json = File.ReadAllText(filename);
        entries = JsonSerializer.Deserialize<List<Entry>>(json);

        Console.WriteLine("Journal loaded successfully from JSON!");
    }

    private bool ValidatePassword()
    {
        Console.Write("Enter the password: ");
        string inputPassword = Console.ReadLine();
        return inputPassword == password;
    }
}
