using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206.DatabaseApp.UI
{
    public class MeetingViewController : Meeting_Controller
    {
        private ObservableCollection<Meeting> viewableMeetings;
        public ObservableCollection<Meeting> ViewableMeetings { get { return viewableMeetings; } }

        public MeetingViewController(int id) : base(id)
        {
            viewableMeetings = new ObservableCollection<Meeting>(meetings);
        }

        public ObservableCollection<Meeting> GetViewableMeetings()
        {
            return viewableMeetings;
        }

    }
}
