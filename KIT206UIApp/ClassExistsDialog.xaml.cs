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
using System.Windows.Shapes;

namespace KIT206.DatabaseApp.UI
{
    /// <summary>
    /// Interaction logic for ClassExistsDialog.xaml
    /// </summary>
    public partial class ClassExistsDialog : Window
    {
        MainWindow window;
        StudentViewController student;
        StudentGroupViewController group;
        public ClassExistsDialog(MainWindow win, StudentViewController stu, StudentGroupViewController gro)
        {
            InitializeComponent();
            window = win;
            student = stu;
            group = gro;

        }

        private void OpenGroupDialog(object sender, RoutedEventArgs e)
        {
            AddGroupDialog addGroupDialog = new AddGroupDialog(group);
            addGroupDialog.ShowDialog();
            if (addGroupDialog.groupID != -1)
            {
                student.EditStudentGroupMembership(addGroupDialog.groupID);
                NowToMain(sender, e);
            }

        }
        private void NowToMain(object sender, RoutedEventArgs e)
        {
            group.SelectGroup(student.CurrentStudent.StudentGroup);
            window.Overlay.Content = new GroupMainView(window, student, group);
        }

        private void NewGroupPlease(object sender, RoutedEventArgs e)
        {

        }
        //Change the Xaml for the main window to the no group case
        public void NoGroup()
        {

        }
        //Change the Xaml for the main window to the 1 group case
        public void OneGroup()
        {
            
        }
        //Change the Xaml for the main window to the Many group case
        public void MultipleGroup()
        {

        }
        private void JoinGroup()
        {

        }
        private void CreateGroup()
        {

        }
    }
} //public or private?
