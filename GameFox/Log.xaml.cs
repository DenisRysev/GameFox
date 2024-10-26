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
using ClassLibrary1;

namespace GameFox
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        public FoxingEntities2 db = new FoxingEntities2();
        string fam, name, potch, log, pass, pass2;
        public Log()
        {
            InitializeComponent();
            Captcha();
        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Welcome wel = new Welcome();
            wel.Show();
            this.Hide();
        }


        string pwd = "";
        public void Captcha()
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            // записываем набор символов в массив
            String[] ar = allowchar.Split(a);
            pwd = ""; //переменная в которой будет хранится значение капчи string temp = " "; //переменная, в которую будет записываться рандомный символ из массива Random r = new Random();
            string temp = " ";
            Random r = new Random();
            int kol = 6; // количество символов в капче
            for (int i = 0; i < kol; i++)
            {
                // генерируем рандомный символ из массива // мы берем элемент массива и задаем рандомный индекс элемента // обратите внимание, что диапазон рандома начинается с 0 и заканчивается длиной массива символов
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
                //выводим сформированный текст в поле

            }
            label3.Content = pwd;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            fam = textBox1.Text;
            name = textBox2.Text;
            potch = textBox3.Text;
            log = textBox4.Text;
            pass = textBox5.Text;
            pass2 = textBox6.Text;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                if (Class1.CheckMail(potch))
                {
                    if (Class1.CheckPassword(pass))
                    {

                        if (pass == pass2)
                        {
                            if (textBox10.Text == pwd)
                            {
                                Пользователь registr = new Пользователь
                                {
                                    Фамилия = fam,
                                    Имя = name,
                                    Логин = log,
                                    email = potch,
                                    Пароль = pass,
                                    Код = n,
                                    Доступ = false,
                                    Разрешение = "Да"

                            };
                                n++;
                                db.Пользователь.Add(registr);
                                db.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("Вы не ввели капчу или сделали это не правильно");
                                Captcha();
                            }
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
                    MessageBox.Show("Некорректный формат почты.");
                }


            }
            else
            {
                MessageBox.Show("Не все данные введены!");
            }
        }
        int n = 1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox1.Clear();
            textBox2.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox3.Clear();
            textBox4.Text = "";
            textBox4.Clear();
            textBox5.Text = "";
            textBox5.Clear();
            textBox6.Text = "";
            textBox6.Clear();
        }
    }
}
