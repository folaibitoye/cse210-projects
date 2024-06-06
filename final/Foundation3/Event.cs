

class Event
{
    protected string eventTitle;
    protected string description;
    protected DateTime date;
    protected TimeSpan time;
    protected Address address;


    



     public Event(string _eventTitle, string _description, DateTime _date, TimeSpan _time, Address _address )
    {
        eventTitle     = _eventTitle;
        description    = _description;
        date           = _date;
        address        = _address;


    }
    public virtual string GetStandardDetails()
    {
        return $"Event Title: {eventTitle}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time.ToString()}\nAddress: {address.ToString()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Type: Generic Event\nEvent Title: {eventTitle}\nDate: {date.ToShortDateString()}";
    }
}
