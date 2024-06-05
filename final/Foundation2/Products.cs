

class Product
{
    private string name;
    private string id;
    private double price;

    private int quantity;
     public Product(string _name, string _id, double _price, int _quantity)
    {
        name = _name;
        id = _id;
        price = _price;
        quantity = _quantity;
    }
     public string GetName()
    {
        return name;
    }
     public void setName(string _name)
    {
       name =_name;
    }

    public string GetProductId()
    {
        return id ;
    }
     public void SetProductId(string _id)
    {
        id = _id;
    }

    public double GetPrice()
    {
        return price;
    }
    public void SetPrice(double _price)
    {
        price = _price;
    }

    public int GetQuantity()
    {
        return quantity;
    }
     public void SetQuantity(int _quantity)
    {
        quantity = _quantity;
    }

    public double GetTotalPrice()
    {
        return price * quantity;
    }
}