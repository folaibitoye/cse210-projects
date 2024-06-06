

class RunningActivity : Activity
{
    private double distance;

    public RunningActivity(  string _date, double _distance, int _length) : base(_date, _length)
    {
        distance = _distance;
    }
    public override double getDistance()
    {
        return distance;
    }
    public override double getSpeed()
    {
        return (distance / length) * 60;
    }
    public override double getPace()
    {
       return  Math.Round(length / distance);
    }
    public override string GetSummary()
    {
        return $"Activity Name: Running\n Date: {date}\n Length(Min):{length}\n Distance:{getDistance()}KM\n Speed:{getSpeed()}mph\n Pace:{getPace()}min per km\n";
    }



    
}