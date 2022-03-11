using System;
using System.Threading;

namespace AboutEvent
{
    // pulisher
    public class Clock
    {
        //利用计时器模拟闹钟 每10秒会进行一此 计时响应
        //模拟闹钟定在 n 秒 由构造函数中的参数确定闹钟响应时间

        private  int time;// 时钟从零开始 这是时钟现在的时间
        private int clocktime;//这是时钟设置的闹铃时间

        // 创建闹钟响委托
        public delegate void ClockDingHandler();
        //创建闹钟计时委托
        public delegate void ClockCountHandler();


        //创建事件
        public event ClockDingHandler Alarm;//闹钟事件
        public event ClockCountHandler Tick;//走时事件

        //设置事件响应函数 
        public virtual void OnClockDing()
        {
            if(Alarm != null)
            {
                Alarm();
            }
            
        }
        public virtual void OnClockCount()
        {
            if (Tick != null)
            {
                Tick();
            }
          
        }

        //时钟机制 线程的实现函数
        public  void IncreaseTime()
        {
            while(time>=0)
            {
                time++;
                Console.WriteLine(time);
                Thread.Sleep(1000);
                if ((time % 10) == 0)
                {
                    OnClockCount(); 
                }
                if(time == clocktime)
                {
                    OnClockDing();
                }
            }
        }


        //构造函数 并且启用时间线程
        public Clock(int n)
        {
            time = 0;
            clocktime = n;
            ThreadStart childref = new ThreadStart(IncreaseTime);
            Thread timeCountThread = new Thread(childref);
            timeCountThread.Start();
        }

    }
//订阅类
    public class subscribEvent
    {
        //订阅者对时钟的反应
        public void ClockdingRespond ()
        {
            Console.WriteLine("Alarm!!!!!!!");
           
        }
        public void ClockcountRespond()
        {
            Console.WriteLine("Tick Tick");
           
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //将闹钟设置在12秒
            Clock c = new Clock(12);
            subscribEvent v = new subscribEvent();

            c.Tick += new Clock.ClockCountHandler(v.ClockcountRespond);
            c.Alarm += new Clock.ClockDingHandler(v.ClockdingRespond);
  

        }
    }
}
