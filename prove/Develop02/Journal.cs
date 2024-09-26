using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    // Add a new entry
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Display all entries
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
        }
        else
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
    }

    // Saving to a file
    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
        Console.WriteLine($"Entries saved to: {Path.GetFullPath(fileName)}");
    }

    // Loading a file
    public void LoadFromFile(string fileName)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            Entry entry = new Entry(parts[1], parts[2]);
            entry._date = parts[0];
            _entries.Add(entry);
        }
    }

    public void DisplayFavorites()
    {
        Console.WriteLine("Favorite Entries:");
        bool hasFavorites = false;

        foreach (Entry entry in _entries)
        {
            if (entry._favorite)
            {
                entry.Display();
                hasFavorites = true;
            }
        }

        if (!hasFavorites)
        {
            Console.WriteLine("No favorite entries found.");
        }
    }
}