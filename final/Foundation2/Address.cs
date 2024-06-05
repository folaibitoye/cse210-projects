

class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string _streetAddress, string _city, string _state, string _country)
    {
        streetAddress = _streetAddress;
        city          = _city;
        state         = _state;
        country       = _country;
    }


    public string GetState()
    {
        return state;
    }
    public void  SetState(string _state)
    {
        state = _state;
    }
    public string GetStreetAddress()
    {
        return streetAddress;
    }
    public void  SetStreetAddress(string _streetAddress )
    {
        streetAddress = _streetAddress;
    }
    public string GetCountry()
    {
        return country;
    }
    public void  SetCountry(string  _country)
    {
        country =  _country;
    }

    public string GetCity()
    {
        return city;
    }
    public void SetCity(string  _city)
    {
        city =_city;
    }

    public bool isUs()
    {
        return country.ToLower() == "usa";
     
    }
    public string GetFullAddress()
    {
        return $"{streetAddress} - {city} - {state} - {country}";
    }

}