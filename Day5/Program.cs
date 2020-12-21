using System;


namespace Day5
{
    class Employee
    {
        int empNo;
        String name;
        decimal basic;
        short deptNo;
        static int count = 0;

        public Employee(String name = "Anonymous", decimal basic = 10000, short deptNo = 10)
        {
            empNo = ++count;
            Name = name;
            Basic = basic;
            DeptNo = deptNo;
        }

        public int EmpNo
        {
            get
            {
                return empNo;
            }
        }

        public String Name
        {
            set
            {
                if (value.Length > 0)
                    name = value;
                else
                    Console.WriteLine("Invalid Name");
            }
            get
            {
                return name;
            }
        }

        public decimal Basic
        {
            set
            {
                if (value >= 10000 && value <= 100000)
                    basic = value;
                else
                    Console.WriteLine("Invalid Salary");
            }
            get
            {
                return basic;
            }
        }

        public short DeptNo
        {
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.WriteLine("Invalid Department Number");
            }
            get
            {
                return deptNo;
            }
        }

        public static Employee getMaxSalEmp(Employee[] e)
        {
            Employee temp = e[0];
            decimal max = e[0].Basic;
            for (int i = 0; i < e.Length; i++)
            {
                if (max < e[i].Basic)
                {
                    max = e[i].Basic;
                    temp = e[i];
                }
            }
            Console.WriteLine(max);
            Console.WriteLine(temp.Name);
            return temp;
        }

        public override string ToString()
        {
            return EmpNo + " " + Name + " " + Basic + " " + DeptNo;
        }



    }


    public struct Student
    {
        String name;
        int roll;
        decimal marks;

        public Student(int roll, String name, decimal marks)
        {
            this.name = name;
            this.roll = roll;
            this.marks = marks;
        }

        public String Name
        {
            set
            {
                if (value.Length > 0)
                {
                    name = value;
                }
                else
                    Console.WriteLine("Invalid name");
            }
            get
            {
                return name;
            }
        }

        public int Roll
        {
            set
            {
                if (value > 0)
                    roll = value;
            }
            get
            {
                return roll;
            }
        }

        public decimal Marks
        {
            set
            {
                if (value >= 0)
                    marks = value;
            }
            get
            {
                return marks;
            }
        }

        public override string ToString()
        {
            return Roll + " " + Name + " " + Marks;
        }


    }

    class Program
    {

        public static Employee getEmpDetails(int id, Employee[] e)
        {
            Employee temp = null;
            for (int i = 0; i < e.Length; i++)
            {
                if (e[i].EmpNo == id)
                {
                    temp = e[i];
                }
            }
            return temp;
        }

        static void Main(string[] args)
        {
            Employee[] e = new Employee[5];
            e[0] = new Employee("Pratik", 80000, 10);
            e[1] = new Employee("Ritesh", 70000, 10);
            e[2] = new Employee("Demo", 60000, 20);
            e[3] = new Employee("Demo1", 50000, 20);
            e[4] = new Employee("Demo2", 40000, 30);

            Console.WriteLine(Employee.getMaxSalEmp(e));
            Console.WriteLine("============");
            Console.WriteLine(getEmpDetails(4, e));


            Console.WriteLine("===============================================");

            Console.WriteLine("Enter the number of Batches : ");
            int batch = int.Parse(Console.ReadLine());

            Console.WriteLine("===============================================");
            Console.WriteLine("Marks");
            /*
            int[][][] x = new int[batch][][];
            for(int i=0; i<batch; i++)
            {
                Console.WriteLine("Enter the number of Students in Batch " + (i + 1) + " : ");
                int st = int.Parse(Console.ReadLine());
                x[i] = new int[st][];
                for (int j = 0; j < st; j++)
                {
                    Console.WriteLine("Enter number of Subjects for Student"+(j+1)+" : ");
                    int sub = int.Parse(Console.ReadLine());
                    x[i][j] = new int[sub];
                    for (int k=0; k<sub; k++)
                    {
                        Console.WriteLine("Enter marks for Sub"+(k+1)+" : ");
                        x[i][j][k] = int.Parse(Console.ReadLine());
                    }
                }
            }*/

            Console.WriteLine("===============================================");

            Student[] s = new Student[5];

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter Student" + (i + 1) + " name: ");
                String name = Console.ReadLine();
                Console.WriteLine("Enter Marks for " + name + " : ");
                decimal marks = decimal.Parse(Console.ReadLine());
                s[i] = new Student(i + 1, name, marks);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(s[i]);
            }
        }
    }
}