using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5
{
    class Order :IComparable
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public double Money { get; set; }

        public List<OrderDetails> orderdetails = new List<OrderDetails>();

        public Order ()
        {
            Id = 0;
            Client = string.Empty;
            Money = 0;
        }

        public Order(int id, string client)
        {
            Id = id;
            Client = client;
            
        }

        public int CompareTo(object obj)
        {
            Order a = obj as Order;

            return this.Id.CompareTo(a.Id);
        }

        public override bool Equals(object obj)
        {
            Order a = obj as Order;
            return a.Id== this.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public void getAllPrice ()
        {
            double money = 0;
            foreach (OrderDetails a in orderdetails)
            {
                money += a.getPrice();
            }
            this.Money = money;
        }

        public void addOrderDetails (string name, int number ,int price)
        {
            OrderDetails a = new OrderDetails(number, price, name);
            this.orderdetails.Add(a);
        }

        public void deleteOrderDetails()
        {
            try
            {
                Console.WriteLine("输入订单详细序号删除订单明细");
                int a = Convert.ToInt32(Console.ReadLine());
                this.orderdetails.RemoveAt(a);
                Console.WriteLine("删除成功");
                Console.WriteLine("-------------------------------------");
            }
            catch
            {
                Console.WriteLine("Wrong Input Error");
            }
        }

        public void showOrderDetails ()
        {
            Console.WriteLine("序号 名称 单价 数量");
            foreach (OrderDetails a in orderdetails)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("{0} {1} {2} {3}", this.orderdetails.IndexOf(a), a.Name, a.Price, a.Number);

            }
        }

    }
}
