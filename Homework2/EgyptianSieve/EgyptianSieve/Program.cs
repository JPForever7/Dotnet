using System;

namespace EgyptianSieve
{
    class Program
    {
        public bool isPrime(int number)
        {
            bool flag = true;
            for (int i=2; i*i<=number;i++)
            {
                
                if(number % i == 0)
                {
                    flag = false;
                    return flag;
                }              
            }
            return flag;
               
        }
        static void Main(string[] args)

        {
            Program a = new Program();
            Console.WriteLine(2);
            for(int i =3;i<100;i++)
            {
                if (a.isPrime(i)) Console.WriteLine(i);
            }
            
          
        }

    }
}
