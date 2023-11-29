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
using UchebPrak.Components;

namespace UchebPrak.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExamList.xaml
    /// </summary>
    public partial class ExamList : Page
    {
        public ExamList()
        {
            InitializeComponent();
            foreach(Examen exam in App.db.Examen.ToArray())
            {
                ExamsWp.Children.Add(new ExamenUserControl(exam));
            }
        }
    }
}
