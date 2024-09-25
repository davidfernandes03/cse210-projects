public class Job
{   
    // Responsabilities
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    // Behaviors
    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}