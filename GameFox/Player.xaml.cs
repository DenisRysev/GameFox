using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Player.xaml
    /// </summary>
    public partial class Player : Window
    {
        public static string rootPath = AppDomain.CurrentDomain.BaseDirectory;  // Путь к папке Debug
        private Пользователь user;
        int index;
        string log;
        public FoxingEntities2 db = new FoxingEntities2();
        public static string imageName = "";    // Имя файла текущего изображения
        public static string imageSource = "";

        public Player(Пользователь user)
        {
            InitializeComponent();
            this.user = user;
            index = Convert.ToInt32(user.Тип_пользователя);
            log = Convert.ToString(user.Логин);
        }
        
        private void back_Click(object sender, RoutedEventArgs e)
        {
            Igrotec spi = new Igrotec(index, log, user);
            spi.Show(); this.Hide();
        }
        private void redact_Click(object sender, RoutedEventArgs e)
        {
            Turnir ter = new Turnir(user);
            ter.Show(); this.Hide();
        }
        private void Ava_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Настройка диалогового окна
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "jpg (*.jpg)|*.jpg|All files (*.*)|*.*";
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;

                // Открытие диалогового окна
                if (openFileDialog.ShowDialog() == true)
                {
                    // Установка изображения в элемент Image
                    image1.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                    // Сохранение данных изображения
                    imageName = openFileDialog.SafeFileName;
                    imageSource = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка загрузки изображения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt1.Text = user.Имя;
            txt2.Text = user.Фамилия;
            txt3.Text = user.Логин;
            txt4.Text = user.Пароль;
            txt5.Text = user.email;
            
            txt6.Text = Convert.ToString(user.Тип_пользователя);
            if (user.Тип_пользователя == 4)
            {
                txt6.Text = "Мастер";
            }
            else if (user.Тип_пользователя == 2)
            {
                txt6.Text = "Администратор";
            }
            else if (user.Тип_пользователя == 1)
            {
                txt6.Text = "Игрок";
            }
            if (user.Тип_пользователя == 4)
            {
                if (user.Фото == null)
                {
                    image1.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(@"..\..\Ava\av3.jpg") + user.Фото));
                }
                else
                {
                    string savePath = System.IO.Path.GetFullPath(@"..\..\Ava\");
                    image1.Source = new BitmapImage(new Uri(savePath + user.Фото));
                }
            }
            else if (user.Тип_пользователя == 2)
            {
                if (user.Фото == null)
                {
                    image1.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(@"..\..\Ava\av1.jpg") + user.Фото));
                }
                else
                {
                    string savePath = System.IO.Path.GetFullPath(@"..\..\Ava\");
                    image1.Source = new BitmapImage(new Uri(savePath + user.Фото));
                }
            }
            else if (user.Тип_пользователя == 1)
            {
                if (user.Фото == null)
                {
                    image1.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(@"..\..\Ava\av2.jpg") + user.Фото));
                }
                else
                {
                    string savePath = System.IO.Path.GetFullPath(@"..\..\Ava\");
                    image1.Source = new BitmapImage(new Uri(savePath + user.Фото));
                }
            }
        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            Welcome we = new Welcome();
            we.Show(); this.Close();
        }
    }
}
