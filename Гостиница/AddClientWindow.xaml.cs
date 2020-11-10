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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        ГостиницаEntities db;
        public DataGrid datagrid;
        int i;
        public AddClientWindow()
        {
            InitializeComponent();
            db = new ГостиницаEntities();
            foreach (Номера nomer in db.Номера)
            {
                i = 0;
                foreach (Клиенты client in db.Клиенты)
                {
                    if (nomer.ИДНомера != client.ИДНомера)
                    {
                        i++;
                    }
                }
                if (i == db.Клиенты.Count())
                {
                    NomeraBox.Items.Add(nomer.НазваниеНомера.ToString());
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string Familiya = FamiliyaBox.Text;
            string Imya = ImyaBox.Text;
            string Otchestvo = OtchestvoBox.Text;
            string komment = Kommentarii.Text;
            int nomer = db.Номера.Where(b => b.НазваниеНомера == NomeraBox.SelectedValue.ToString()).FirstOrDefault().ИДНомера; 
            
            if (Familiya.Length > 0 && Imya.Length > 0 && Otchestvo.Length > 0 && NomeraBox.SelectedValue != null)
            {
                Клиенты klient = new Клиенты(Familiya, Imya, Otchestvo, komment, nomer);
                db.Клиенты.Add(klient);
                db.SaveChanges();
                datagrid.ItemsSource = db.Клиенты.ToList();
                this.Close();
            }
        }
    }
}
