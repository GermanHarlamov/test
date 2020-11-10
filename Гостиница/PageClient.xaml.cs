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

namespace Гостиница
{
    /// <summary>
    /// Логика взаимодействия для PageClient.xaml
    /// </summary>
    public partial class PageClient : Page
    {
        ГостиницаEntities db;
        public PageClient()
        {
            InitializeComponent();
            db = new ГостиницаEntities();
            DataGridClient.ItemsSource = db.Клиенты.ToList();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow wind = new AddClientWindow();
            wind.datagrid = this.DataGridClient;
            wind.Show();
        }

        private void DelClient_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridClient.SelectedItem == null)
                return;
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить запись?", "Вы уверены?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    db = new ГостиницаEntities();
                    var r = DataGridClient.SelectedItem as Клиенты;
                    var f = db.Клиенты.Where(b => b.ИДКлиента == r.ИДКлиента).FirstOrDefault();
                    db.Клиенты.Remove(f);
                    db.SaveChanges();
                    DataGridClient.ItemsSource = db.Клиенты.ToList();
                    break;
                case MessageBoxResult.No:
                    
                    break;
            }
        }
    }
}
