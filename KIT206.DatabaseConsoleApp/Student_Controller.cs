using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206.DatabaseApp
{
    public class Student_Controller
    {

        protected List<Student> students = new List<Student>();
        protected Student currentStudent;

        public List<Student> Students { get { return students; } set { } }
        public Student CurrentStudent { get { return currentStudent; } set { } }

        public Student_Controller()
        {
            students = StorageAdapter.LoadStudents();
        }
        ///<summary>
        ///Prints list of Students to Console
        ///</summary>
        public void ListStudents()
        {
            foreach(Student student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
        ///<summary>
        ///Sets Current Student to given student ID
        ///</summary>
        public void SelectStudent(int id)
        {
            currentStudent = FindStudent(id);
        }
        ///<summary>
        ///Finds Student given student ID
        ///</summary>
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
        ///<summary>
        ///Returns List of Students in Current Students group
        ///</summary>
        public List<Student> FindStudentsByGroup()
        {
            var selected = from Student s in students
                           where currentStudent.StudentGroup == s.StudentGroup
                           select s;
            return selected.ToList<Student>();
        }
        ///<summary>
        ///Returns List of Students in given group
        ///</summary>
        public List<Student> FindStudentsByGroup(int id)
        {
            var selected = from Student s in students
                           where id == s.StudentGroup
                           select s;
            return selected.ToList<Student>();
        }
        ///<summary>
        ///Adds student details to Current Student and updates database
        ///</summary>
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

            StorageAdapter.EditStudentDetails(currentStudent);
        }
        ///<summary>
        ///Changes Current Students group membership to given group ID
        ///</summary>
        public void EditStudentGroupMembership(int groupID)
        {
            currentStudent.StudentGroup = groupID;
            //Update database
            StorageAdapter.EditStudentGroupMembership(currentStudent);

        }

    }
}
