namespace AndreyAndBilliard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AndreyAndBilliard
    {
        class Customer
        {
            public string Name { get; set; }
            public Dictionary<string, int> Order { get; set; }
            public decimal Bill
            {
                get
                {
                    var sum = 0m;
                    foreach (var item in Order)
                    {
                        sum += priceList[item.Key] * item.Value;
                    }
                    return sum;
                }
            }

                    public Customer(string name, string product, int quantity)
            {
                Name = name;
                Order = new Dictionary<string, int>();
                if (Order.ContainsKey(product))
                {
                    Order[product] += quantity;
                }
                else
                {
                    Order[product] = quantity;
                }
            }
        }

        static Dictionary<string, decimal> priceList = new Dictionary<string, decimal>();
        static List<Customer> customers = new List<Customer>();

        static void Main()
        {
            var numOfGoods = int.Parse(Console.ReadLine());

            InputPriceList(numOfGoods);

            AddOrder();

            PrintBill();
        }

        private static void PrintBill()
        {
            foreach (var customer in customers.OrderBy(n => n.Name))
            {
                Console.WriteLine(customer.Name);
                foreach (var product in customer.Order)
                {
                    Console.WriteLine($"-- {product.Key} - {product.Value}");
                }
                Console.WriteLine($"Bill: {customer.Bill:F2}");
            }

            Console.WriteLine($"Total bill: {customers.Select(n => n.Bill).Sum():F2}");
        }

        private static void AddOrder()
        {
            var clientsOrder = string.Empty;

            while (!(clientsOrder = Console.ReadLine()).Equals("end of clients"))
            {
                var clientsOrderSplit = clientsOrder.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var clientName = clientsOrderSplit[0];
                var clientProduct = clientsOrderSplit[1];
                var productQuantity = int.Parse(clientsOrderSplit[2]);

                if (customers.Any(n => n.Name == clientName))
                {
                    if (customers.Any(n => n.Name == clientName && n.Order.ContainsKey(clientProduct)))
                    {
                        var index = customers.FindIndex(c => c.Name==clientName);
                        customers[index].Order[clientProduct] += productQuantity;
                    }
                    else
                    {
                        if (priceList.ContainsKey(clientProduct))
                        {
                            var index = customers.FindIndex(c => c.Name == clientName);
                            customers[index].Order[clientProduct] = productQuantity;
                        }
                    }
                }
                else
                {
                    if (priceList.ContainsKey(clientProduct))
                    {
                        customers.Add(new Customer(clientName, clientProduct, productQuantity));
                    }
                }
            }
        }

        private static void InputPriceList(int numOfGoods)
        {
            for (int i = 0; i < numOfGoods; i++)
            {
                var input = Console.ReadLine().Split('-');
                var goodName = input[0];
                var goodPrice = input[1];
                priceList[goodName] = decimal.Parse(goodPrice);
            }
        }
    }
}
