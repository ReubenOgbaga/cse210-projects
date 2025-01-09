using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage? ");
        double gradePercentage = Convert.ToDouble(Console.ReadLine());

        string letter = "";
        string sign = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else if (gradePercentage < 60)
        {
            letter = "F";
        }

        if (letter != "F")
        {
            int lastDigit = (int)gradePercentage % 10;
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            if (letter == "A" && sign == "+")
            sign = "";
        }

        
        Console.WriteLine($"Your letter grade is: {letter}{sign}");
        
        if (gradePercentage > 70)
        {
            Console.WriteLine("Congratulations you passed the Course.");
        }
        else
        {
            Console.WriteLine("You did n0t pass this time but you can if you work harder next time.");      
        }
    }
}