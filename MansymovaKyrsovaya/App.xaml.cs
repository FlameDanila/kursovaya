using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MansymovaKyrsovaya
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static OcenkiEntities db = new OcenkiEntities();
        public static string name = "";
        public static int groupid = 1;
        public static string login = "";
        public static int tabelid = 0;
        public static int nameOfGroup = 0;
    }
}
