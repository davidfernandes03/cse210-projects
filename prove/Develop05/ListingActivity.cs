using System.ComponentModel;

class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") 
    {
        // List of Prompts
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run() 
    {
        DisplayStartingMessage();
        Console.WriteLine();

        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($" --- {prompt} --- ");
        Console.Write("\nYou may begin in: ");
        ShowCountDown(7);
        
        Console.WriteLine();

        List<string> userItems = GetListFromUser();
        _count = userItems.Count;

        if (_count == 1) {
            Console.WriteLine($"You listed {_count} item!");
        }
        else {
            Console.WriteLine($"You listed {_count} items!");
        }

        DisplayEndingMessage();
    }

    public string GetRandomPrompt() 
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }

    public List<string> GetListFromUser() 
    {

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime) {
            Console.Write("> ");
            string item = Console.ReadLine();
            items.Add(item);
        }

        return items;
    }
}