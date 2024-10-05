using System;

// Additional Content - A list that stores scriptures with their references
// Then a random scripture will be chosen for the user.
class Program
{
    static void Main(string[] args)
    {
        // Additional Content - List of Scriptures
        List<Scripture> scripturesList = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),

            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),

            new Scripture(new Reference("Genesis", 1, 1), "In the beginning God created the heavens and the earth."),

            new Scripture(new Reference("3 Nephi", 12, 16), "Therefore let your light so shine before this people, that they may see your good works and glorify your Father who is in heaven.")
        };

        // Additional Content - Select a random item from 'scripturesList'
        Random random = new Random();
        int randomIndex = random.Next(scripturesList.Count);

        Scripture scripture = scripturesList[randomIndex];

        bool allWordsHidden = false;

        // Main loop
        while (true)
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");

            // Get user input
            string input = Console.ReadLine();

            // If the user types 'quit', exit the loop and end the program
            if (input.ToLower() == "quit")
            {
                break;
            }

            // Check if the scripture is already completely hidden
            if (scripture.IsCompletelyHidden())
            {
                allWordsHidden = true;
            }
            else
            {
                scripture.HideRandomWords(3);
            }

            // If all words are hidden, the program ends on the next Enter
            if (allWordsHidden)
            {
                break;
            }
        }
    }
}