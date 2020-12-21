using System;

namespace Day4
{
    interface IDbFunction
    {
        void create();
        void delete();
        void display();
    }

    class IDbImplement : IDbFunction
    {
        public void create()
        {
            Console.WriteLine("Inside Class Create");
        }

        public void delete()
        {
            Console.WriteLine("Inside Class Delete");
        }

        public void display()
        {
            Console.WriteLine("Inside Class Display");
        }

        public void ImpleMethod()
        {
            Console.WriteLine("Inside Class");
        }
    }

    class IdbImplement2 : IDbFunction
    {
        void IDbFunction.create()
        {
            Console.WriteLine("Inside Class Create IDbFunction using ref");
        }

        void IDbFunction.delete()
        {
            Console.WriteLine("Inside Class Delete");
        }

        void IDbFunction.display()
        {
            Console.WriteLine("Inside Class Display");
        }
        
        
    }

    class Program
    {
        static void Main(string[] args)
        {

            IDbFunction id = new IdbImplement2();
            id.create();

        }
    }
}
