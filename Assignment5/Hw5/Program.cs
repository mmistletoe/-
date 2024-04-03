using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    public string OrderNumber { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderDetails> Details { get; set; }

    public Order(string orderNumber, string customerName)
    {
        OrderNumber = orderNumber;
        CustomerName = customerName;
        Details = new List<OrderDetails>();
    }

    public override bool Equals(object obj)
    {
        if (obj is Order order)
        {
            return OrderNumber == order.OrderNumber && CustomerName == order.CustomerName;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(OrderNumber, CustomerName);
    }

    public override string ToString()
    {
        return $"Order Number: {OrderNumber}, Customer: {CustomerName}, Total Amount: {TotalAmount}";
    }
}

public class OrderDetails
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public OrderDetails(string productName, int quantity, decimal price)
    {
        ProductName = productName;
        Quantity = quantity;
        Price = price;
    }

    public override bool Equals(object obj)
    {
        if (obj is OrderDetails details)
        {
            return ProductName == details.ProductName && Quantity == details.Quantity && Price == details.Price;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ProductName, Quantity, Price);
    }

    public override string ToString()
    {
        return $"Product: {ProductName}, Quantity: {Quantity}, Price: {Price}";
    }
}

public class OrderService
{
    private List<Order> orders = new List<Order>();

    public void AddOrder(Order order)
    {
        if (orders.Contains(order))
        {
            throw new ArgumentException("Order already exists.");
        }
        orders.Add(order);
    }

    public void DeleteOrder(string orderNumber)
    {
        var order = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
        if (order == null)
        {
            throw new ArgumentException("Order not found.");
        }
        orders.Remove(order);
    }

    public void UpdateOrder(Order updatedOrder)
    {
        var existingOrder = orders.FirstOrDefault(o => o.OrderNumber == updatedOrder.OrderNumber);
        if (existingOrder == null)
        {
            throw new ArgumentException("Order not found.");
        }
        orders.Remove(existingOrder);
        orders.Add(updatedOrder);
    }

    public List<Order> SearchOrders(Func<Order, bool> predicate)
    {
        return orders
            .Where(predicate)
            .OrderByDescending(o => o.TotalAmount)
            .ToList();
    }

    public void SortOrders(Func<Order, object> keySelector)
    {
        orders.Sort((x, y) => Comparer<object>.Default.Compare(keySelector(x), keySelector(y)));
    }

    public void SortOrdersByCustom(Func<Order, IComparable> keySelector)
    {
        orders.Sort((x, y) => keySelector(x).CompareTo(keySelector(y)));
    }
}


class Program
{
    static void Main(string[] args)
    {
        // 创建OrderService实例  
        OrderService orderService = new OrderService();

        // 示例查询：按订单号查询订单  
        List<Order> ordersByNumber = orderService.SearchOrders(o => o.OrderNumber == "12345");
        Console.WriteLine("Orders by Order Number:");
        foreach (var order in ordersByNumber)
        {
            Console.WriteLine($"Order Number: {order.OrderNumber}, Customer: {order.CustomerName}, Total: {order.TotalAmount}");
        }

        // 示例查询：按客户名称查询订单  
        List<Order> ordersByCustomer = orderService.SearchOrders(o => o.CustomerName == "John Doe");
        Console.WriteLine("\nOrders by Customer Name:");
        foreach (var order in ordersByCustomer)
        {
            Console.WriteLine($"Order Number: {order.OrderNumber}, Customer: {order.CustomerName}, Total: {order.TotalAmount}");
        }
 
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}