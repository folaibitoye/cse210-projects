using System;

class Program
{
    static void Main(string[] args)
    {
        Address usa_address = new Address("123 Main Street", "Anytown", "NY", "USA");
        Address non_usa_address = new Address("456 Elm Street", "Some City", "Province A", "Canada");
        Customer usa_customer = new Customer("James Brown", usa_address);
        Customer non_usa_customer = new Customer("Jane Smith", non_usa_address);


        Product product_1 = new Product("Iphone6", "W001", 30000.0, 3);
        Product product_2 = new Product("23inch tv", "G001", 25000.0, 2);
        Product product_3 = new Product("Hp Laptop", "D001", 17000.0, 4);
        Product product_4 = new Product("Air condition", "Wdd3", 120.0, 3);


        Order order1 = new Order(usa_customer);
        order1.AddProduct(product_1);
        order1.AddProduct(product_2);

        Order order2 = new Order(non_usa_customer);
        order2.AddProduct(product_3);
        order2.AddProduct(product_4);
        

      

        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Order 1 Total Price: $" + order1.CalculateTotalPrice());

        Console.Write("\nOrder 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.Write("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Order 2 Total Price: $" + order2.CalculateTotalPrice());
        
    }
}