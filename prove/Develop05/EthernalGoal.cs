

class EternalGoal: Goal
{
    

    public EternalGoal(string shortName, string  description, int  points) : base(shortName, description, points)
    {

    }

    public  override int  RecordEvent()
    {
        Console.WriteLine("congratulations you have completed a goal.");
        return points;

    }
   

    public override string GetSaveString()
    {

        return $"Eternal,{shortName},{description},{points}";

    }
   
}