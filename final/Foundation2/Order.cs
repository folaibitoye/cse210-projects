

class Order
{
    private List<Product> _productList = new List<Product>();
    private Customer customer;

    public Order(Customer  _customer)
    {
        customer = _customer;
        List<Product> productsList  = _productList;
    }
    public void AddProduct(Product product)
    {
        _productList.Add(product);
    }

    public double CalculateTotalPrice()
    {
        double total_price = 0;
        foreach (var product in _productList)
        {
            total_price += product.GetTotalPrice();
        }

        double shipping_cost = customer.isInTheUs() ? 5 : 35;
        return total_price + shipping_cost;
    }

    public string GetPackingLabel()
    {
        string packing_label = "";
        foreach (var product in _productList)
        {
            packing_label += $"Product Name: {product.GetName()} (Product ID: {product.GetProductId()})\n";
        }
        return packing_label;
    }

    public string GetShippingLabel()
    {
        return $"Customer Name: {customer.GetName()}\nAddress:{customer.GetAddress()}";
    }
 

    
}