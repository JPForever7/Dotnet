using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5
{
    [Serializable]
    public class Order :IComparable
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public double Money { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();


            foreach (OrderDetails detail in orderdetails)
            {
                sb.Append(String.Format("{0},{1},{2}\n",detail.Name,detail.Number,detail.Price));
            }
            return sb.ToString();
        }

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
                
                
                this.orderdetails.Clear();
                
            }
            catch
            {
               
            }
        }

        public string showOrderDetails ()
        {
            StringBuilder sb = new StringBuilder();


            foreach (OrderDetails detail in orderdetails)
            {
                sb.Append(String.Format("{0},{1},{2}\n", detail.Name, detail.Number, detail.Price));
            }
            return sb.ToString();
        }

    }
}
