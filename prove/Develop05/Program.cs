using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();
}

[Serializable]
class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return IsCompleted ? "[X] " + Name : "[ ] " + Name;
    }
}

[Serializable]
class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetStatus()
    {
        return "[∞] " + Name;
    }
}

[Serializable]
class ChecklistGoal : Goal
{
    public int RequiredCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, int points, int requiredCount, int bonusPoints) 
        : base(name, points)
    {
        RequiredCount = requiredCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            CurrentCount++;
            if (CurrentCount >= RequiredCount)
            {
                IsCompleted = true;
                return Points + BonusPoints;
            }
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return IsCompleted ? "[X] " + Name + " (Completed)" : 
            "[ ] " + Name + " (Completed " + CurrentCount + "/" + RequiredCount + ")";
    }
}

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalScore = 0;

    static void Main(string[] args)
    {
        LoadData();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest");
            Console.WriteLine("Total Score: " + totalScore);
            Console.WriteLine("1. List Goals");
            Console.WriteLine("2. Create Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save & Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListGoals();
                    break;
                case "2":
                    CreateGoal();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveData();
                    return;
            }
        }
    }

    static void ListGoals()
    {
        Console.Clear();
        Console.WriteLine("Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
    }

    static void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("Create a new goal:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string type = Console.ReadLine();

        Goal goal = null;
        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, points);
                break;
            case "2":
                goal = new EternalGoal(name, points);
                break;
            case "3":
                Console.Write("Required count: ");
                int requiredCount = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, points, requiredCount, bonusPoints);
                break;
        }

        if (goal != null)
        {
            goals.Add(goal);
            Console.WriteLine("Goal created successfully.");
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    static void RecordEvent()
    {
        Console.Clear();
        Console.WriteLine("Record an event:");
        ListGoals();
        Console.Write("Select a goal to record (number): ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            int pointsEarned = goals[index].RecordEvent();
            totalScore += pointsEarned;
            Console.WriteLine($"Event recorded. Points earned: {pointsEarned}");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    static void SaveData()
    {
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write))
        {
            formatter.Serialize(stream, goals);
            formatter.Serialize(stream, totalScore);
        }
    }

    static void LoadData()
    {
        if (File.Exists("data.bin"))
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("data.bin", FileMode.Open, FileAccess.Read))
            {
                goals = (List<Goal>)formatter.Deserialize(stream);
                totalScore = (int)formatter.Deserialize(stream);
            }
        }
    }
}
