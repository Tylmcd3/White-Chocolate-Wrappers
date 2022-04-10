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
            StudentGroup group = null;
            List<Student> students = new List<Student>();
            List<StudentGroup> groups = new List<StudentGroup>();
            students.Add(new Student("John", 69));
            groups.Add(students[0].AddGroup("White_Choc_Wrappers"));

            foreach (Student student in students)
            {
                if(student.StudentID == 69)
                {
                    group = StudentGroup.GetGroup(student, groups);


                }
            }
            foreach (Student student in students)
            {
                Console.WriteLine(student.ToString());
                Console.WriteLine(group.ToString());
            }
        }
    }
}
