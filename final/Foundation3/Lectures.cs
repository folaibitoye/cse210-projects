

class Lectures : Event
{
    private string speaker;
    private int  capacity;
    public Lectures(string _speaker, string _description, string _eventTitle, DateTime _date, TimeSpan _time, Address _address, int  _capacity): base (_eventTitle,  _description ,_date, _time,   _address)
    {
        speaker = _speaker;
        capacity = _capacity;

    }
     public override string GetFullDetails()
    {
        return $"Type: Lecture\n{base.GetFullDetails()}Speaker:{speaker}\nCapacity: {capacity}\n";
    }
      public override string GetShortDescription()
    {
        return $"Type: Lecture Event\nEvent Title: {eventTitle}\nDate: {date.ToShortDateString()}\n";
    }
       public override string GetStandardDetails()
    {
        return $"Event Title: {eventTitle}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time.ToString()}\nAddress: {address.ToString()}\n";
    }
}
