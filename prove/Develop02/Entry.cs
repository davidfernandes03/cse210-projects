using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public bool _favorite;

    public Entry(string promptText, string entryText)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _promptText = promptText;
        _entryText = entryText;
        _favorite = false;
    }

    public void Display()
    {
        Console.WriteLine($"Date : {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine();
    }
}