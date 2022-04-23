using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206
{
    class StudentGroup_Controller
    {
        private List<StudentGroup> groups = new List<StudentGroup>();
        public List<StudentGroup> Groups { get { return groups; } set { } }
        public StudentGroup_Controller()
        {
            groups = StorageAdapter.LoadGroups();
        }
        public StudentGroup FindStudentGroup(int id)
        {
            foreach (StudentGroup group in groups)
            {
                if (group.GroupID == id)
                {
                    return group;
                }
            }
            return null;
        }
        public void AddGroup(int id, string name)
        {
            StudentGroup group = new StudentGroup(id, name);
            groups.Add(group);
            //Update database
            StorageAdapter.AddGroup(group);

        }

        public void EditGroup(int groupID, string name)
        {
            StudentGroup group = FindStudentGroup(groupID);
            group.GroupName = name;
            //Update database
            StorageAdapter.EditGroup(group);
        }
    }
}
