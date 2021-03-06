using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206.DatabaseApp
{
    public class Class_Controller
    {
        private Class groupClass;
        public Class GroupClass { get { return groupClass; } set { } }

        public Class_Controller(int id)
        {
            groupClass = StorageAdapter.LoadClassByGroup(id);
        }
        ///<summary>
        ///Creates new Class and adds to database
        ///</summary>
        public int AddClass(int groupID, Day day, TimeSpan start, TimeSpan end, string room)
        {
            int classID = GenerateID();
            Class toAdd = new Class(classID, groupID, day, start, end, room);
            groupClass = toAdd;
            //update database
            StorageAdapter.AddClass(toAdd);
            return classID;
        }
        ///<summary>
        ///Generates Class ID iteratively
        ///</summary>
        public int GenerateID()
        {
            int highest = 0;

            List<Class> allClasses = StorageAdapter.LoadClasses();

            foreach (Class item in allClasses)
            {
                if (highest <= item.ClassID)
                {
                    highest = item.ClassID;
                }
            }
            return highest++;
        }

    }
}
