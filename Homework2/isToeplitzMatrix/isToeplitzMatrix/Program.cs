using System;

namespace isToeplitzMatrix
{
    class Program

    {
        public bool isToep(int[,] array,int row,int list)
        {
            bool flag = true;
            for (int i= 1;i<row;i++)
            {
                for(int j= i;j<list;j++)
                {
                    if (array[i, j] != array[i - 1, j - 1]) flag = false;
                }
            }
            return flag;
        }
        static void Main(string[] args)
        {
            //input matrix
            Console.Write("input row number and  list");
            int row = int.Parse(Console.ReadLine());
            int list = int.Parse(Console.ReadLine());
            int[,] array = new int[row,list];
            for(int i= 0;i<row;i++)
            {
                for(int j = 0;j<list;j++)
                {
                    array[i, j] = int.Parse(Console.ReadLine());

                }
            }
            Program a = new Program();
            Console.WriteLine(a.isToep(array, row, list));


        }
    }
}
