using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206
{
    class Student_Controller
    {
        //we could add Properties for certain values like name and stuff for ease of use. just so we can ignore Student entirely
        public Student user;

        //This just gets a fresh student object for the user every time a function is called
        //This is useful when the user group is changed or the
        private void UpdateStudent()
        {
            user = StorageAdapter.GetStudent(user.StudentID);
        }
        public StudentGroup AddGroup(string name)
        {
            UpdateStudent();
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
            StorageAdapter.EditStudentDetails(user.StudentID, title, campus, category, email, phone);
            UpdateStudent();
        }
        //Need to change editing
        public void EditStudentGroup()
        {
            StorageAdapter.EditStudentGroup(user.StudentID, 0);
            UpdateStudent();

        }
        public string GetStudentString()
        {

            if (user.Email != null)
                return user.ToString("full");
            else
                return user.ToString(" ");
        }

    }
}
