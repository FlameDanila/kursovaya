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

namespace MansymovaKyrsovaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Object sender = new Object();
            RoutedEventArgs e = new RoutedEventArgs();

            authButton_Click(sender, e);
        }
        public int Flag = 0;
        public int close = 0;

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxUser.Text == "Куратор")
            {
                List<kurators> kuratorsLoginList = App.db.kurators.ToList();

                var PasswordList = kuratorsLoginList.Select(n => n.password).ToList();
                var LoginList = kuratorsLoginList.Select(n => n.login).ToList();
                var NamesList = kuratorsLoginList.Select(n => n.name).ToList();
                var idList = kuratorsLoginList.Select(n => n.groupid).ToList();

                for (int i = 0; i < kuratorsLoginList.Count; i++)
                {
                    if (LoginBox.Text == LoginList[i])
                    {
                        if (PasswordBox.Text == PasswordList[i] || MyPasswordBox.Password == PasswordList[i])
                        {
                            App.name = NamesList[i];
                            App.login = LoginList[i];
                            App.groupid = Convert.ToInt32(idList[i]);
                            App.tabelid = 1;
                            MessageBox.Show("Авторизация прошла успешно");
                            ocenki ocenki = new ocenki();
                            ocenki.Show();
                            Close();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Пароль введен неверно");

                            PasswordBox.Text = ""; MyPasswordBox.Password = "";
                            break;
                        }
                    }
                }
            }
            else
            {
                List<students> studentsLoginList = App.db.students.ToList();

                var PasswordList = studentsLoginList.Select(n => n.password).ToList();
                var LoginList = studentsLoginList.Select(n => n.login).ToList();
                var NamesList = studentsLoginList.Select(n => n.name).ToList();

                for (int i = 0; i < studentsLoginList.Count; i++)
                {
                    if (LoginBox.Text == LoginList[i])
                    {
                        if (PasswordBox.Text == PasswordList[i] || MyPasswordBox.Password == PasswordList[i])
                        {
                            App.name = NamesList[i];
                            App.login = LoginList[i];
                            App.tabelid = 0;
                            MessageBox.Show("Авторизация прошла успешно");
                            ocenki ocenki = new ocenki();
                            ocenki.Show();
                            Close();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Пароль введен неверно");

                            PasswordBox.Text = ""; MyPasswordBox.Password = "";
                            break;
                        }
                    }
                }
            }
        }
        private void ShowPassword(object sender, RoutedEventArgs e)
        {
            PasswordBox.Text = MyPasswordBox.Password;
            MyPasswordBox.Visibility = Visibility.Hidden;
            PasswordBox.Visibility = Visibility.Visible;
        }

        private void UnshowPassword(object sender, RoutedEventArgs e)
        {
            MyPasswordBox.Password = PasswordBox.Text;
            PasswordBox.Visibility = Visibility.Hidden;
            MyPasswordBox.Visibility = Visibility.Visible;
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            Close();
        }
    }
}
