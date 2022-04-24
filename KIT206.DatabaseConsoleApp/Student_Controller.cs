using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206.DatabaseApp
{
    public class Student_Controller
    {

        private List<Student> students = new List<Student>();
        private Student currentStudent;

        public List<Student> Students { get { return students; } set { } }
        public Student CurrentStudent { get { return currentStudent; } set { } }

        public Student_Controller()
        {
            students = StorageAdapter.LoadStudents();
        }

        public void ListStudents()
        {
            foreach(Student student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
        public void SelectStudent(int id)
        {
            currentStudent = FindStudent(id);
        }

        public Student FindStudent(int id)
        {
            foreach (Student student in students)
            {
                if (student.StudentID == id)
                {
                    return student;
                }
            }
            return null;
        }
        public void AddStudentDetails(string title, Campus campus, string email, Category category, string phone)
        {
            if (currentStudent == null)
            {
                return;
            }
            currentStudent.Title = title;
            currentStudent.Campus = campus;
            currentStudent.Email = email;
            currentStudent.Category = category;
            currentStudent.Phone = phone;
            //Update database
            StorageAdapter.EditStudentDetails(currentStudent);
        }

        public void EditStudentGroupMembership(int groupID)
        {
            currentStudent.StudentGroup = groupID;
            //Update database
            StorageAdapter.EditStudentGroupMembership(currentStudent);

        }

    }
}
