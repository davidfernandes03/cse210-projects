using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int num = -1;

        while (num != 0)
        {
            Console.Write("Enter a number: ");
            num = int.Parse(Console.ReadLine());
            
            if (num != 0)
            {
                numbers.Add(num);
            }
        }

        // Variables to find the sum, average and largest number from the list 
        int sum = 0;
        double average = 0;
        int large = int.MinValue;

        foreach (int n in numbers)
        {
            // Get the sum
            sum += n;

            // Get the largest number
            if (n > large)
            {
                large = n;
            }
        }

        // Get the average
        if (numbers.Count > 0) // Avoids division by 0
        {
            average = (double)sum / numbers.Count;
        }

        // Show results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {large}");
    }
}