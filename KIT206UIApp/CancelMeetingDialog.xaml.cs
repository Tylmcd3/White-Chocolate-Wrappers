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
    /// Interaction logic for CancelMeetingDialog.xaml
    /// </summary>
    public partial class CancelMeetingDialog : Window
    {
        public CancelMeetingDialog(Meeting meeting)
        {
            InitializeComponent();
            dialogConfirmation.Content = $"Are you sure you want to cancel the meeting on {meeting.Day.ToString()}?";
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
