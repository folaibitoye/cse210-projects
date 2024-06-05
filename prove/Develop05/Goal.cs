abstract class Goal
{
    protected int   points;
    protected string  shortName;
    protected string  description;
    protected bool isComplete;

    public  Goal(string _shortName, string _description, int _point)
    {
        shortName = _shortName;
        description = _description;
        points = _point;
        isComplete = false;
    }
    public  Goal(string _shortName, string _description, int _point, bool _isComplete)
    {
        shortName = _shortName;
        description = _description;
        points = _point;
        isComplete = _isComplete;
    }
    public abstract int RecordEvent();
   
    public bool IsComplete()
    {
        return isComplete;
    }

    private char IsCompleteChar()
    {
        if(isComplete)
            return 'X';
        else
            return ' ';
    }

    public string Display()
    {
        return $"[{IsCompleteChar()}] {shortName} - {description}";
    }
   

    public abstract  string GetSaveString();
    
    
}



        //     switch (userInput)
        // {
            
        //     case 1:
        //         break;
            
        //     case 2:
        //         break;

        //     case 3:
        //         break;

        //     case 4:
        //         break;

        //     case 5:
        //         break;

        //     case 6:                
        //         break;










        
      