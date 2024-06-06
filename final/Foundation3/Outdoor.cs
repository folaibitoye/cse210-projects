


class Outdoor : Event
{
    private string weather;
    
    

    public Outdoor(string _weather, string _eventTitle, string _description, DateTime _date, TimeSpan _time, Address _address): base (_eventTitle,  _description ,_date, _time,  _address)
    {
        weather  = _weather;

    }
   
    public override string GetFullDetails()
    {
        return $"Type: Outdoor\n{base.GetFullDetails()}Weather Forecast: {weather}\n";
    }
      public override string GetShortDescription()
    {
        return $"Type: Outdoor Event\nEvent Title: {eventTitle}\nDate: {date.ToShortDateString()}\n";
    }
    public override string GetStandardDetails()
    {
        return $"Event Title: {eventTitle}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time.ToString()}\nAddress: {address.ToString()}\n";
    }



}