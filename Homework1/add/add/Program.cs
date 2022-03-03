using System;

namespace add
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the action be performed");
            Console.WriteLine("Press 1 for Addition");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the first number");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number");
            int number2 = Convert.ToInt32(Console.ReadLine());
            int result = 0;
            switch(action)
            {
                case 1:
                    {
                        result = number1 + number2;
                        break;
                    }
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
