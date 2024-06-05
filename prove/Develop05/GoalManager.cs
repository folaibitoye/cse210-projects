
class GoalManager
{
    private int score;
    private List<Goal> listGoals = new List<Goal>();
    public GoalManager()
    {
    }
    public void Start()
    {
        List<string> menuList = new List<string>
        {
            "Menu Options",
            "   1. Create New Goal",
            "   2. List Goals",
            "   3. Save Goals",
            "   4. Load Goals",
            "   5. Record Event",
            "   6. Quit",
        };

        foreach (string menu in menuList)
        {
            Console.WriteLine(menu);
        }

    }

    public void CreateGoals()
    {
        string shortName;
        int input;
        string descripton;
        int point;
        int bonus;
        int target;


        List<string> typeOfGoals = new List<string>
        {

            "The Type of Goals are",
            "      1. Simple Goal",
            "      2. Enternal Goal",
            "      3. Checklist goal",
            "Which Type of goal would you like to create?"

        };
        foreach (string goal in typeOfGoals)
        {
            Console.WriteLine(goal);
        }
        input = int.Parse(Console.ReadLine());
        if (input == 1)
        {
            Console.WriteLine("What is the name of your goal");
            shortName = Console.ReadLine();
            Console.WriteLine("What is a short descripton of your goal?");
            descripton = Console.ReadLine();
            Console.WriteLine("What is a the number of point associated with this goal?");
            point = int.Parse(Console.ReadLine());
            SimpleGoal simpGoal = new SimpleGoal(shortName, descripton, point);
            listGoals.Add(simpGoal);
            
        }
        else if (input == 2)
        {
            Console.WriteLine("What is the name of your goal");
            shortName = Console.ReadLine();
            Console.WriteLine("What is a short descripton of your goal?");
            descripton = Console.ReadLine();
            Console.WriteLine("What is a the number of point associated with this goal?");
            point = int.Parse(Console.ReadLine());
            EternalGoal entGoal = new EternalGoal(shortName, descripton, point);
            listGoals.Add(entGoal);
           
        }
        else if (input == 3)
        {
            Console.WriteLine("What is the name of your goal");
            shortName = Console.ReadLine();
            Console.WriteLine("What is a short descripton of your goal?");
            descripton = Console.ReadLine();
            Console.WriteLine("What is a the number of point associated with this goal?");
            point = int.Parse(Console.ReadLine());
            Console.WriteLine("How many times does this goal needs to be accomplished for a bonus");
            bonus = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the bonus for accomplishing this goal that many times?");
            target = int.Parse(Console.ReadLine());
            ChecklistGoal chGoal = new ChecklistGoal(shortName, descripton, point, target, bonus);
            listGoals.Add(chGoal);
         
        }
        
           
    }
 
       
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {score} Point");
    }

  

    public void GoalDetails()
    {

        foreach (Goal goal in listGoals)
        {
            Console.WriteLine(goal.Display());
        }
    }
    public void RecordEvent()
    {
        int counter = 1;
        foreach (Goal goal in listGoals)
        {
            
            Console.WriteLine($"{counter} {goal.Display()}");
        }
        Console.WriteLine(" what goal do you want to record event for");
        int choice = int.Parse(Console.ReadLine());
        choice --;
        if (!listGoals[choice].IsComplete() )
        {
        score += listGoals[choice].RecordEvent();
            
        }
        else
        {
            Console.WriteLine("The goal is already completed");
        }       
    }
    public void SaveGoals()
    {
        Console.WriteLine("Enter the filename: ");
        string filename = Console.ReadLine();
        Console.Write("Saving ");
        for (int i = 5; i > 0; i --)
        {
           
            Console.Write(".");
            Thread.Sleep(3000);
        }
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(score);
            foreach (Goal goal in listGoals)
            {

                outputFile.WriteLine($"{goal.GetSaveString()}");

            }
        }
        Console.WriteLine("");
       

    }
    public void LoadGoals()
    {
        listGoals.Clear();          
        Console.WriteLine("What is the filen name");
        string filename = Console.ReadLine();      
        List<string> records = File.ReadAllLines(filename).ToList();
        score = int.Parse(records[0]);
         Console.Write("Loading");
        for (int i = 7; i > 0; i --)
        {           
            Console.Write(".");
            Thread.Sleep(250);
        }
        foreach (string record in records)
        {
            string[] newList = record.Split(",");
            string name = newList[1];
            string description = newList[2];
            int point = int.Parse(newList[3]);
            switch (newList[0])
            {
                
                case "Simple":
                    bool complete = bool.Parse(newList[4]);
                    SimpleGoal simple = new SimpleGoal( name,description,point,complete);
                    listGoals.Add(simple);
                    break;

                case "Checklist":                
                    complete = bool.Parse(newList[4]);
                    int bonus = int.Parse(newList[5]);
                    int target  = int.Parse(newList[6]);
                    int amountCompleted = int.Parse(newList[7]);
                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, point,target,bonus, complete, amountCompleted);
                    listGoals.Add(checklistGoal);
                    break;

                case "Eternal":
                    EternalGoal eternalGoal = new EternalGoal(name, description,point);
                    listGoals.Add(eternalGoal);
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("Your file has been looded Successfully thank you for usein the loading section.");


        
        
        
        
        }

    }




}