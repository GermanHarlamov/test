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

namespace Гостиница
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new PageClient());
        }

        private void BtnNomer_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new PageNomer());

        }

        private void BtnJyrnal_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new PageJyrnal());

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Close();
            Hide();
        }
    }
}
