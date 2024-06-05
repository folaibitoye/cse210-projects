using System;

class Program
{
    static void Main(string[] args)
    {
        int userInput;
        GoalManager goalManager = new GoalManager();
        goalManager.DisplayPlayerInfo();
        Console.Write("");
       

        do
        {
            goalManager.Start();
            Console.Write("Select a menu of your choice");
            userInput = int.Parse(Console.ReadLine());
            if (userInput == 1)
            {
                goalManager.CreateGoals();                
                
            }
            else if (userInput == 2)
            {
                goalManager.GoalDetails();
                
            }
            else if (userInput == 3)
            {
                goalManager.SaveGoals();
                
            }
            else if (userInput == 4)
            {
                goalManager.LoadGoals();

            }
            else if (userInput == 5)
            {
                goalManager.RecordEvent();   
                                
                
            }
          
        } while (userInput!= 6);

        // while (userInput!= 6)
        // {
        //     if (userInput == 1)
        //     {
        //         goalManager.CreateGoals();                
                
        //     }
        //     else if (userInput == 2)
        //     {
        //         goalManager.GoalDetails();
                
        //     }
        //     else if (userInput == 3)
        //     {
        //         goalManager.SaveGoals();
                
        //     }
        //     else if (userInput == 4)
        //     {
        //         goalManager.LoadGoals();

        //     }
        //     else if (userInput == 5)
        //     {
        //         goalManager.RecordEvent();   
                                
                
        //     }
        //     else
        //     {
        //         return;
        //     }
            
        // }
    }
}
