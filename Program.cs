using System;
using System.Linq;

namespace Array_3
{
    class Program
    {
        int notContains(int[] array)
        {
            int min=array[0];
            for(int i=0;i<array.Length;i++)
            {
                if (array[i] > 0 && array[i]<min)
                {
                    min = array[i];
                    Console.WriteLine(min);
                }
            }
            
            return min-1;
        }
        static void Main(string[] args)
        {
            int arrSize,values;
            string src;
            do
            {
                Console.WriteLine("Gtxovt Seitanot masivis elementebis raotenoba");
                arrSize = Convert.ToInt32(Console.ReadLine());
                int[] array = new int[arrSize];
               
                for (int i = 0; i < arrSize; i++)
                {
                    Console.Write("Gtxovt Seitanot masivi  ");
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
                Program program = new Program();
               values= program.notContains(array);
                Console.WriteLine("minimaluri mdeli ricxvi aris  " +values);
                Console.WriteLine("Gavagrtelot Seitane 1 ara 0");
                src = Console.ReadLine();
            } while (src == "1");
        }
    }
}
