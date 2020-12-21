using System;
using System.Collections.Generic;
using System.Text;

namespace Day11
{
    class Student
    {
        int count;
        String name;
        public Student()
        {
            count = 0;
            name = "Anony";
        }
        public Student(int count, String name)
        {
            this.count = count;
            this.name = name;
        }

        public static Student operator+(Student s1, Student s2)
        {
            Student obj = new Student();
            obj.count = s1.count + s2.count;
            obj.name = s1.name +  s2.name;
            return obj;
        }

        public override string ToString()
        {
            return count + " " + name;
        }
    }
    class OperatorOverloading
    {
        public static void main()
        {
            int a = 10;
            int b = 20;
            int c = a + b;

            Student s1 = new Student(10, "Aishwarya");
            Student s2 = new Student(20, "Pratik");
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine("================");
            Student s3 = s1 + s2;
            Console.WriteLine(s3);
        }
    }
}
