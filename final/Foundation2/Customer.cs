

class Customer
{
    private string name;
    private Address address;
    public Customer(string _name, Address _address)
    {
        name = _name;
        address = _address;
    }

    public string GetName()
    {
        return name;
    }
    public string GetAddress()
    {
        return address.GetFullAddress();
    }
     public void SetName(string _name)
    {
        name = _name;
    }
    public void SetAddress(Address _address)
    {
        address = _address;
    }




    public bool isInTheUs()
    {
        return address.isUs();        
  
    }
}