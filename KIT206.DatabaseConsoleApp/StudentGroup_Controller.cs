using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206.DatabaseApp
{
    public class StudentGroup_Controller
    {
        private List<StudentGroup> groups = new List<StudentGroup>();
        public List<StudentGroup> Groups { get { return groups; } set { } }

        private Class_Controller group_Class;
        public Class_Controller Group_Class { get { return group_Class; } set { } }

        private Meeting_Controller group_Meetings;
        public Meeting_Controller Group_Meetings { get { return group_Meetings; } set { } }

        public StudentGroup_Controller()
        {
            groups = StorageAdapter.LoadGroups();
        }

        public void SelectGroup(int id)
        {
            group_Meetings = new Meeting_Controller(id);
            group_Class = new Class_Controller(id);
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

        public List<StudentGroup> FindStudentGroupByName(string name)
        {
            var selected = from StudentGroup g in groups
                           where name == g.GroupName
                           select g;
            return selected.ToList<StudentGroup>();

        }

        public void AddGroup(string name)
        {
            int id = GenerateID();
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

        //Iterates on the highest group id
        public int GenerateID()
        {
            int highest = 0;
            foreach(StudentGroup group in groups)
            {
                if(highest <= group.GroupID)
                {
                    highest = group.GroupID;
                }
            }
            return highest++;
        }
    }
}
