using System;

namespace Day8
{
    class Program
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public static void show()
        {
            Console.WriteLine("From show function!");
        }

        static void Main(string[] args)
        {
            Action a = show;
            a();
            Program p = new Program();
            Func<int, int, int> f = p.Add;
            Console.WriteLine(f(10, 20));

            Console.WriteLine("=====================================");

            Action anon = delegate ()
            {
                Console.WriteLine("From Anonymous function");
            };

            Func<int, int, int> fanon = delegate (int a, int b)
            {
                return a + b;
            };

            anon();
            Console.WriteLine(fanon(10, 10));

            Console.WriteLine("=====================================");

            Func<int, int, int> farr = (x, y) => x * y;

            Console.WriteLine(farr(5, 10));
        }
    }
}
