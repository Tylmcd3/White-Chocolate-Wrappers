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
        private MeetingViewController testList;
        public GroupMainView(MainWindow win, StudentViewController stu, StudentGroupViewController gru)
        {
            InitializeComponent();
            window = win;
            student = stu;
            group = gru;
            if (group.Group_Class.GroupClass != null)
            {
                window.ClassName.Text = group.Group_Class.GroupClass.ToString();//doesnt work if not in a group
            }
            else
            {
                window.classDetailsBtn.Visibility = Visibility.Visible;
            }
            GroupMembers.ItemsSource = student.FindStudentsByGroup();
            GroupName.Text = group.FindStudentGroup(student.CurrentStudent.StudentGroup).GroupName;
            //MeetingsList.ItemsSource = group.Group_Meetings.Meetings;
            testList = new MeetingViewController(5);
            MeetingsList.ItemsSource = testList.ViewableMeetings;
            
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

                testList.AddMeeting(student.CurrentStudent.StudentGroup,
                                    day, start, end, room);
                //group.Group_Meetings.AddMeeting(student.CurrentStudent.StudentGroup,
                //                                day, start, end, room);

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
            if (MeetingsList.SelectedIndex >= 0)
            { 
                Meeting toCancel = MeetingsList.SelectedItem as Meeting;

                CancelMeetingDialog cancelMeetingDialog = new CancelMeetingDialog(toCancel);

                bool? result = cancelMeetingDialog.ShowDialog();

                if(result == true)
                {
                    group.Group_Meetings.CancelMeeting(toCancel.MeetingID);
                }
            }
        }
        
        private void Edit_Group(object sender, RoutedEventArgs e)
        {
            EditGroupDialog editGroupDialog = new EditGroupDialog(group.FindStudentGroup(student.CurrentStudent.StudentGroup).GroupName);

            bool? result = editGroupDialog.ShowDialog();    

            if(result == true)
            {
                string newName = editGroupDialog.nameTextBox.Text;
                group.EditGroup(student.CurrentStudent.StudentGroup, newName);
            }
        }
        private void Leave_Group(object sender, RoutedEventArgs e)
        {
            LeaveGroupDialog leaveGroupDialog = new LeaveGroupDialog(group.FindStudentGroup(student.CurrentStudent.StudentGroup).GroupName);

            bool? result = leaveGroupDialog.ShowDialog();

            if(result== true)
            {
                //Also need to update view
                student.EditStudentGroupMembership(-1);                
            }
        }

        private void GoToEditGroup(object sender, RoutedEventArgs e)
        {

        }
    }
}
