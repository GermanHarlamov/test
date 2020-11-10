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
    /// Логика взаимодействия для PageJyrnal.xaml
    /// </summary>
    public partial class PageJyrnal : Page
    {
        ГостиницаEntities db;
        public PageJyrnal()
        {
            InitializeComponent();
            db = new ГостиницаEntities();
            DataGridJyrnal.ItemsSource = db.Журнал.ToList();
            Sort.Items.Add("");
            Sort.Items.Add("Вселение");
            Sort.Items.Add("Выселение");
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Sort.SelectedValue.ToString() == "Вселение")
            {
                List<Журнал> jyr = db.Журнал.Where(b => b.ТипЗаписи == "Вселение").ToList();
                DataGridJyrnal.ItemsSource = jyr;
            }
            else if(Sort.SelectedValue.ToString() == "Выселение")
            {
                List<Журнал> jyr = db.Журнал.Where(b => b.ТипЗаписи == "Выселение").ToList();
                DataGridJyrnal.ItemsSource = jyr;
            }
            else
            {
                DataGridJyrnal.ItemsSource = db.Журнал.ToList();
            }
        }
    }
    
}
