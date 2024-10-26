using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClassLibrary1;

namespace GameFox
{
    /// <summary>
    /// Логика взаимодействия для Log2.xaml
    /// </summary>
    public partial class Log2 : Window
    {
        public RegistrationEntities2 db = new RegistrationEntities2();
        string log, pass, pass2, tel,pol,data;
        string phonePattern;
        string dataPattern;

        public Log2()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show(); this.Hide();
        }

        private void t1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (char.IsLetter(c))
                {
                    e.Handled = true;
                    return;
                }
            }
            int maxLength = 11; // Максимальное количество цифр, которое можно ввести

            if (t1 != null && t1.Text.Length >= maxLength)
            {
                e.Handled = true; // Отменить ввод, если достигнуто максимальное количество символов
            }
            else if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true; // Отменить ввод, если введенный символ не является цифрой
            }
        }

        private void t2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (char.IsLetter(c))
                {
                    e.Handled = true;
                    return;
                }
            }
            int maxLength = 10; // Максимальное количество цифр, которое можно ввести

            if (t2 != null && t2.Text.Length >= maxLength)
            {
                e.Handled = true; // Отменить ввод, если достигнуто максимальное количество символов
            }
            
        }

        private void bt4_Click(object sender, RoutedEventArgs e)
        {
            if (t3.Text!=null&& t4.Text!=null &&t5.Text!=null&&t6.Text!=null&&t7.Text!=null)
            {
                Пол p = db.Пол.Where(x => x.Наименование == pol).FirstOrDefault();
                Клиент klint = new Клиент
                {
                    Логин=log,
                    Пароль=pass,
                    Телефон=tel,
                    Дата_рождения=data,
                    Код_пола=p.Код_пола,
                    Улица=t3.Text,
                    Дом=t4.Text,
                    Комната=t5.Text,
                    Подъезд=t6.Text,
                    Этаж=t7.Text
                };
                db.Клиент.Add(klint);
                db.SaveChanges();
                MessageBox.Show("Вы зарегестрировались!");
                Welcome man = new Welcome();
                man.Show(); this.Close();
            }
            else
            {
                MessageBox.Show("ВВедены не все данные");
            }
        }

        private void t6_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (char.IsLetter(c))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void t7_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (char.IsLetter(c))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        private void b2_Click(object sender, RoutedEventArgs e)
        {
            Haracter.Visibility = Visibility.Hidden;
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (t1.Text != "" && t2.Text != "")
                {

                    tel = t1.Text;
                    if (Class1.Checkdata(t2.Text))
                    {
                        data = t2.Text;
                        if (r1.IsChecked == true)
                        {
                            pol = "Мужской";
                        }
                        else if (r2.IsChecked == true)
                        {
                            pol = "Женский";
                        }
                        else
                        {
                            pol = "Неопределенный";
                        }
                        adress.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("все плохо");
                    }


                }
                else
                {
                    MessageBox.Show("Не все данные введены!");
                }
            }
            catch
            {

            }
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            adress.Visibility = Visibility.Hidden;
        }

        int n = 1;
        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            log = textBox4.Text;
            pass = textBox5.Text;
            pass2 = textBox6.Text;
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                if (Class1.CheckPassword(pass))
                {

                    if (pass == pass2)
                    {
                        Haracter.Visibility = Visibility.Visible;
                       
                    }
                    else
                    {
                        MessageBox.Show("пароли не совпадают!");
                    }
                }
                else
                {
                    MessageBox.Show("Пароль не соответствует условиям сложности.");
                }
            }
            else
            {
                MessageBox.Show("Не все данные введены!");
            }
            
            
            //if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            //{
            //        if (Class1.CheckPassword(pass))
            //        {

            //            if (pass == pass2)
            //            {
            //                Клиент kli = new Клиент
            //                {
            //                    Логин = log,
            //                    Пароль = pass
            //                };
            //                n++;
            //                db.Клиент.Add(kli);
            //                db.SaveChanges();
            //                MessageBox.Show("Пользователь добавлен!");
            //            }
            //            else
            //            {
            //                MessageBox.Show("пароли не совпадают!");
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Пароль не соответствует условиям сложности.");
            //        }


            //}
            //else
            //{
            //    MessageBox.Show("Не все данные введены!");
            //}
        }
    }
}
