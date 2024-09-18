using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        Console.Write("What is your guess? ");
        int guessNumber = int.Parse(Console.ReadLine());

        while (guessNumber != magicNumber)
        {
            if (guessNumber > magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }

            Console.Write("What is your guess? ");
            guessNumber = int.Parse(Console.ReadLine());
        }

        // Message for guess the correct number
        Console.WriteLine("You guessed it!");
    }
}