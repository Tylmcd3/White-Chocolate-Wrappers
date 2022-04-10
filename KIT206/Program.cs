using System;
using System.Collections.Generic;
using System.Globalization;

namespace KIT206
{
    class Program
    {
        //Driver Class
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<StudentGroup> groups = new List<StudentGroup>();
            Student student = new Student("John", 69);
            groups.Add(student.AddGroup("White_Choc_Wrappers"));
            Console.WriteLine(student.ToString());
        }
    }
}
