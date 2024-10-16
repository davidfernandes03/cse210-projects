using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment mathA1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathA1.GetSummary());
        Console.WriteLine(mathA1.GetHomeworkList());

        WritingAssignment writA1 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writA1.GetSummary());
        Console.WriteLine(writA1.GetWritingInformation());
    }
}