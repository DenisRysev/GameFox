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

namespace GameFox
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Window
    {
        public RegistrationEntities2 db = new RegistrationEntities2();
        public Пользователь user;
        List<Пользователь> zak = new List<Пользователь>();
        public History(Пользователь user)
        {
            InitializeComponent();
            this.user = user;
            zak = db.Пользователь.ToList();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            list.ItemsSource = zak;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Admin ad = new Admin(user);
            ad.Show(); this.Hide();
        }
    }
}
