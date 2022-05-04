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

        ///<summary>
        ///Sets Meetings and Class to given groups Meetings and Class
        ///</summary>
        public void SelectGroup(int id)
        {
            group_Meetings = new Meeting_Controller(id);
            group_Class = new Class_Controller(id);
        }
        ///<summary>
        ///Finds Student Group given Group ID
        ///</summary>
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
        ///<summary>
        ///Finds Student Groups given a name
        ///</summary>
        public List<StudentGroup> FindStudentGroups(string name)
        {
            var selected = from StudentGroup g in groups
                           where name == g.GroupName
                           select g;
            return selected.ToList<StudentGroup>();

        }
        ///<summary>
        ///Finds Student Groups given an id
        ///</summary>
        public List<StudentGroup> FindStudentGroups(int id)
        {
            var selected = from StudentGroup g in groups
                           where id == g.GroupID
                           select g;
            return selected.ToList<StudentGroup>();

        }
        ///<summary>
        ///Creates new StudentGroup and adds to database
        ///</summary>
        public int AddGroup(string name)
        {
            int id = GenerateID();
            StudentGroup group = new StudentGroup(id, name);
            groups.Add(group);
            //Update database
            StorageAdapter.AddGroup(group);
            return id;

        }
        ///<summary>
        ///Changes given Student Group name to given name
        ///</summary>
        public void EditGroup(int groupID, string name)
        {
            StudentGroup group = FindStudentGroup(groupID);
            group.GroupName = name;
            //Update database
            StorageAdapter.EditGroup(group);
        }

        ////<summary>
        ///Generates StudentGroup ID iteratively
        ///</summary>
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
            return ++highest;
        }
    }
}
