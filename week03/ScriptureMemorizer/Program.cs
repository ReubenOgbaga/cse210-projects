using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        Scripture scripture = new Scripture(
            new Reference("Romans", 8, 28, 29),
        @"And he that searcheth the hearts knoweth what is the mind of the Spirit,
        because he maketh intercession for the saints according to the will of God.
        And we know that all things work together for good to them that love God,
        to them who are the called according to his purpose."
        );
            
        
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            // Display progress tracking
            int hiddenCount = scripture.HiddenWordCount();
            int totalCount = scripture.TotalWordCount();
            double progress = (double)hiddenCount / totalCount * 100;
            Console.WriteLine($"\nWords hidden: {hiddenCount}/{totalCount} ({progress:F1}% memorized)");

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }

        Console.Clear();
        Console.WriteLine("All words are hidden! Good job memorizing!");
    }
}


public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            words.Add(new Word(word));
        }
    }

  public void HideRandomWords()
    {
        Random random = new Random();
        List<Word> visibleWords = words.FindAll(word => !word.IsHidden);

        if (visibleWords.Count > 0)
        {
            int indexToHide = random.Next(visibleWords.Count);
            visibleWords[indexToHide].Hide();
        }
    }
    public bool AllWordsHidden()
    {
        return words.TrueForAll(word => word.IsHidden);
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", words.ConvertAll(word => word.GetDisplayText()));
        return $"{reference.GetDisplayText()} {scriptureText}";
    }

    public int HiddenWordCount()
    {
        int count = 0;
        foreach (var word in words)
        {
            if (word.IsHidden) count++;
        }
        return count;
    }

     public int TotalWordCount()
    {
        return words.Count;
    }
}

public class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int? endVerse;

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        return endVerse == null
            ? $"{book} {chapter}:{startVerse}"
            : $"{book} {chapter}:{startVerse}-{endVerse}";
    }
}

public class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        this.hidden = false;
    }

    public bool IsHidden => hidden;

    public void Hide()
    {
        hidden = true;
    }

    public string GetDisplayText()
    {
        return hidden ? new string('_', text.Length) : text;
    }
}
