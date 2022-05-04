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
        
        public MainWindow(int id)
        {
            //Console.WriteLine(StudentID);
            InitializeComponent();
            student = new StudentViewController();
            group = new StudentGroupViewController();
            int StudentID=id;
            student.SelectStudent(StudentID);
            
            StudentName.Text = student.CurrentStudent.FirstName + " " + student.CurrentStudent.LastName;
            BindStudentDetails();

            group.SelectGroup(student.CurrentStudent.StudentGroup);


            BindStudentImage();

            selectMainView();
        }
        //Bind Student Image needs to check if theres an image before trying to user the students Photo
        //Maybe change the Students name from centre to the right when theres an image but leave it when there isint.
        public void BindStudentImage()
        {
           // var image = new Image();
           // string path = student.CurrentStudent.Photo.Remove(0, 1);
           // path = path.Remove(path.Length - 1, 1);
           // if(path.Length < 100)
           // {
           //    var fullFilePath = path;

           //    BitmapImage bitmap = new BitmapImage();
           //    bitmap.BeginInit();
           //    bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
           //    bitmap.EndInit();

           //    StudentImage.Source = bitmap;
           //}

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
            //Super ugly but it works
            string name, id, campus, email, category, phone;
            string groupName = "";
            List<string> studentDetails = new List<string>();
            List<string> labels = new List<string>();

            name = $"{student.CurrentStudent.FirstName} {student.CurrentStudent.LastName}";
            id = student.CurrentStudent.StudentID.ToString();
            campus = student.CurrentStudent.Campus.ToString();
            category = student.CurrentStudent.Category.ToString();
            email = student.CurrentStudent.Email;
            phone = student.CurrentStudent.Phone;

            if (student.CurrentStudent.StudentGroup > -1)
            {
                groupName = group.FindStudentGroup(student.CurrentStudent.StudentGroup).GroupName;
            }

            if (student.CurrentStudent.Title != null)
                name = student.CurrentStudent.Title + name;

            studentDetails.Add(name); studentDetails.Add(id); studentDetails.Add(groupName); studentDetails.Add(campus);
            studentDetails.Add(category);  studentDetails.Add(email); studentDetails.Add(phone);

            labels.Add("Name:"); labels.Add("ID: "); labels.Add("Group: "); labels.Add("Campus: ");
            labels.Add("Category: "); labels.Add("Email: "); labels.Add("Phone: ");

            studentDetailsListBox.ItemsSource = studentDetails;
            studentDetailsLabels.ItemsSource = labels;
        }
        
        private void ToEditStudent(object sender, RoutedEventArgs e)
        {
            Student toEdit = student.CurrentStudent;
            
            EditStudentDialog editStudentDialog = new EditStudentDialog(toEdit);

            bool? result = editStudentDialog.ShowDialog();

            if(result == true)
            {
                string title, email, phone;
                Campus campus = Campus.None;
                Category category = Category.None;

                if(editStudentDialog.campusSelector.SelectedIndex > 1)
                {
                    ComboBoxItem selectedCampus = (ComboBoxItem)editStudentDialog.campusSelector.SelectedItem;
                    campus = Enum.Parse<Campus>(selectedCampus.Content.ToString());
                }
                if(editStudentDialog.categorySelector.SelectedIndex > 1)
                {
                    ComboBoxItem selectedCategory = (ComboBoxItem)editStudentDialog.categorySelector.SelectedItem;
                    category = Enum.Parse<Category>(selectedCategory.Content.ToString());
                }

                title = editStudentDialog.titleBox.Text;
                email = editStudentDialog.emailBox.Text;
                phone = editStudentDialog.phoneBox.Text;

                student.AddStudentDetails(title, campus, email, category, phone);


            }

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

         private void checkID()
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
