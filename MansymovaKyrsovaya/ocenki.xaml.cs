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
using word = Microsoft.Office.Interop.Word;

namespace MansymovaKyrsovaya
{
    /// <summary>
    /// Логика взаимодействия для ocenki.xaml
    /// </summary>
    public partial class ocenki : Window
    {
        public ocenki()
        {
            InitializeComponent();
            groups.ItemsSource = App.db.students.Select(n => n.name).ToList();
            groups.SelectedIndex = 0;
            if (App.tabelid == 1)
            {
                button.Visibility = Visibility.Visible;
            }
            Update();
        }

        public void Update()
        {
            list.ItemsSource = App.db.students.ToList();
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            var application = new word.Application();
            word.Document document = application.Documents.Add();

            var listr = App.db.students.Select(n => n.name).ToList();
            var listr2 = App.db.students.Select(n => n.math).ToList();
            var listr3 = App.db.students.Select(n => n.rus).ToList();
            var listr4 = App.db.students.Select(n => n.literature).ToList();
            var listr5 = App.db.students.Select(n => n.fizra).ToList();

            word.Paragraph paragraph = document.Paragraphs.Add();
            word.Range paragraphRange = paragraph.Range;

            paragraphRange.Text = "Студент " + "Оценки " + "\t\t" + "Математика" + " " + "Русский" + " " + "Лиетература" + " " + "Физкультура";
            paragraphRange.InsertParagraphAfter();

            for (int i = 0; i < listr.Count; i++)
            {
                word.Paragraph paragraph2 = document.Paragraphs.Add();
                word.Range paragraphRange2 = paragraph2.Range;

                paragraphRange2.Text = listr[i] + "\t\t\t\t" + listr2[i] + "\t\t" + listr3[i] + "\t\t" + listr4[i] + "\t\t" + listr5[i];
                paragraphRange2.InsertParagraphAfter();
            }
            application.Visible = true;
            document.SaveAs2($@"OTCHET.doc", FileMode.OpenOrCreate);
        }

        private void Image_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            changes changes = new changes();
            changes.Show();
            Close();
        }

        private void groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            list.ItemsSource = App.db.students.Where(Name => Name.name == groups.Text).ToList();
        }

        private void sbros_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
