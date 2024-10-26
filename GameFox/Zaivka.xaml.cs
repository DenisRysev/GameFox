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
    /// Логика взаимодействия для Zaivka.xaml
    /// </summary>
    public partial class Zaivka : Window
    {
        FoxingEntities2 db = new FoxingEntities2();
        List<Турнир> igr = new List<Турнир>();
        Пользователь user;
        public Zaivka(Пользователь user)
        {
            this.user = user;
            InitializeComponent();
            igr = db.Турнир.ToList();
            for (int i = 0; i < igr.Count; i++)
            {
                cb1.Items.Add(igr[i].Наименование);
            }
            txt1.Text = user.Имя;
            txt2.Text = user.Фамилия;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Турнир servis = db.Турнир.Where(x => x.Наименование == cb1.Text).FirstOrDefault();
            Заявка заказ = new Заявка
            {
                Код_пользователя = user.Код,
                Возраст = dp1.SelectedDate,
                Код_турнира = servis.Код_турнира,
                ФИО = user.Имя

            };
            db.Заявка.Add(заказ);
            db.SaveChanges();
            MessageBox.Show("Good");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Turnir tu = new Turnir(user);
            tu.Show(); this.Close();
        }
    }
}
