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
            int StudentID = 123474;
            student.SelectStudent(StudentID);
            StudentName.Text = student.CurrentStudent.FirstName + " " + student.CurrentStudent.LastName;
            BindStudentDetails();

            group.SelectGroup(student.CurrentStudent.StudentGroup);

            BindStudentImage();

            selectMainView();
        }

        public void BindStudentImage()
        {
            var image = new Image();
            string path = student.CurrentStudent.Photo.Remove(0, 1);
            path = path.Remove(path.Length - 1, 1);
            if(path.Length < 100)
            {
                var fullFilePath = path;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();

                StudentImage.Source = bitmap;
            }

        }
        public void selectMainView()
        {
            if (student.CurrentStudent.StudentGroup <= 0) //Change this to == for add group view to pop up
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

        public void BindStudentDetails()
        {
            string Name, Id, GroupName, Campus, Email, Category, Phone;


            StudentDetails.Text = "Name: " + Name + "\n" + "StudentID: " + student.CurrentStudent.StudentID + "\n" + "Group Name: "
                + student.CurrentStudent.StudentGroup + "\n" + "Campus: " + student.CurrentStudent.Campus + "\n" + "Email: " +
                student.CurrentStudent.Email + "\n" + "Category: " + student.CurrentStudent.Category + "\n" + "Phone No: " +
                student.CurrentStudent.Phone;
        }

        private void ToEditStudent(object sender, RoutedEventArgs e)
        {
            EditStudentDialog editStudentDialog = new EditStudentDialog();
            editStudentDialog.ShowDialog();
        }
        private void Add_Class(object sender, RoutedEventArgs e)
        {
            AddClassDialog addClassDialog = new AddClassDialog();
            bool? result = addClassDialog.ShowDialog();

            //Only process if they pressed OK
            //will also need to do some form of form validation on the dialog TODO
            if (result == true)
            {
                int id;

                Day day;
                TimeSpan start, end;
                string room;

                ComboBoxItem selectedDay = (ComboBoxItem)addClassDialog.daySelector.SelectedItem;
                day = Enum.Parse<Day>(selectedDay.Content.ToString());

                room = addClassDialog.roomTextBox.Text;
                start = TimeSpan.Parse(addClassDialog.startTextBox.Text);
                end = TimeSpan.Parse(addClassDialog.endTextBox.Text);

                id = group.Group_Class.AddClass(student.CurrentStudent.StudentGroup, day, start, end, room);
                student.EditStudentGroupMembership(id);
            }
        }
        private void GoToEditGroup(object sender, RoutedEventArgs e)
        {
            //Main.Content = new AddGroup();
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
