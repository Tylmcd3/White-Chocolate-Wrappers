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
    /// Interaction logic for NichtGroup.xaml
    /// </summary>
    public partial class NoGroupMainView : UserControl
    {
        MainWindow window;
        StudentViewController student;
        StudentGroupViewController group;
        public NoGroupMainView(MainWindow win, StudentViewController stu, StudentGroupViewController gro)
        {
            InitializeComponent();
            window = win;
            student = stu;
            group = gro;
            window.ClassName.Text = "You need to join a group before you can see your class details.";
        }
        private void Add_Meeting(object sender, RoutedEventArgs e)
        {
            AddMeetingDialog addMeetingDialog = new AddMeetingDialog();
            addMeetingDialog.ShowDialog();
        }
        private void OpenGroupDialog(object sender, RoutedEventArgs e)
        {
            AddGroup addGroupDialog = new AddGroup(window, student, group);
            addGroupDialog.ShowDialog();
            if(addGroupDialog.groupID != -1)
            {
                student.EditStudentGroupMembership(addGroupDialog.groupID);
                NowToMain(sender,e);
            }

        }
        private void NowToMain(object sender, RoutedEventArgs e)
        {
            group.SelectGroup(student.CurrentStudent.StudentGroup);
            window.Overlay.Content = new GroupMainView(window, student, group);
        }
    }
}
