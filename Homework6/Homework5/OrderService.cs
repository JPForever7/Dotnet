using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace Homework5
{
    [Serializable]
    public class OrderService 
    {
        public List<Order> order = new List<Order>();


        public OrderService()
        {

        }
        public void Export()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("order.xml", FileMode.Create))
            {
                xs.Serialize(fs, this.order);
            }   
        }

        public void import()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("order.xml", FileMode.Open))
            {
                List<Order> lo = (List<Order>)xs.Deserialize(fs);
            
            }
        }
        

        public string showAllOrder()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Order o in order)
            {
                sb.Append(String.Format("{0},{1},{2}\n", o.Client, o.Id, o.Money));
                sb.Append(o.showOrderDetails());                
            }
            return sb.ToString();

        }
            
        

        public bool addOrder(Order a)
        {
                foreach (Order o in order)
                {
                if (o.Equals(a)) return false;
                }
            return true;
        }

        public bool deleteOrder(int id)
        {
            int index = 0;
            foreach (Order a in order)
            {
                if (id == a.Id) index = this.order.IndexOf(a);
                else
                {
                    return false;
                }
            }
           
             this.order[index].deleteOrderDetails();
            this.order.RemoveAt(index);
            return true;
            
        }

        public List<Order> searchOrder(int id1)
        {
            List<Order> o = new List<Order>();

            var query4 = from s4 in order
                         where s4.Id == id1
                         orderby s4.Money
                         select s4;
            o = query4.ToList();
            return o;
        }

        public List<Order>  searchOrder(int maxNum,int minNum)
        {
            List<Order> o = new List<Order>();
            var query1 = from s1 in order
                         where maxNum > s1.Money
                         orderby s1.Money
                         select s1;
            var query3 = from s3 in query1
                         where s3.Money > minNum
                         orderby s3.Money
                         select s3;
            o = query3.ToList();
            return o;
        }

        public List<Order> searchOrder(String name1)
        {
            List<Order> o = new List<Order>();
            var query2 = from s2 in order
                         where s2.Client.Equals(name1)
                         orderby s2.Money
                         select s2;
            o = query2.ToList();
            return o;
        }

        public bool changeOrder(int id, string name)
        {
           
            int index = 0;
            foreach(Order a in order)
            {
                if (a.Id == id) index = order.IndexOf(a);
                else
                {
                    return false;
                }

          
            }
           
            order[index].Client = name;
            return true;
            
        }




    }

       

        
    }

