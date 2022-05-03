using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KIT206.DatabaseApp.UI
{
    /// <summary>
    /// Interaction logic for groupView.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private StudentViewController student;
        private StudentGroupViewController group;
        public MainWindow()
        {
            InitializeComponent();
            student = new StudentViewController();
            group = new StudentGroupViewController();
            int StudentID = 123460;
            student.SelectStudent(StudentID);
            StudentName.Text = student.CurrentStudent.FirstName + " " + student.CurrentStudent.LastName;
            StudentDeets();

            group.SelectGroup(student.CurrentStudent.StudentGroup);

            selectMainView();
        }

        public void selectMainView()
        {
            if (student.CurrentStudent.StudentGroup == 0) //Change this to == for add group view to pop up
            {
                NoGroupMainView ng = new NoGroupMainView(this, student, group);
                Overlay.Content = ng;
            }
            else
            {
                GroupMainView ng = new GroupMainView(this, student, group);
                Overlay.Content = ng;
            }
        }

        public void setClass(string ClassString)
        {
            ClassName.Text = ClassString;
        }

        public void StudentDeets()
        {
            ShtudentDetails.Text = "Name: " + student.CurrentStudent.Title + " " + student.CurrentStudent.FirstName + " " +
                student.CurrentStudent.LastName + "\n" + "StudentID: " + student.CurrentStudent.StudentID + "\n" + "Group ID: "
                + student.CurrentStudent.StudentGroup + "\n" + "Campus: " + student.CurrentStudent.Campus + "\n" + "Email: " +
                student.CurrentStudent.Email + "\n" + "Catagory: " + student.CurrentStudent.Category + "\n" + "Phone No: " +
                student.CurrentStudent.Phone;
        }
        private void Add_Meeting(object sender, RoutedEventArgs e)
        {
            //Then need to grab data from dialog box and use addmeeting on controller
            AddMeetingDialog addMeetingDialog = new AddMeetingDialog();
            addMeetingDialog.ShowDialog();
        }

        private void Edit_Meeting(object sender, RoutedEventArgs e)
        {
            //Then need to grab data from dialog box and use Editmeeting on controller
            //if(MeetingsList.SelectedIndex >= 0)
            //{
            //    Meeting toEdit = MeetingsList.SelectedItem as Meeting;

            //    EditMeetingDialog editMeetingDialog = new EditMeetingDialog(toEdit);
            //    editMeetingDialog.ShowDialog();
            //}

        }

        private void Leave_Meeting(object sender, RoutedEventArgs e)
        {
            //Then need to grab data from dialog box and use addmeeting on controller
            LeaveMeetingDialog LeaveMeetingDialog = new LeaveMeetingDialog();
            LeaveMeetingDialog.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void GoToEditGroup(object sender, RoutedEventArgs e)
        {

        }
        private void List_Unselected_Event(object sender, RoutedEventArgs e)
        {
            //EditMeetingBtn.IsEnabled = false;
            //CancelMeetingBtn.IsEnabled = false;
        }

        private void List_GotFocus_Event(object sender, RoutedEventArgs e)
        {
            //EditMeetingBtn.IsEnabled = true;
            //CancelMeetingBtn.IsEnabled = true;  
        }

        private void Overlay_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
