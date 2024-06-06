

class Reception : Event
{
    private string rsvp;
    public Reception(string _rsvp, string _eventTitle, string _description, DateTime _date,  TimeSpan _time, Address _address): base (_eventTitle,  _description ,_date, _time,  _address)
    {
       rsvp = _rsvp;
    }

   public override string GetFullDetails()
    {
        return $" Type: Reception \n{base.GetFullDetails()}RSVP Email: {rsvp}\n";
    }
      public override string GetShortDescription()
    {
        return $"Type: Reception Event\nEvent Title: {eventTitle}\nDate: {date.ToShortDateString()}\n";
    }
    public override string GetStandardDetails()
    {
        return $"Event Title: {eventTitle}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time.ToString()}\nAddress: {address.ToString()}\n";
    }
    
}