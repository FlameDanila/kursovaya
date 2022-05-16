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

namespace MansymovaKyrsovaya
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            List<string> listOfItems = App.db.groups.Select(n => n.name).ToList();
            foreach (var group in listOfItems)
            {
                groups.Items.Add(group);
            }
            groups.Items.Add("Нет");
            groups.SelectedItem = "Нет";
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            if (Error.Visibility == Visibility.Visible)
            { MessageBox.Show("Этот логин уже занят, придумайте другой"); }
            else
            {
                if (nameText.Text == "" || PasswordBox.Text == "" || LoginBox.Text == "" || RepeatPassBox.Password == "")
                { MessageBox.Show("У вас остались незаполненые поля"); }
                else
                {
                    if (PasswordBox.Text != RepeatPassBox.Password)
                    { MessageBox.Show("Пароли должны совпадать!"); }
                    else
                    {
                        if (ComboBoxUser.Text == "Студент")
                        {
                            var listofitems = groups.ItemsSource;
                            students students = new students()
                            {
                                login = LoginBox.Text,
                                password = PasswordBox.Text,
                                groupId = App.nameOfGroup,
                                name = nameText.Text
                            };

                            App.db.students.Add(students);
                            App.db.SaveChanges();
                            MessageBox.Show("Студент " + nameText.Text + " добавлен");
                        }
                        else
                        {
                            kurators students = new kurators()
                            {
                                login = LoginBox.Text,
                                password = PasswordBox.Text,
                                groupid = App.nameOfGroup,
                                name = nameText.Text
                            };
                            App.db.kurators.Add(students);
                            App.db.SaveChanges();
                            MessageBox.Show("Куратор " + nameText.Text + " добавлен");
                        }
                        List<kurators> kuratorsLoginList = App.db.kurators.ToList();
                        List<students> studentsLoginList = App.db.students.ToList();

                        var LoginList = kuratorsLoginList.Select(n => n.login).ToList();
                        LoginList.AddRange(studentsLoginList.Select(n => n.login).ToList());

                        if (LoginList.Contains(LoginBox.Text))
                        {
                            Error.Visibility = Visibility.Visible;
                        }
                        else { Error.Visibility = Visibility.Hidden; }
                    }
                }
            }
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<kurators> kuratorsLoginList = App.db.kurators.ToList();
            List<students> studentsLoginList = App.db.students.ToList();

            var LoginList = kuratorsLoginList.Select(n => n.login).ToList();
            LoginList.AddRange(studentsLoginList.Select(n => n.login).ToList());

            if (LoginList.Contains(LoginBox.Text))
            {
                Error.Visibility = Visibility.Visible;
            }
            else { Error.Visibility = Visibility.Hidden; }
        }

        private void Image_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^а-яА-Я]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void DigitsTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = App.db.groups.Select(n => n.name).ToList();
            var listOfId = App.db.groups.Select(n => n.id).ToList();
            for (int i = 0; i < list.Count(); i++)
            {
                if (groups.Text == list[i])
                {
                    App.nameOfGroup = listOfId[i];
                }
            }
        }
    }
}
