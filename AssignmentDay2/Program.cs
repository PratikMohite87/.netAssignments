using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public interface IDbFunction 
    {
        void addData();
    }

    abstract class Employee
    {
        public String Name 
        {
            set;
            get;
        }

        public int EmpNo
        {
            private set;
            get;
        }

        public short DeptNo 
        {
            set;
            get;
        }

        public abstract decimal Basics
        {
            set;
            get;
        }

        private static int count;

        public Employee(String name="NoName", short deptno=10, decimal basics=2000)
        {
            this.EmpNo = ++count;
            this.Name = name;
            this.DeptNo = deptno;
            this.Basics = basics;
        }

        public abstract decimal CalcNetSalary();
    }

    class Manager : Employee, IDbFunction
    {
        public override decimal Basics 
        { 
            get;
            set; 
        }

        public String Designation
        {
            set;
            get;
        }

        public Manager(String name = "NoName", short deptno = 10, decimal basics = 2000, String designation = "employee"): base(name, deptno, basics) 
        {
            this.Designation = designation; 
        }

        public override decimal CalcNetSalary()
        {
            return this.Basics * 2;
        }

        public void addData()
        {
            throw new NotImplementedException();
        }
    }

    class GeneralManager : Manager, IDbFunction
    {
        public override decimal Basics
        {
            get;
            set;
        }

        public String Perks 
        {
            set;
            get;
        }

        public GeneralManager(String name = "NoName", short deptno = 10, decimal basics = 2000, String designation = "employee", string perks="novalidation") : base(name, deptno, basics, designation)
        {
            this.Perks = perks;
        }

        public override decimal CalcNetSalary()
        {
            return this.Basics * 2;
        }
    }

    class CEO : Employee, IDbFunction
    {
        public override sealed decimal Basics
        {
            get;
            set;
        }

        public CEO(String name = "NoName", short deptno = 10, decimal basics = 2000): base(name, deptno, basics) { }

        public override decimal CalcNetSalary()
        {
            return this.Basics * 3;
        }

        public void addData()
        {
            throw new NotImplementedException();
        }
    }
}
