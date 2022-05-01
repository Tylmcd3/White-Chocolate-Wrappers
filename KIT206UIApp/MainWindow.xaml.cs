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
            this.DataContext = group.FindStudentGroup(student.CurrentStudent.StudentGroup);
            group.SelectGroup(student.CurrentStudent.StudentGroup);
            ClassName.Text = group.Group_Class.GroupClass.ToString();
            GroupMembers.ItemsSource = student.FindStudentsByGroup();
            MeetingsList.ItemsSource = group.Group_Meetings.Meetings;
        }

        private void Add_Meeting(object sender, RoutedEventArgs e)
        {
            AddMeetingDialog addMeetingDialog = new AddMeetingDialog();
            addMeetingDialog.ShowDialog();
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

        }
    }
}
