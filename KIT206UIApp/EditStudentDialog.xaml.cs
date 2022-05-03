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
    /// Interaction logic for EditStudentDialog.xaml
    /// </summary>
    public partial class EditStudentDialog : Window
    {
        public EditStudentDialog(Student student)
        {
            InitializeComponent();
            titleBox.Text = student.Title.ToString();
            firstNameBox.Text = student.FirstName.ToString();
            lastNameBox.Text = student.LastName.ToString();
            //studentIdBox.Text = student.StudentID;
            emailBox.Text = student.Email.ToString();
            phoneBox.Text = student.Phone.ToString();
            campusSelector.SelectedIndex = (int)student.Campus + 1;
            categorySelector.SelectedIndex = (int)student.Category + 1;
        }

        private void okClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
