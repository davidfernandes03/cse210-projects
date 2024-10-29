using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running activity1 = new Running(DateTime.Now, 30, 3);
        activities.Add(activity1);

        Cycling activity2 = new Cycling(DateTime.Now, 45, 20.0);
        activities.Add(activity2);

        Swimming activity3 = new Swimming(DateTime.Now, 25, 40);
        activities.Add(activity3);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}