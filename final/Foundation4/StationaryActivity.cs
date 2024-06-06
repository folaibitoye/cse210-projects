

class StationaryActivity : Activity
{
    private double speed;

    public StationaryActivity(string _date, double _speed,  int _length) :base(_date, _length)
    {
        speed = _speed;
    }
    public override double getDistance()
    {
        return speed * (length / 60.0);
        // return length * 50 /1000;
    }
    public override double getSpeed()
    {
        return speed;
    }
    public override double getPace()
    {
        return Math.Round(60/speed);
    }
     public override string GetSummary()
    {
        return $"Activity Name: Cycling\n Date: {date}\n Length(Min):{length}\n Distance:{getDistance()}KM\n Speed:{getSpeed()}mph\n Pace:{getPace()}min per km\n";
    }
}