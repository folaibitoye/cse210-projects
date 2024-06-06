

class SwimmingActivity : Activity
{
    private int laps;

    public SwimmingActivity(string _date, int _laps,  int _length) : base(_date, _length)
    {
        laps = _laps;
    }
     public override double getDistance()
    {
        return laps * 50 /1000;
    }

    public override double getSpeed()
    {
        return (getDistance()/length) *60;
    }
    public override double getPace()
    {
        return Math.Round(length / getDistance()); 
       
    }
     public override string GetSummary()
    {
        return $"Activity Name: Swimming\n Date: {date}\n Length(Min):{length}\n Distance:{getDistance()}KM\n Speed:{getSpeed()}mph\n Pace:{getPace()}min per km\n";
    }
    
}