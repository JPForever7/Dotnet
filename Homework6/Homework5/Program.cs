using System;
using System.Collections.Generic;

namespace Homework5
{
    class Program
    {
        //封装方法 实现只在program类中使用console
        public void ADD(OrderService a)
        {
            try
            {
                Console.WriteLine("请输入订单编号：");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("请输入客户名称：");
                string client = Console.ReadLine();

                Order b = new Order(id, client);
                if (a.addOrder(b)) {             
                    Console.WriteLine("输入订单项：");

                    
                    bool judge = true;

                    while (judge)
                    {
                        Console.WriteLine("请输入物品名称：");
                        string name = Console.ReadLine();
                        Console.WriteLine("请输入购买数量：");
                        int number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("请输入单价：");
                        int price = Convert.ToInt32(Console.ReadLine());
                        b.addOrderDetails(name, number, price);

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
                    a.order.Add(b);
                    Console.WriteLine("建立成功");
                    Console.WriteLine("-------------------------");
                }
            }
            catch
            {
                Console.WriteLine("Wrong Input Error");
            }
        }

        public void DELETE(OrderService a)
        {
            Console.WriteLine("输入订单号删除订单或相应明细：");
            int id = Convert.ToInt32(Console.ReadLine());
            a.deleteOrder(id);
           
        }

        public void SEARCH(OrderService o,int i)
        {
            switch(i)
            {
                case 1:
                    int minNum, maxNum;
                    Console.WriteLine("输入要查询的最小金额：");
                    minNum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("输入要查询的最大金额：");
                    maxNum = Convert.ToInt32(Console.ReadLine());

                    List<Order> a = o.searchOrder(maxNum, minNum);

                    foreach (Order b1 in a)
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
                    List<Order> b =o.searchOrder(name1);
                    foreach (Order b1 in b)
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

                    List<Order> c = o.searchOrder(id1);
                    foreach (Order b1 in c)
                    {
                        Console.WriteLine("订单号 客户 日期 总金额");
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("{0} {1} {2} ", b1.Id, b1.Client, b1.Money);
                        b1.showOrderDetails();
                    }
                    break;     
            }
        }

        public void SHOWORDERS(OrderService os)
        {
            Console.WriteLine(os.showAllOrder());
        }

        public void Change(OrderService os)
        {

            Console.WriteLine("输入订单号");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入客户名称");
            string name = Console.ReadLine();
            if (os.changeOrder(id,name))
            {
                Console.WriteLine("Success");
            }
            Console.WriteLine("Fail");
        } 
        static void Main(string[] args)
        {
            OrderService a = new OrderService();
            Program manager = new Program();
            bool judge_ = true;
            while (judge_)
            {
                Console.WriteLine("输入1增加订单，输入2删除订单，输入3查询订单，输入4显示所有订单，输入5修改订单，输入6退出");
                string choose1 = Console.ReadLine();
                switch (choose1)
                {
                    case "1": manager.ADD(a); break;
                    case "2": manager.DELETE(a); break;
                    case "3": Console.WriteLine("输入1根据订单金额查询订单，输入2根据客户名查询订单,输入3跟据订单编号查询"); int i = Convert.ToInt32(Console.ReadLine()); a.searchOrder(i); break;
                    case "4": manager.SHOWORDERS(a); break;
                    case "5": manager.Change(a); break;

                    case "6": judge_ = false; break;
                    default: Console.WriteLine("输入错误"); break;
                }
            }
        }
    }
}
