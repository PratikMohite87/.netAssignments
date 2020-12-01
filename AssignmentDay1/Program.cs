using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee o1 = new Employee("Amol", 123465, 10);
            Employee o2 = new Employee("Amol", 123465);
            Employee o3 = new Employee("Amol");
            Employee o4 = new Employee();

            Console.WriteLine(o1.EMPNO);
            Console.WriteLine(o2.EMPNO);
            Console.WriteLine(o3.EMPNO);

            Console.WriteLine(o3.EMPNO);
            Console.WriteLine(o2.EMPNO);
            Console.WriteLine(o1.EMPNO);

            Console.WriteLine(o3);
            Console.ReadLine();
        }
    }

    class Employee
    {
        private int EmpNo;
        private String Name;
        private float basic;
        private short DeptNo;
        private static int Count; 

        public Employee(String Name, float basic, short DeptNo)
        {
            this.EmpNo = ++Count;

            if (Name == "")
                Console.WriteLine("Name cannot be blank");
            else
                this.Name = Name;

            if (basic < 2000)
                Console.WriteLine("Basic Should be greater than 2000");
            else if (basic > 10000)
                Console.WriteLine("Basic Should be less than 10000");
            else
                this.basic = basic;

            if (DeptNo <= 0)
                Console.WriteLine("DeptNo must be greater than 0");
            else
                this.DeptNo = DeptNo;
        }

        public Employee(String Name, float basic)
        {
            this.EmpNo = ++Count;

            if (Name == "")
                Console.WriteLine("Name cannot be blank");
            else
                this.Name = Name;

            if (basic < 2000)
                Console.WriteLine("Basic Should be greater than 2000");
            else if (basic > 10000)
                Console.WriteLine("Basic Should be less than 10000");
            else
                this.basic = basic;
        }

        public Employee(String Name)
        {
            this.EmpNo = ++Count;

            if (Name == "")
                Console.WriteLine("Name cannot be blank");
            else
                this.Name = Name;
        }

        public Employee() 
        {
            ++Count;
        }

        public int EMPNO
        {
            get
            {
                return this.EmpNo;
            }
        }

        public String NAME
        {
            set
            {
                if (value == "")
                    Console.WriteLine("Name cannot be blank");
                else
                    this.Name = value;
            }
            get
            {
                return this.Name;
            }
        }

        public float BASIC
        {
            set
            {
                if (value < 2000)
                    Console.WriteLine("Basic Should be greater than 2000");
                else if (value > 10000)
                    Console.WriteLine("Basic Should be less than 10000");
                else
                    this.basic = value;
            }

            get
            {
                return this.basic;
            }
        }

        public short DEPTNO
        {
            set
            {
                if (value < 2000)
                    Console.WriteLine("Basic Should be greater than 2000");
                else if (value > 10000)
                    Console.WriteLine("Basic Should be less than 10000");
                else
                    this.DeptNo = value;
            }

            get
            {
                return this.DeptNo;
            }

        }

        public float GetNetSalary()
        {
            return basic * 2;
        }

        public override string ToString()
        {
            return "Employee : " + " EmpNo :"+ EmpNo + " Name : "+ Name + " Basic : " + basic + " DeptNo : " + DeptNo;
        }
    }
}
