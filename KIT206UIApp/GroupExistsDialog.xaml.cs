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
    public partial class AddGroup : Window
    {
        MainWindow window;
        StudentViewController student;
        StudentGroupViewController group;
        public int groupID = -1;
        string name;
        public AddGroup(MainWindow win, StudentViewController stu, StudentGroupViewController gro)
        {
            InitializeComponent();
            window = win;
            student = stu;
            group = gro;
        }
        public AddGroup()
        {
            List<Student> students = new List<Student>() {
                new Student(123, "Tyler", "McDonald", 1),
                new Student(132, "Callum", "Stehdf", 1),
                new Student(142, "Jordan", "Voiceless", 1)
            };
            InitializeComponent();
            student = new();
            group = new();
        }
        private void CreateNewGroup(object sender, RoutedEventArgs e)
        {

        }
        private void JoinSelectedGroup(object sender, RoutedEventArgs e)
        {
            StackPanel panel = (StackPanel)Groups.SelectedItem;
            int panelID = int.Parse(panel.Uid);

            groupID = panelID;
            this.Close();
        }
        private void NowToMain(object sender, RoutedEventArgs e)
        {
            group.SelectGroup(student.CurrentStudent.StudentGroup);
            window.Overlay.Content = new GroupMainView(window, student, group);
        }

        private void JoinExistingGroup(object sender, RoutedEventArgs e)
        {
            groupID = group.AddGroup(name);
            this.Close();
        }
        private void DisplayGroups(string groupName)
        {
            List<StudentGroup> ListOfGroups = group.FindStudentGroups(groupName);
            
            foreach(StudentGroup group in ListOfGroups)
            {
                StackPanel panel= new();
                TextBlock Heading = new();

                panel.Uid = group.GroupID.ToString();
                Heading.FontSize = 20;
                panel.Orientation = Orientation.Vertical;
                Heading.Text = "Group Members";
                Heading.TextAlignment = TextAlignment.Center;
                panel.Children.Add(Heading);
                panel.Children.Add(new Separator());

                foreach(Student stu in student.FindStudentsByGroup(group.GroupID))
                {
                    TextBlock students = new();

                    students.FontSize = 20;
                    students.TextAlignment = TextAlignment.Center;
                    students.Text += stu.FirstName + " " + stu.LastName;
                    panel.Children.Add(students);

                }
                Groups.Items.Add(panel);
            }
        }
        private void SearchGroup(object sender, RoutedEventArgs e)
        {
            name = GroupName.Text;
            if (name != null)
            {
                if (group.FindStudentGroups(name).Count > 1)
                {
                    ContentText.Text = "There are multiple groups with that name, select which group you would like to join";
                    search.Visibility = Visibility.Collapsed;
                    GroupName.Visibility = Visibility.Collapsed;
                    Groups.Visibility = Visibility.Visible;
                    Create.Visibility = Visibility.Visible;
                    Join.Visibility = Visibility.Visible;
                    DisplayGroups(name);
                }
                else if (group.FindStudentGroups(name).Count == 1)
                {
                    ContentText.Text = "There is already a group with that name, Would you like to join it?";
                    search.Visibility = Visibility.Collapsed;
                    GroupName.Visibility = Visibility.Collapsed;
                    Groups.Visibility = Visibility.Visible;
                    Create.Visibility = Visibility.Visible;
                    Join.Visibility = Visibility.Visible;
                    DisplayGroups(name);
                }
                else
                {
                    groupID = group.AddGroup(name);
                    this.Close();
                }
            }
            else
            {
                GroupName.Text = "You didnt enter a name\nPlease enter the name of the group you want to join";
            }
        }
    }

}
