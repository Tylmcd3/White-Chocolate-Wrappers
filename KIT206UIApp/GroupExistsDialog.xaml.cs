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
    public partial class GroupExistsDialog : Window
    {
        MainWindow window;
        StudentViewController student;
        StudentGroupViewController group;
        public GroupExistsDialog(MainWindow win, StudentViewController stu, StudentGroupViewController gro)
        {
            InitializeComponent();
            window = win;
            student = stu;
            group = gro;
        }
        public GroupExistsDialog()
        {
            List<Student> students = new List<Student>() {
                new Student(123, "Tyler", "McDonald", 1),
                new Student(132, "Callum", "Stehdf", 1),
                new Student(142, "Jordan", "Voiceless", 1)
            };
            InitializeComponent();
            student = new();
            group = new();

            DisplayGroups("Networking 2.0");
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

        private void JoinExistingGroup(object sender, RoutedEventArgs e)
        {

        }
        private void DisplayGroups(string groupName)
        {
            List<StudentGroup> ListOfGroups = group.FindStudentGroups(groupName);

            Groups.ItemsSource = ListOfGroups;
        }
        private void DisplayStudents(ListBoxItem listBoxItem)
        {
            List<Student> students = new List<Student>() {
                new Student(123, "Tyler", "McDonald", 1),
                new Student(132, "Callum", "Stehdf", 1),
                new Student(142, "Jordan", "Voiceless", 1)
            };

            //Students.ItemsSource = students;
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
}
