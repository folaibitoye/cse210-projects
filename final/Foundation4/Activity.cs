

abstract class  Activity
{
    protected string date;
    // protected string name;
    protected int length;

    public Activity(string _date, int _length)
    {
        // name = _name;
        date = _date;
        length = _length;
    }

    public abstract double getDistance();
    public abstract double getSpeed();
    public abstract double getPace();

    public abstract string GetSummary();
    

    
}