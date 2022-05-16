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

namespace MansymovaKyrsovaya
{
    /// <summary>
    /// Логика взаимодействия для changes.xaml
    /// </summary>
    public partial class changes : Window
    {
        public changes()
        {
            InitializeComponent();
            groups.ItemsSource = App.db.students.Select(n => n.name).ToList();
            groups.SelectedIndex = 0;
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            var Body = App.db.students.Where(p => p.name == App.name).FirstOrDefault();

            Body.name = App.name;
            Body.math = Convert.ToInt32(mathText.Text);
            Body.rus = Convert.ToInt32(rusText.Text);
            Body.literature = Convert.ToInt32(litText.Text);
            Body.fizra = Convert.ToInt32(fizText.Text);

            App.db.SaveChanges();

            MessageBox.Show("Изменения сохранены");
        }

        private void select(object sender, RoutedEventArgs e)
        {
            mathText.IsEnabled = true;
            litText.IsEnabled = true;
            fizText.IsEnabled = true;
            rusText.IsEnabled = true;

            var list = App.db.students.Select(n => n.name).ToList();
            var listOfMath = App.db.students.Select(n => n.math).ToList();
            var listOfRus = App.db.students.Select(n => n.rus).ToList();
            var listOfLit = App.db.students.Select(n => n.literature).ToList();
            var listOfFiz = App.db.students.Select(n => n.fizra).ToList();

            App.name = groups.Text;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == groups.Text)
                {
                    mathText.Text = listOfMath[i].ToString();
                    litText.Text = listOfLit[i].ToString();
                    fizText.Text = listOfFiz[i].ToString();
                    rusText.Text = listOfRus[i].ToString();
                }
            }
        }

        private void Image_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            ocenki ocenki = new ocenki();
            ocenki.Show();
            Close();
        }
    }
}
