using System;

namespace Day3
{
    abstract class Employee
    {
        String name;
        int empNo;
        short deptNo;
        protected decimal basic;
        static int count = 0;
    
        public String Name
        {
            set
            {
                if (value.Length > 0)
                    name = value;
                else
                {
                    Console.WriteLine("Invalid Name");
                    name = "Anonymous";
                }
            }
            get
            {
                return name;
            }
        }

        public int EmpNo
        {
            get
            {
                return empNo;
            }
        }

        public short DeptNo
        {
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                {
                    Console.WriteLine("Invalid Department Number");
                    deptNo = 10;
                }
            }
            get
            {
                return deptNo;
            }
        }

        public abstract decimal Basic
        {
            set;
            get;
        }

        public Employee(String name = "Anonymous", short deptNo = 10)
        {
            this.empNo = ++count;
            this.Name = name;
            this.DeptNo = deptNo;
        }

        public abstract  decimal CalNetSalary();

        public override string ToString()
        {
            return EmpNo + " " + Name + " " + DeptNo + " ";
        }
    }

    class Manager : Employee
    {
        String designation;

        public String Designation
        {
            set
            {
                if (value.Length > 0)
                    designation = value;
                else
                {
                    Console.WriteLine("Invalid Designation");
                    designation = "Manager";
                }
            }
            get
            {
                return designation;
            }
        }
        public override decimal Basic 
        {
            set
            {
                if (value >= 10000 && value <= 100000)
                    basic = value;
                else
                {
                    Console.WriteLine("Invalid Salary");
                    basic = 10000;
                }
            }
            get
            {
                return basic;
            }
        }

        public Manager(String name="Anonymous", decimal basic=50000, short deptNo=10, String desgination = "Manager") : base(name, deptNo)
        {
            this.Basic = basic;
            this.Designation = designation;
        }

        public override decimal CalNetSalary()
        {
            return Basic * 12;
        }
    }

    class GeneralManager : Manager
    {
        String perks;

        public String Perks
        {
            set
            {
                if (value.Length > 0)
                    perks = value;
                else
                {
                    Console.WriteLine("Invalid Perks");
                    perks = "none";
                }
            }
            get
            {
                return perks;
            }
        }

        public GeneralManager(String name = "Anonymous", decimal basic = 50000, short deptNo = 10, String desgination = "GeneralManager", String perks = "none") 
            : base(name, basic, deptNo, desgination)
        {
            this.Perks = perks;
        }

        public override decimal CalNetSalary()
        {
            return base.CalNetSalary() * 10;
        }
    }


    class CEO : Employee
    {
        public override decimal Basic 
        {
            set
            {
                if (value >= 100000 && value <= 1000000)
                    basic = value;
                else
                {
                    Console.WriteLine("Invalid Salary");
                    basic = 100000;
                }
            }
            get
            {
                return basic;
            }
        }

        public CEO(String name = "Anonymous", decimal basic = 100000, short deptNo = 10) : base(name, deptNo)
        {
            this.Basic = basic;
        }

        public override sealed decimal CalNetSalary()
        {
            return 12 * Basic * 20;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Manager m = new Manager("Sanket", 100000, 10);
            GeneralManager gm = new GeneralManager("Ritesh");
            CEO c = new CEO("Pratik", 1000000, 10);

        }   
    }
}
