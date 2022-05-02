﻿using System;
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
    /// Interaction logic for NichtGroup.xaml
    /// </summary>
    public partial class NoGroupMainView : UserControl
    {
        MainWindow window;
        public NoGroupMainView(MainWindow win)
        {
            InitializeComponent();
            window = win;
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Add_Meeting(object sender, RoutedEventArgs e)
        {
            AddMeetingDialog addMeetingDialog = new AddMeetingDialog();
            addMeetingDialog.ShowDialog();
        }

        private void NowToMain(object sender, RoutedEventArgs e)
        {
            AddGroupDialog addGroupDialog = new AddGroupDialog();
            addGroupDialog.ShowDialog();


            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void Edit_Meeting(object sender, RoutedEventArgs e)
        {
            //Then need to grab data from dialog box and use Editmeeting on controller
            if (MeetingsList.SelectedIndex >= 0)
            {
                Meeting toEdit = MeetingsList.SelectedItem as Meeting;

                EditMeetingDialog editMeetingDialog = new EditMeetingDialog(toEdit);
                editMeetingDialog.ShowDialog();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
    }
}
