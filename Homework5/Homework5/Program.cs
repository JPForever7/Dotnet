using System;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService a = new OrderService();
            bool judge_ = true;
            while (judge_)
            {
                Console.WriteLine("输入1增加订单，输入2删除订单，输入3查询订单，输入4显示所有订单，输入5修改订单，输入6退出");
                string choose1 = Console.ReadLine();
                switch (choose1)
                {
                    case "1": a.addOrder(); break;
                    case "2": a.deleteOrder(); break;
                    case "3": Console.WriteLine("输入1根据订单金额查询订单，输入2根据客户名查询订单,输入3跟据订单编号查询"); int i = Convert.ToInt32(Console.ReadLine()); a.searchOrder(i); break;
                    case "4": a.showAllOrder(); break;
                    case "5": a.changeOrder(); break;

                    case "6": judge_ = false; break;
                    default: Console.WriteLine("输入错误"); break;
                }
            }
        }
    }
}
