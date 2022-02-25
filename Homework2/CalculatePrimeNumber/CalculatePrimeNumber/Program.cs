using System;

namespace CalculatePrimeNumber
{
    class Program

    {
        public void findPrime(int number)
        {
            for (int i = 2; i * i <= number; i++)
            {

                bool flag = ((number % i) == 0);
                if (!flag)
                {
                    continue;
                }

                while (flag)
                {
                    number = number /i;
                    flag = ((number % i) == 0);
                }
                Console.Write(i+" ");
            }
            if (number != 1) {
                Console.Write(number + " ");
            }

        }
        static void Main(string[] args)
        {

            //Input the number used to calculate
            Console.Write("input number");
            int intNumber = int.Parse(Console.ReadLine());
            Program tem = new Program();
            tem.findPrime(intNumber);

            Console.ReadKey();

        }

    }

}
