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

namespace KIT206UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			
			InitializeComponent();
			
		}

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
			Meetings.Items.Add("string");
		}

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }
    }
			Application.Current.MainWindow = this;
		}
		private void ToTheGroupViewSmile(object sender, RoutedEventArgs e)
       	{
            	groupView page = new groupView();
            	this.Content = page;
        }
	}
}
