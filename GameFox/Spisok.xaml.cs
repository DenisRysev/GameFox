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
    /// Логика взаимодействия для Spisok.xaml
    /// </summary>
    public partial class Spisok : Window
    {
        public FoxingEntities2 db = new FoxingEntities2();
        List<Игра> game = new List<Игра>();
        int kodsp;
        int kodik;
        Пользователь user;

        public Spisok(int kodsp,Пользователь user)
        {
            InitializeComponent();
            this.user = user;
            this.kodsp = kodsp;
        }

        private void list1_Loaded(object sender, RoutedEventArgs e)
        {
            game = db.Игра.ToList<Игра>();

            for (int i = 0; i < game.Count; i++)
            {   if (game[i].Код_списка == kodsp)
                {
                    
                    WrapPanel wp = new WrapPanel();
                    System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                    Label LabelName = new Label();

                    wp.Height = 200;
                    wp.Width = 200;

                    LabelName.Content = game[i].Наименование;

                    string savePath = System.IO.Path.GetFullPath(@"..\..\Source");
                    savePath = savePath + "\\" + game[i].Фото;
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(savePath);
                    bitmap.EndInit();
                    img.Source = bitmap;


                    img.Height = 100;
                    img.Width = 100;

                    img.Uid = game[i].Код_списка.ToString();

                    wp.Children.Add(img);
                    wp.Children.Add(LabelName);

                    list1.Items.Add(wp);
                }
            }
        }
               
        private void list1_PreviewMouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            
            string savePath = System.IO.Path.GetFullPath(@"..\..\Source");
            BitmapImage bitmap = new BitmapImage();
            
            
            if (kodsp == 1)
            {

                Игра servis = db.Игра.Where(x => x.Код_игры == (list1.SelectedIndex + 1)).FirstOrDefault();
                Категории katy = db.Категории.Where(x => x.Код_категории == servis.Код_категории).FirstOrDefault();
                Жанр zhan = db.Жанр.Where(x => x.Код_жанра == servis.Код_жанра).FirstOrDefault();
                Тематика tema = db.Тематика.Where(x => x.Код_тематики == servis.Код_тематики).FirstOrDefault();
                savePath = savePath + "\\" + servis.Фото;
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(savePath);
                bitmap.EndInit();
                img.Source = bitmap;
                opis.Text = Convert.ToString(servis.Описание);
                kat.Text = Convert.ToString(katy.Наименование);
                jan.Text = Convert.ToString(zhan.Наименование);
                tem.Text = Convert.ToString(tema.Наименование);

            }
            else if (kodsp == 2)
            {
                Игра servis = db.Игра.Where(x => x.Код_игры == (list1.SelectedIndex + 3)).FirstOrDefault();
                Категории katy = db.Категории.Where(x => x.Код_категории == servis.Код_категории).FirstOrDefault();
                Жанр zhan = db.Жанр.Where(x => x.Код_жанра == servis.Код_жанра).FirstOrDefault();
                Тематика tema = db.Тематика.Where(x => x.Код_тематики == servis.Код_тематики).FirstOrDefault();
                savePath = savePath + "\\" + servis.Фото;
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(savePath);
                bitmap.EndInit();
                img.Source = bitmap;
                opis.Text = Convert.ToString(servis.Описание);
                kat.Text = Convert.ToString(katy.Наименование);
                jan.Text = Convert.ToString(zhan.Наименование);
                tem.Text = Convert.ToString(tema.Наименование);
            }
            else if (kodsp == 3)
            {
                Игра servis = db.Игра.Where(x => x.Код_игры == (list1.SelectedIndex + 6)).FirstOrDefault();
                Категории katy = db.Категории.Where(x => x.Код_категории == servis.Код_категории).FirstOrDefault();
                Жанр zhan = db.Жанр.Where(x => x.Код_жанра == servis.Код_жанра).FirstOrDefault();
                Тематика tema = db.Тематика.Where(x => x.Код_тематики == servis.Код_тематики).FirstOrDefault();
                savePath = savePath + "\\" + servis.Фото;
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(savePath);
                bitmap.EndInit();
                img.Source = bitmap;
                opis.Text = Convert.ToString(servis.Описание);
                kat.Text = Convert.ToString(katy.Наименование);
                jan.Text = Convert.ToString(zhan.Наименование);
                tem.Text = Convert.ToString(tema.Наименование);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Player pl = new Player(user);
            pl.Show();
            this.Close();
        }
    }
}
