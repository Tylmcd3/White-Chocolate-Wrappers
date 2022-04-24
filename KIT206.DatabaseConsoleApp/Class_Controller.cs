using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206.DatabaseApp
{
    class Class_Controller
    {
        private List<Class> classes;
        public List<Class> Classes { get { return classes; } set { } }
        public Class_Controller()
        {
            classes = new List<Class>();
            classes = StorageAdapter.GetClasses();
        }

        public void AddClass(int classID, int groupID, Day day, DateTime start, DateTime end, string room)
        {
            Class toAdd = new Class(classID, groupID, day, start, end, room);
            classes.Add(toAdd);
            //update database
        }
    }
}
