using System;
using System.IO;
using System.Text;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Getting Student Object using Student
            //Student s = Student.StudentObj;
            //readUsingBinaryReader();
            Indexers.main();
        }

        static void createDir()
        {
            //Using static Class Create Directory
            //Directory.CreateDirectory("C:\\Users\\prati\\OneDrive\\Desktop\\PratikAish\\New");
            Console.WriteLine("========Using Static Class Create Directory========");
            Directory.CreateDirectory(@"C:\Users\prati\OneDrive\Desktop\PratikAish\New");

            //Using Directory Info Object
            Console.WriteLine("========Using Directory Info Object========");
            DirectoryInfo dinf = new DirectoryInfo(@"C:\Users\prati\OneDrive\Desktop\PratikAish\Ice");
            dinf.Create();

            Console.WriteLine("Directory Created!");
        }

        static void createFile()
        {
            //Using Class Create File
            File.Create(@"C:\Users\prati\OneDrive\Desktop\PratikAish\MyNewFile.docx");

            //Using File Info Object
            FileInfo finf = new FileInfo(@"C:\Users\prati\OneDrive\Desktop\PratikAish\lola.txt");
            finf.Create();

            Console.WriteLine("File Created!");
        }


        static void driveInfo()
        {
            DriveInfo dinf = new DriveInfo("F");
            Console.WriteLine("NAME : " + dinf.Name);
            Console.WriteLine("LABEL : " + dinf.VolumeLabel);
            Console.WriteLine("AVAILABLE FREE SPACE : " + dinf.AvailableFreeSpace); //In bytes
            Console.WriteLine("TOTAL FREE SPACE : " + dinf.TotalFreeSpace);//In bytes
            Console.WriteLine("DRIVE FORMAT : " + dinf.DriveFormat);
            Console.WriteLine("DRIVE TYPE : " + dinf.DriveType);
            Console.WriteLine("DRIVE IS READY : " + dinf.IsReady);
            Console.WriteLine("DRIVE TOTAL SIZE : " + dinf.TotalSize);//In bytes
            Console.WriteLine("ROOT DIRECTORY : " + dinf.RootDirectory);


            Console.WriteLine("==================================");
        }

        static void writeToFile()
        {
            String s = "Aishwarya Pratik Ghare\n";
            //Encoding enc = Encoding.Default;
            //byte []arr = enc.GetBytes(s);
            //OR
            byte[] arr = Encoding.Default.GetBytes(s);

            //Using File Stream
            //FileStream stream = File.Open(@"C:\Users\prati\OneDrive\Desktop\PratikAish\lola.txt", FileMode.Append);
            //stream.Write(arr, 0, arr.Length);

            //stream.Close();


            //Using Stream Writer
            StreamWriter swrt = File.CreateText(@"C:\Users\prati\OneDrive\Desktop\PratikAish\lola.txt");
            swrt.WriteLine(s);
            swrt.WriteLine("Hello there!");
            swrt.WriteLine("Hello there again!");
            swrt.Close();
        }
        static void usingBinaryWriter()
        {
            //Used to Write to a File using Binary Writer
            string s = "Hello";
            int i = 100;
            bool b = true;

            FileInfo f = new FileInfo(@"C:\Users\prati\OneDrive\Desktop\PratikAish\Ice.txt");

            BinaryWriter binary_writer = new BinaryWriter(f.OpenWrite());
            binary_writer.Write(s);
            binary_writer.Write(i);
            binary_writer.Write(b);
            binary_writer.Write("Hello from other side");
            binary_writer.Close();
        }


        static void readFromFile()
        {
            String s;
            StreamReader reader = File.OpenText(@"C:\Users\prati\OneDrive\Desktop\PratikAish\lola.txt");

            while ((s = reader.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
            reader.Close();
        }

        static void readUsingBinaryReader()
        {
            string s, s1;
            int i;
            bool b;
            FileInfo f = new FileInfo(@"C:\Users\prati\OneDrive\Desktop\PratikAish\Ice.txt");
            BinaryReader binary_reader = new BinaryReader(f.OpenRead());
            s = binary_reader.ReadString();
            i = binary_reader.ReadInt32();
            b = binary_reader.ReadBoolean();
            s1 = binary_reader.ReadString();

            Console.WriteLine(s);
            Console.WriteLine(i);
            Console.WriteLine(b);
            Console.WriteLine(s1);
        }

    }
}
