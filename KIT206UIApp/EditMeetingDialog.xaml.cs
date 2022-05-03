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
    /// Interaction logic for EditMeetingDialog.xaml
    /// </summary>
    public partial class EditMeetingDialog : Window
    {
        public EditMeetingDialog(Meeting meeting)
        {
            InitializeComponent();
            startTextBox.Text = meeting.Start.ToString();
            endTextBox.Text = meeting.End.ToString();
            //Starts indexing at 1 (??) so add 1
            daySelector.SelectedIndex = (int)meeting.Day + 1; 
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
