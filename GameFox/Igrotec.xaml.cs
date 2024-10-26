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
using static System.Net.Mime.MediaTypeNames;

namespace GameFox
{
    /// <summary>
    /// Логика взаимодействия для Igrotec.xaml
    /// </summary>
    public partial class Igrotec : Window
    {
        FoxingEntities2 db = new FoxingEntities2 ();
        List<Игротека> igr =new List<Игротека>();
        List<Список> spi = new List<Список>();
        int kodsp;
        string log;
        int index;
        Пользователь user;

        public Igrotec(int index, string log, Пользователь user)
        {
            this.log = log;
            this.index = index;
            spi = db.Список.ToList();
            igr = db.Игротека.ToList();
            InitializeComponent();
            list1.ItemsSource = igr;
            for (int i = 0; i < spi.Count; i++)
            {
                cb1.Items.Add(spi[i].Наименование);
            }
            if (user.Тип_пользователя == 4 || user.Тип_пользователя == 2)
            {
                lb.Visibility = Visibility.Visible;
                lb1.Visibility = Visibility.Visible;
                lb2.Visibility = Visibility.Visible;
                cb1.Visibility = Visibility.Visible;
                txt2.Visibility = Visibility.Visible;
                txt1.Visibility = Visibility.Visible;
                bt.Visibility = Visibility.Visible;
            }
            this.user = user;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Список servis = db.Список.Where(x => x.Наименование == cb1.Text).FirstOrDefault();
            Игротека заказ = new Игротека
            {
                Код_пользователя =index,
                Время_начала=txt1.Text,
                Код_списка=servis.Код_списка,
                Количество_игроков=txt2.Text

            };
            db.Игротека.Add(заказ);
            db.SaveChanges();
            MessageBox.Show("Good");
            List<Игротека> ii = new List<Игротека>();
            ii = db.Игротека.ToList();
            list1.ItemsSource=ii;
        }

        private void list1_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
             
            Игротека servis = db.Игротека.Where(x => x.Код_игротеки == (list1.SelectedIndex+9)).FirstOrDefault();
            kodsp=Convert.ToInt32(servis.Код_списка);
            Spisok spisok = new Spisok(kodsp, user);
            spisok.Show(); this.Hide();
        }
    }
}
