using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Drawing;

namespace KIT206.DatabaseApp.UI
{
    /// <summary>
    /// Interaction logic for EditStudentDialog.xaml
    /// </summary>
    public partial class EditStudentDialog : Window
    {
        public string studentImage = "";
        public EditStudentDialog(Student student)
        {
            InitializeComponent();

            if(student.Title != null)
            {
                titleBox.Text = student.Title;
                titleBox.IsEnabled = false;
            }
            if(student.Email != null)
            {
                emailBox.Text = student.Email;
                emailBox.IsEnabled = false;
            }
            if(student.Phone != null)
            {
                phoneBox.Text = student.Phone;
                phoneBox.IsEnabled = false;
            }
            if(student.Campus != Campus.None)
            {
                campusSelector.SelectedIndex = (int)student.Campus + 1;
                campusSelector.IsEnabled = false;  
            }
            if (student.Category != Category.None)
            {
                categorySelector.SelectedIndex = (int)student.Category + 1;
                categorySelector.IsEnabled = false;
            }
        }

        private void okClick(object sender, RoutedEventArgs e)
        {
            if(titleBox.Text == "" || emailBox.Text == "" || phoneBox.Text == "" || campusSelector.SelectedIndex == 0 || categorySelector.SelectedIndex == 0)
            {
                MessageBox.Show("Please enter all your details");
            }
            else
            {
                DialogResult = true;
            }
        }

        private void cancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ImageClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {

                studentImage = openFileDialog.FileName;
                

            }
                
        }
    }
}
