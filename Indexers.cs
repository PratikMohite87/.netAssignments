using System;
using System.Collections.Generic;
using System.Text;

namespace Day11
{
    class MyClass
    {
        public int[] arr;
        int startPos;

        public MyClass(int size, int startPos=0)
        {
            arr = new int[size];
            this.startPos = startPos;
        } 

        public int this[int index]
        {
            set
            {
                arr[index - startPos] = value;
            }
            get
            {
                return arr[index - startPos];
            }
        }
    }

    class Indexers
    {
        public static void main()
        {
            MyClass obj = new MyClass(5, 100);
            obj[100] = 10;
            obj[101] = 20;
            obj[103] = 40;

           
        }
    }
}
