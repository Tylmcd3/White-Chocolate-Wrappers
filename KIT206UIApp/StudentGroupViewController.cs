using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206.DatabaseApp.UI
{
    public class StudentGroupViewController : StudentGroup_Controller
    {
        private ObservableCollection<StudentGroup> viewableGroups;
        public ObservableCollection<StudentGroup> ViewableGroups { get { return viewableGroups; } }
        public StudentGroupViewController()
        {
            viewableGroups = new ObservableCollection<StudentGroup>();
        }

        public ObservableCollection<StudentGroup> GetViewableGroups()
        {
            return ViewableGroups;
        }

        public void SearchGroups(int id)
        {
            List<StudentGroup> filteredGroups = FindStudentGroups(id);
            viewableGroups.Clear();

            filteredGroups.ForEach(viewableGroups.Add);
        }

        public void SearchGroups(string name)
        {
            List<StudentGroup> filteredGroups = FindStudentGroups(name);
            viewableGroups.Clear();

            filteredGroups.ForEach(viewableGroups.Add);
        }
    }
}
