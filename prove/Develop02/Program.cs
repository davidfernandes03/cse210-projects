using System;

// Exceeding Requirements - A new option to save favorites answers
// A new method DisplayFavorites() in Journal.cs
// Option 5 display only the favorite entries
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool proceed = true;
        while (proceed)
        {
            Console.WriteLine("Select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Favorites");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    // Write
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string answer = Console.ReadLine();
                    
                    Entry newEntry = new Entry(prompt, answer);
                    journal.AddEntry(newEntry);

                    // Additional Content: Favorite
                    Console.WriteLine("Mark as favorite? (1 - Yes / 0 - No): ");
                    string favoriteChoice = Console.ReadLine();

                    if (favoriteChoice == "1")
                    {
                        newEntry._favorite = true;
                    }
                    break;
                
                case "2":
                    // Display
                    journal.DisplayAll();
                    break;
                
                case "3":
                    // Load
                    Console.WriteLine("What is the filename? ");
                    string loadFileName = Console.ReadLine();

                    if (File.Exists(loadFileName))
                    {
                        journal.LoadFromFile(loadFileName);
                    }
                    else
                    {
                        Console.WriteLine("File not found. Please check the filename and try again.");
                    }
                    break;
                
                case "4":
                    // Save
                    // WARNING - If the saved file doesn't appear with the other files, it is probably inside the 'bin' directory
                    // Location - Develop02/bin/Debug/net8.0
                    Console.Write("What is the filename? ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;
                
                case "5":
                    // Additional Content: Display Favorites
                    journal.DisplayFavorites();
                    break;

                case "6":
                    // Quit
                    proceed = false;
                    break;
                
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
        // Leaving the program
        Console.WriteLine("Goodbye!");
    }
}