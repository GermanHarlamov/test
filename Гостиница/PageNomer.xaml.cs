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
    /// Логика взаимодействия для PageNomer.xaml
    /// </summary>
    public partial class PageNomer : Page
    {
        ГостиницаEntities db;
        public PageNomer()
        {
            InitializeComponent();
            db = new ГостиницаEntities();
            DataGridNomer.ItemsSource = db.Номера.ToList();
        }

        private void AddNomer_Click(object sender, RoutedEventArgs e)
        {
            AddNomerWindow wind = new AddNomerWindow();
            wind.datagrid = this.DataGridNomer;
            wind.Show();
        }

        private void DelNomer_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridNomer.SelectedItem == null)
                return;
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить запись?", "Вы уверены?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    db = new ГостиницаEntities();
                    
                    Номера r = DataGridNomer.SelectedItem as Номера;
                    var f = db.Номера.Where(b => b.ИДНомера == r.ИДНомера).FirstOrDefault();
                    db.Номера.Remove(f);
                    db.SaveChanges();
                    DataGridNomer.ItemsSource = db.Номера.ToList();
                    break;
                case MessageBoxResult.No:

                    break;
            }
        }
    }
}
