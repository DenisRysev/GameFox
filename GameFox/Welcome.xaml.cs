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
    /// Логика взаимодействия для Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public FoxingEntities2 db = new FoxingEntities2();
        public Welcome()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var user = db.Пользователь.FirstOrDefault(x => x.Логин == textBox7.Text && x.Пароль == textBox8.Text);
            if (user != null)
            {
                    if (user.Разрешение == "Да")
                    {
                        if (user.Тип_пользователя == 1)
                        {
                            MessageBox.Show("Авторизация успешна");
                            Player usr = new Player(user);
                            usr.Show(); this.Hide();
                        }
                        else if (user.Тип_пользователя == 2)
                        {
                            MessageBox.Show("Авторизация успешна");
                            Player usr = new Player(user);
                            usr.Show(); this.Hide();
                        }
                        else if (user.Тип_пользователя == 4)
                        {
                        MessageBox.Show("Авторизация успешна");
                        Player usr = new Player(user);
                            usr.Show(); this.Hide();
                        }
                    }
                    else if (user.Разрешение == "Нет")
                    {
                        MessageBox.Show("Пользователь заблокирован");
                    }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует");
            }
        }

    }
}
