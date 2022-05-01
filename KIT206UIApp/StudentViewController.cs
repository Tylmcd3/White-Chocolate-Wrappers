using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206.DatabaseApp.UI
{
    public class StudentViewController : Student_Controller
    {
        private ObservableCollection<Student> viewableStudents;
        public ObservableCollection<Student> ViewableStudents { get { return viewableStudents; } }

        public StudentViewController()
        {
            viewableStudents = new ObservableCollection<Student>();
        }

        public ObservableCollection<Student> GetViewableList()
        {
            return ViewableStudents;
        }

        public void SearchStudents(int id)
        {
            var selected = from Student s in students
                           where id == s.StudentID
                           select s;
            viewableStudents.Clear();
            selected.ToList().ForEach(viewableStudents.Add);
        }

        public void SearchStudentsByGroup(int id)
        {
            List<Student> filteredStudents = FindStudentsByGroup(id);
            viewableStudents.Clear();

            filteredStudents.ForEach(viewableStudents.Add);    
        }
    }
}
