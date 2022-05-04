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
    /// Interaction logic for AddGroupDialog.xaml
    /// </summary>
    public partial class AddGroupDialog : Window
    {
        private StudentGroupViewController group;
        public int groupID = -1;
        public AddGroupDialog(StudentGroupViewController gro)
        {
            InitializeComponent();
            group = gro;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.GroupNameTextBox.Text == "")
            {
                MessageBox.Show("You did not enter a group name, Please try again.","Error", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                List<StudentGroup> groups = group.FindStudentGroups(this.GroupNameTextBox.Text);
                if(groups.Count == 0)
                {
                    //Class Exists no group page
                    if (MessageBox.Show("This group doesnt exist, would you like to create this group?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        
                        groupID = group.AddGroup(this.GroupNameTextBox.Text);
                        this.Close();
                    }
                }
                else if(groups.Count == 1)
                {
                    //Class Exists 1 group page
                    if (MessageBox.Show("A group exists with that name, would you like to join it?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        groupID = group.AddGroup(this.GroupNameTextBox.Text);
                        this.Close();
                    }
                }
                else
                {
                    _ = MessageBox.Show("Multiple group exists with that name");

 

                }
            }
            
        }
    }
} //meow
