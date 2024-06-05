
class SimpleGoal : Goal
{


    public SimpleGoal(string _shortName, string _description, int _points) : base(_shortName, _description, _points)
    {

    }

    public SimpleGoal(string _shortName, string _description, int _points, bool isComplete) : base(_shortName, _description, _points, isComplete)
    {
                
    }

    public override int RecordEvent()
    {
        isComplete = true;
        Console.WriteLine(" Congratulations you have completed a goal.");
        return points;
    }

    public override string GetSaveString()
    {

        return $"Simple,{shortName},{description},{points},{isComplete}";

    }



}

//  Console.Write("Loading");
//         for (int i = 5; i > 0; i --)
//         {           
//             Console.Write(".");
//             Thread.Sleep(2000);
//         }