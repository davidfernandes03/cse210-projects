class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    // Additional Content
    // A new list and additions to the GetRandomQuestion() method to make sure no random questions are selected until they have all been used at least once
    private List<string> _unusedQuestions;

    public ReflectingActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        // List of Prompts
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        // List of Questions
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        // Additional Content
        // Copying the full list into the unused lists
        _unusedQuestions = new List<string>(_questions);
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();

        Console.WriteLine("Consider the following prompt:");

        // Display a random prompt
        Console.WriteLine();
        DisplayPrompt();
        Console.WriteLine();

        // Pause
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        // Displat random questions
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();
        DisplayQuestions();

        DisplayEndingMessage();
    }

    public string GetRandomPrompt() 
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }

    public string GetRandomQuestion() 
    {
        if (_unusedQuestions.Count == 0)
        {
            // All prompts used, refill the list
            _unusedQuestions = new List<string>(_questions);
        }

        Random random = new Random();
        int index = random.Next(_unusedQuestions.Count);
        string selectedQuestion = _unusedQuestions[index];
        _unusedQuestions.RemoveAt(index);

        return selectedQuestion;
    }

    public void DisplayPrompt() 
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($" --- {prompt} --- ");
    }

    public void DisplayQuestions() 
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime) {
            string question = GetRandomQuestion();
            Console.Write($" > {question} ");
            
            int spinnerCounter = 0;
            string[] spinner = { "|", "/", "-", "\\" };

            while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                Console.Write(spinner[spinnerCounter]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                spinnerCounter = (spinnerCounter + 1) % spinner.Length;
            }

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            Console.WriteLine();
        }
    }
}