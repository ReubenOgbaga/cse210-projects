using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        // Creating videos
        Video video1 = new Video("Python OOP Basics", "Tech Guru", 600);
        Video video2 = new Video("Intro to Machine Learning", "AI Wizard", 1200);
        Video video3 = new Video("Web Development Tips", "Code Master", 900);

        // Adding comments
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Can you make a video on inheritance?"));

        video2.AddComment(new Comment("Dave", "Excited to learn more!"));
        video2.AddComment(new Comment("Eve", "What libraries are best for ML?"));
        video2.AddComment(new Comment("Frank", "Awesome content!"));

        video3.AddComment(new Comment("Grace", "I love your tutorials."));
        video3.AddComment(new Comment("Hank", "CSS tips would be helpful too."));
        video3.AddComment(new Comment("Ivy", "This is so well explained!"));

        // Storing videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Displaying video info
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public override string ToString()
    {
        return $"{CommenterName}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($" - {comment}");
        }
        Console.WriteLine("\n" + new string('-', 40) + "\n");
    }
}

