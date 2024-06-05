

class ChecklistGoal: Goal
{
    private int amountCompleted, target, bonus;

    public ChecklistGoal( string _shortName, string  _description, int _points, int _target, int _bonus ) : base(_shortName, _description, _points )
    {
        target =_target;
        bonus = _bonus;
        amountCompleted = 0;
    }

    public ChecklistGoal( string _shortName, string  _description, int _points, int _target, int _bonus, bool _isComplete, int _amountCompleted) : base(_shortName, _description, _points, _isComplete )
    {
        target =_target;
        bonus = _bonus;
        amountCompleted = _amountCompleted;
    }
    public  override int  RecordEvent()
    {
        amountCompleted ++;
        if (amountCompleted == target)
        {
            isComplete = true;
            Console.WriteLine("congratulations you have completed a goal");
            return points + bonus;
            
        }
        else
        {
            return points;
        }


    }
    

   public override string GetSaveString()
    {

        return $"Checklist,{shortName},{description},{points},{isComplete},{bonus},{target}{amountCompleted}";

    }








}  