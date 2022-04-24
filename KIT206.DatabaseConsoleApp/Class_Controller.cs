using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206.DatabaseApp
{
    class Class_Controller
    {
        private Class groupClass;
        public Class GroupClass { get { return groupClass; } set { } }

        public Class_Controller(int id)
        {
            groupClass = StorageAdapter.GetClassByGroup(id);
        }

        public void AddClass(int classID, int groupID, Day day, TimeSpan start, TimeSpan end, string room)
        {
            Class toAdd = new Class(classID, groupID, day, start, end, room);
            groupClass = toAdd;
            //update database
            StorageAdapter.AddClass(toAdd);
        }
    }
}
