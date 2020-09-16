using System;

namespace Pow
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            Console.WriteLine(pow(x, e));
        }

        static double pow(int x, int e)
        {
            //TODO add 0^0 and x^negative support
            
            double tmp = 1;
            if (x == 0)
            {
                tmp = 0;
            }
            for (int i = 0; i < e; i++)
            {
                tmp *= x;
            }
            return tmp;
        }
    }
}
