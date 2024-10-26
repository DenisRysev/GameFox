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
    /// Логика взаимодействия для Turnir.xaml
    /// </summary>
    public partial class Turnir : Window
    {
        FoxingEntities2 db = new FoxingEntities2();
        List<Турнир> igr = new List<Турнир>();
        List<Игра> spi = new List<Игра>();
        List<Заявка> zai = new List<Заявка>();
        Пользователь user;
        public Turnir(Пользователь user)
        {
            InitializeComponent();
            this.user = user;
            if (user.Тип_пользователя == 4 || user.Тип_пользователя == 2)
            {
                lb1.Visibility = Visibility.Visible;
                lb2.Visibility = Visibility.Visible;
                cb1.Visibility = Visibility.Visible;
                dp1.Visibility = Visibility.Visible;
                lb3.Visibility = Visibility.Visible;
                txt1.Visibility = Visibility.Visible;
                btn.Visibility = Visibility.Visible;
            }
            spi = db.Игра.ToList();
            igr = db.Турнир.ToList();
            zai = db.Заявка.ToList();
            list1.ItemsSource = igr;
            for (int i = 0; i < spi.Count; i++)
            {
                cb1.Items.Add(spi[i].Наименование);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Турнир заказ = new Турнир
            {
                Наименование = txt1.Text,
                Код_мастера = user.Код,
                Дата_начала = dp1.SelectedDate,
                Код_игры = cb1.SelectedIndex + 1,
            };
            db.Турнир.Add(заказ);
            db.SaveChanges();
            MessageBox.Show("Good");
            List<Турнир> ii = new List<Турнир>();
            ii = db.Турнир.ToList();
            list1.ItemsSource = ii;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Zaivka zai = new Zaivka(user);
            zai.Show(); this.Close();
        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            Player pl = new Player(user); pl.Show(); this.Close();
        }
    }
}
