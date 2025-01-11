using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
        int number;
        do

        {   
            // Getting Users iputs
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        // Getting the sum of the inputs
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // Calculating the average of the numbers Entered
        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;

        // Calculates the Maximum number 
        int max = int.MinValue;
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        // Calculates the smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int num in numbers)
        {
            if (num > 0 && num < smallestPositive)
            {
                smallestPositive = num;
            }
        }

        // Sorts from smallest to highest
        numbers.Sort();

        // Displaying the calculated Values
        Console.WriteLine($"\nThe sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        Console.WriteLine("The sorted list is: ");
        foreach (int num in numbers)
        {
            Console.Write(num + ", ");
        }
        Console.WriteLine();
        
        
    }
}