using System;

namespace CalculateArray
{
    class Program

    {
        public void getMax (double[] array,int length)
        {
            double max = array[0];
            for(int i = 1; i<length;i++)
            {
                if (max < array[i]) max = array[i];
            }
            Console.Write("max" + max);
        }
        public void getMin(double[] array, int length)
        {
            double min = array[0];
            for (int i = 1; i < length; i++)
            {
                if (min > array[i]) min = array[i];
            }
            Console.Write("min" + min);
        }
        public void getAve(double[] array, int length)
        {
            double sum = 0;

            for (int i = 0; i < length; i++)
            {
                sum += array[i];   
            }
            sum = sum / length;
            Console.Write("ave" + sum);
        }


        static void Main(string[] args)
        { 
            Console.Write("input the length");
            int length = int.Parse(Console.ReadLine());
            double[] array = new double[length];
            Console.Write("write array number");
            for(int i = 0;i<length;i++)
            {
                array[i] = double.Parse(Console.ReadLine());
            }
            Program a = new Program();
            a.getAve(array, length);
            Console.Write("\n");
            a.getMax(array, length);
            Console.Write("\n");
            a.getMin(array, length);
            Console.ReadKey();

            
        }
        
    }
}
