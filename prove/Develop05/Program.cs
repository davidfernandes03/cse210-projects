using System;

// Additional Content
// A new list and additions to the GetRandomQuestion() method inside Reflecting Activity Class.
// It make sure no random questions are selected until they have all been used at least once

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Breathing Activity");
            Console.WriteLine("  2. Reflecting Activity");
            Console.WriteLine("  3. Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "4") 
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            switch (choice)
            {
                case "1":
                    BreathingActivity activity1 = new BreathingActivity();
                    activity1.Run();
                    break;

                case "2":
                    ReflectingActivity activity2 = new ReflectingActivity();
                    activity2.Run();
                    break;

                case "3":
                    ListingActivity activity3 = new ListingActivity();
                    activity3.Run();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    continue; 
            }
        }
    }
}