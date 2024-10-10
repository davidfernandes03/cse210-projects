using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating Addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("London Street 57", "London", "England");

        // Creating Customers
        Customer customer1 = new Customer("Lily Ramsley", address1);
        Customer customer2 = new Customer("Stanley Ford", address2);

        // Creating Products for the first order
        Product product1 = new Product("Laptop", 155, 1200.99, 1);
        Product product2 = new Product("Mouse", 148, 25.99, 1);
        Product product3 = new Product("Chair", 90, 48.99, 2);

        List<Product> order1Products = new List<Product> { product1, product2, product3 };

        // First Order
        Order order1 = new Order(order1Products, customer1);

        
        // Creating Products for the second order
        Product product4 = new Product("Iphone", 203, 899.99, 1);
        Product product5 = new Product("Headphones", 37, 60.99, 3);

        List<Product> order2Products = new List<Product> { product4, product5 };

        // Second Order
        Order order2 = new Order(order2Products, customer2);


        // Displays first order
        Console.WriteLine("Order 1");

        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 40)));
        Console.WriteLine(order1.DisplayPackingLabel());

        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 40)));
        Console.WriteLine(order1.DisplayShippingLabel());

        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice()}\n");

        Console.WriteLine(string.Concat(Enumerable.Repeat("=|=", 14)));

        // Displays second order

        Console.WriteLine("\nOrder 2");

        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 40)));
        Console.WriteLine(order2.DisplayPackingLabel());

        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 40)));
        Console.WriteLine(order2.DisplayShippingLabel());

        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice()}\n");
    }
}