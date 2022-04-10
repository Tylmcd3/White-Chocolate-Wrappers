using System;
using System.Globalization;

namespace KIT206
{
    class Program
    {
        //Driver Class
        static void Main(string[] args)
        {
            Student student = new Student("John", 69);
            Console.WriteLine(student.ToString());
        }
    }
}
