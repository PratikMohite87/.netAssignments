using System;

namespace Day7Exception
{
    class DemoClass
    {
        int var;

        public int Var
        {
            set
            {
                var = value;
            }
            get
            {
                return var;
            }
        }
    }

    class Program
    {
        static void ExceptionFunction()
        {
            DemoClass c = new DemoClass();

            try
            {
                //c = null;
                int x = Convert.ToInt32(Console.ReadLine());
                c.Var = 100 / x;
                Console.WriteLine(c.Var);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Format Exception Occured");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DivideByZeroException Exception Occured");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Null Reference Exception Occured");
            }
            catch (Exception)
            {
                Console.WriteLine("Other Exception");
            }
        }

        static void Main(string[] args)
        {
            ExceptionFunction();
        }
    }
}

namespace Day7Event
{
    class Program
    {
        static void main(String[] args)
        {
            Console.WriteLine("Hello World");
        }
    }
}
