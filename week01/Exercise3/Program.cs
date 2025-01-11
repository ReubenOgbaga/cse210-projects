using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        Random random = new Random();
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            int magicNumber = random.Next(1, 101);
            int guess = 0;
            int attempts = 0;
            Console.WriteLine("Welcome to the Magic Number Game!");
            Console.WriteLine("I have picked a random number between 1 and 100. Can you guess it?");
            
    
            while (guess != magicNumber)
            {
                Console.Write("Enter your guess: ");
                guess = int.Parse(Console.ReadLine());
                attempts++;

                if (guess == magicNumber)
                {
                    Console.WriteLine($"Congratulations! You guessed the magic number in {attempts} attempts!");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Low! guess a higher number.");
                }
                else
                {
                    Console.WriteLine("High! Try guessing a lower number.");
                }
            }

    
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }
        Console.WriteLine("Thank you for playing! Goodbye!");
    }
}