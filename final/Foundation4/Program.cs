using System;

class Program
{
    static void Main(string[] args)
    {
        Activity runningActivity = new RunningActivity("22-07-2023", 30.6, 60);
        Activity cyclingActivity = new StationaryActivity("12-07-2023", 30.7, 45);
        Activity swimmingActivity = new SwimmingActivity("20-03-2023", 56, 55);
        List<Activity> activity =new List<Activity>();
        activity.Add(runningActivity);
        activity.Add(cyclingActivity);
        activity.Add(swimmingActivity);
        foreach (Activity item in activity)
        {
            Console.WriteLine(item.GetSummary());
        }


    }
}