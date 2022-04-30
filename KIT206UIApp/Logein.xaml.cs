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
    /// Interaction logic for Logein.xaml
    /// </summary>
    public partial class Logein : Page
    {
        public Logein()
        {
            InitializeComponent();
        }

        private void BtnClickP1(object sender, RoutedEventArgs e)
        {
            Main.content = new Page1();
        }

        private void BtnClickP2(object sender, RoutedEventArgs e)
        {
            Main.content = new Page2();
        }
    }
}
