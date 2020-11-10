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
    /// Логика взаимодействия для AddNomerWindow.xaml
    /// </summary>
    public partial class AddNomerWindow : Window
    {
        public DataGrid datagrid;
        ГостиницаEntities db;
        

        public AddNomerWindow()
        {
            InitializeComponent();
            db = new ГостиницаEntities();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string Nazvanie = NazvBox.Text;
            int Vmestimost = Int32.Parse(VmestBox.Text);
            string Komfortnost = KomfortBox.Text;
            decimal money = decimal.Parse(Money.Text);
            if (Nazvanie.Length > 0 && Vmestimost > 0 && Komfortnost.Length > 0 && money > 0)
            {
                Номера nomer = new Номера(Nazvanie, Vmestimost, Komfortnost, money);
                db.Номера.Add(nomer);
                db.SaveChanges();
                datagrid.ItemsSource = db.Номера.ToList();
                this.Close();
            }
        }
    }
}
