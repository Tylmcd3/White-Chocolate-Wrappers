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
            BindStudentDetails();

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

        public void BindStudentDetails()
        {
            StudentDetails.Text = "Name: " + student.CurrentStudent.Title + " " + student.CurrentStudent.FirstName + " " +
                student.CurrentStudent.LastName + "\n" + "StudentID: " + student.CurrentStudent.StudentID + "\n" + "Group ID: "
                + student.CurrentStudent.StudentGroup + "\n" + "Campus: " + student.CurrentStudent.Campus + "\n" + "Email: " +
                student.CurrentStudent.Email + "\n" + "Catagory: " + student.CurrentStudent.Category + "\n" + "Phone No: " +
                student.CurrentStudent.Phone;
        }

        

        private void ToEditStudent(object sender, RoutedEventArgs e)
        {
           Student theStudent = student.CurrentStudent;
           EditStudentDialog editStudentDialog = new EditStudentDialog(theStudent);
           editStudentDialog.ShowDialog();
  
           Campus campus;
           Category category;
           string title, email, phone;

           ComboBoxItem selectedCampus = (ComboBoxItem)editStudentDialog.campusSelector.SelectedItem;
           campus = Enum.Parse<Campus>(selectedCampus.Content.ToString());

           ComboBoxItem selectedCategory = (ComboBoxItem)editStudentDialog.categorySelector.SelectedItem;
           category = Enum.Parse<Category>(selectedCategory.Content.ToString());

            title = editStudentDialog.titleBox.Text;
            email = editStudentDialog.emailBox.Text;
            phone = editStudentDialog.phoneBox.Text;

            student.AddStudentDetails(title, campus, email, category, phone);

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
