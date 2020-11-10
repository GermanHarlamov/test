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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ГостиницаEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ГостиницаEntities();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text;
            string pass = PassBox.Password;

            Пользователи user;

            user = db.Пользователи.Where(b => b.Логин == login && b.Пароль == pass).FirstOrDefault();
            if (user != null && user.Роль == "Admin")
            {
                AdminPanel okno = new AdminPanel();
                okno.Show();
                Hide();
            }
            else if (user != null && user.Роль == "User")
            {

            }
        }
    }
}
