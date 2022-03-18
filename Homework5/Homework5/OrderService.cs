using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Homework5
{
    class OrderService : IOrderService
    {
        public List<Order> order = new List<Order>();

        public OrderService()
        {

        }

        public void showAllOrder()
        {
            foreach (Order a in order)
            {
                Console.WriteLine("订单号 客户 总金额");
                Console.WriteLine("------------------------------");
                Console.WriteLine("{0} {1} {2}", a.Id, a.Client, a.Money);
                a.showOrderDetails();
            }
        }

        public void addOrder()
        {
            try {
                Console.WriteLine("请输入订单编号：");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("请输入客户名称：");
                string client = Console.ReadLine();

                Order a = new Order(id, client);
                Console.WriteLine("输入订单项：");

                bool same = false;
                bool judge = true;

                foreach (Order o in order)
                {
                    if (o.Equals(a)) same = true;
                }
                if (same) Console.WriteLine("订单号重复");
                else
                {

                    while (!same && judge)
                    {
                        Console.WriteLine("请输入物品名称：");
                        string name = Console.ReadLine();
                        Console.WriteLine("请输入购买数量：");
                        int number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("请输入单价：");
                        int price = Convert.ToInt32(Console.ReadLine());
                        a.addOrderDetails(name, number, price);

                        Console.WriteLine("是否继续添加订单明细？");
                        string x = Console.ReadLine();
                        if (x == "n") judge = false;
                        else if (x == "y") continue;
                        else if (x != "y" && x != "n")
                        {
                            Exception e = new Exception();
                            throw e;
                        }




                    }
                    order.Add(a);
                    a.getAllPrice();
                    Console.WriteLine("建立成功");
                    Console.WriteLine("-------------------------");
                }
            }
            catch
            {
                Console.WriteLine("Wrong Input Error");
            }

        }

        public void deleteOrder()
        {

            Console.WriteLine("输入订单号删除订单或相应明细：");
            int id = Convert.ToInt32(Console.ReadLine());
            int index = 0;
            foreach (Order a in order)
            {
                if (id == a.Id) index = this.order.IndexOf(a);
            }
            Console.WriteLine("输入1删除订单，输入2继续删除订单明细");
            int choose = Convert.ToInt32(Console.ReadLine());
            switch (choose)
            {
                case 1: this.order.RemoveAt(index); Console.WriteLine("删除成功"); Console.WriteLine("-----------------"); break;
                case 2: this.order[index].showOrderDetails(); this.order[index].deleteOrderDetails(); break;
                default: Console.WriteLine("Wrong Input"); break;
            }
        }

        public void searchOrder(int i)
        {
            List<Order> o = new List<Order>();

            try
            {
                switch (i)
                {
                    case 1:
                        int minNum, maxNum;
                        Console.WriteLine("输入要查询的最小金额：");
                        minNum = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("输入要查询的最大金额：");
                        maxNum = Convert.ToInt32(Console.ReadLine());


                        var query1 = from s1 in order
                                     where maxNum > s1.Money
                                     orderby s1.Money
                                     select s1;
                        var query3 = from s3 in query1
                                     where s3.Money > minNum
                                     orderby s3.Money
                                     select s3;
                        o = query3.ToList();
                        foreach (Order b1 in o)
                        {
                            Console.WriteLine("订单号 客户 日期 总金额");
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("{0} {1} {2} ", b1.Id, b1.Client, b1.Money);
                            b1.showOrderDetails();
                        }
                        break;
                    case 2:
                        Console.WriteLine("输入客户名称：");
                        string name1 = Console.ReadLine();

                        var query2 = from s2 in order
                                     where s2.Client.Equals(name1)
                                     orderby s2.Money
                                     select s2;
                        o = query2.ToList();
                        foreach (Order b1 in o)
                        {
                            Console.WriteLine("订单号 客户 日期 总金额");
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("{0} {1} {2} ", b1.Id, b1.Client, b1.Money);
                            b1.showOrderDetails();
                        }
                        break;

                    case 3:
                        Console.WriteLine("输入订单号");
                        int id1 = Convert.ToInt32(Console.ReadLine());

                        var query4 = from s4 in order
                                     where s4.Id == id1
                                     orderby s4.Money
                                     select s4;
                        o = query4.ToList();
                        foreach (Order b1 in o)
                        {
                            Console.WriteLine("订单号 客户 日期 总金额");
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("{0} {1} {2} ", b1.Id, b1.Client, b1.Money);
                            b1.showOrderDetails();
                        }
                        break;


                    default: throw new Exception();
                }
            } catch
            {
                Console.WriteLine("Wrong Input Error");
            }
           
        }
        public void changeOrder()
        {
            Console.WriteLine("输入订单号");
            int id = Convert.ToInt32(Console.ReadLine());
            int index = 0;
            foreach(Order a in order)
            {
                if (a.Id == id) index = order.IndexOf(a); 
            }
            Console.WriteLine("请输入客户名称");
            string name = Console.ReadLine();
            order[index].Client = name;
            
        }




    }

       

        
    }

