using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Prompting user for Username
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Prompting user for their favourite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Squaring the user's favourite number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }


    }
    
    
}