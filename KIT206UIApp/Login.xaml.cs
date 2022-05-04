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
    /// Interaction logic for Login.xaml
    /// </summary>
    /// 


    public partial class Login : Window
    {
        private StudentViewController student;
        public Login()
        {
            InitializeComponent();
            student = new StudentViewController();
        }

        private void GoToMainPage(object sender, RoutedEventArgs e)
        {
            int id;
            if(int.TryParse(loginIdBox.Text, out id))
            {
                Student student1 = (student.FindStudent(id));
                if (student1 != null)
                {
                    MainWindow mainWindow = new MainWindow(id);
                    mainWindow.Show();
                    this.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Incorrect ID, Enter valid StudentID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid 6 digit number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        
        }
      
    }

}
