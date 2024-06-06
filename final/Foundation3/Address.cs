
class Address 
{
    private string street;
    private string city;
    private string state;
    private string postalCode;

    public Address(string _street, string _city, string _state, string _postalCode)
    {
        street = _street;
        city = _city;
        state = _state;
        postalCode = _postalCode;
    }
      public override string ToString()
    {
        return $"{street}, {city}, {state}, {postalCode}";
    }
}