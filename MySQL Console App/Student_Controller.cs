using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206
{
    class Student_Controller
    {
        public Student user;

        private Student updateStudent()
        {
            return StorageAdapter.GetStudent(user.StudentID);
        }
        public StudentGroup AddGroup(string name)
        {
            StudentGroup group = null;
            //foreach (StudentGroup groups in StorageAdapter.Groups)
            //{
            //    if (groups.GroupName == name)
            //        group = groups;
            //}

            if (group == null)
            {
                group = new StudentGroup(name);
                user.StudentGroup = group.GroupID;
                return group;
            }
            else
            {
                user.StudentGroup = group.GroupID;
                return null;
            }
        }

        public void AddStudentDetails(string title, Campus campus, Category category, string email, string phone)
        {
            user.Title = title;
            user.Campus = campus;
            user.Category = category;
            user.Email = email;
            user.Phone = phone;
        }
        //Need to change editing
        public Student EditStudentGroup()
        {
            user.StudentGroup = 0;
            //StorageAdapter.EditStudent(this);
            return this;
        }
        public string GetStudentString()
        {
            if (Email != null)
                return ToString("full");
            else
                return ToString(" ");
        }

    }
    static void GetStudent()
        {

        }
    }
}
