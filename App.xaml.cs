using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UchebPrak.Components;

namespace UchebPrak
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Frame MainFrame;
        public static UchebPratika_Entities db = new UchebPratika_Entities();
        public static Sotrudnik User;
    }
}
