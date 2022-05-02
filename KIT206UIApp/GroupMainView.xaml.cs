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
    /// Interaction logic for GroupMainView.xaml
    /// </summary>
    public partial class GroupMainView : UserControl
    {
        MainWindow window;
        private StudentViewController student;
        private StudentGroupViewController group;
        public GroupMainView(MainWindow win, StudentViewController stu, StudentGroupViewController gru)
        {
            InitializeComponent();
            window = win;
            student = stu;
            group = gru;
            window.ClassName.Text = group.Group_Class.GroupClass.ToString(); //doesnt work if not in a group
            GroupMembers.ItemsSource = student.FindStudentsByGroup();
            MeetingsList.ItemsSource = group.Group_Meetings.Meetings;
            
        }
        private void Add_Meeting(object sender, RoutedEventArgs e)
        {
            AddMeetingDialog addMeetingDialog = new AddMeetingDialog();
            bool? result = addMeetingDialog.ShowDialog();
            
            //Only process if they pressed OK
            //will also need to do some form of form validation on the dialog TODO
            if(result == true)
            {
                Day day;
                TimeSpan start, end;
                string room;

                ComboBoxItem selectedDay = (ComboBoxItem)addMeetingDialog.daySelector.SelectedItem;
                day = Enum.Parse<Day>(selectedDay.Content.ToString());

                room = addMeetingDialog.roomTextBox.Text;
                start = TimeSpan.Parse(addMeetingDialog.startTextBox.Text);
                end = TimeSpan.Parse(addMeetingDialog.endTextBox.Text);

                group.Group_Meetings.AddMeeting(student.CurrentStudent.StudentGroup,
                                                day, start, end, room);

            }
        }

        private void Edit_Meeting(object sender, RoutedEventArgs e)
        {
            //If an item is actually selected
            if (MeetingsList.SelectedIndex >= 0)
            {
                Meeting toEdit = MeetingsList.SelectedItem as Meeting;

                EditMeetingDialog editMeetingDialog = new EditMeetingDialog(toEdit);

                bool? result = editMeetingDialog.ShowDialog();

                //Only process if they pressed OK
                if( result == true)
                {
                    Day day;
                    TimeSpan start, end;

                    ComboBoxItem selectedDay = (ComboBoxItem)editMeetingDialog.daySelector.SelectedItem;
                    day = Enum.Parse<Day>(selectedDay.Content.ToString());

                    start = TimeSpan.Parse(editMeetingDialog.startTextBox.Text);
                    end = TimeSpan.Parse(editMeetingDialog.endTextBox.Text);

                    group.Group_Meetings.EditMeeting(toEdit.MeetingID, day, start, end);
                    
                }
            }

        }

        private void Cancel_Meeting(Object sender, RoutedEventArgs e)
        {

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
    }
}
