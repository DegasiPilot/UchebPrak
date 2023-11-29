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

using UchebPrak.Pages;

namespace UchebPrak.Components
{
    /// <summary>
    /// Логика взаимодействия для ExamenUserControl.xaml
    /// </summary>
    public partial class ExamenUserControl : UserControl
    {
        private Examen examen;

        public ExamenUserControl(Examen examen)
        {
            InitializeComponent();
            this.examen = examen;
            DataContext = examen;
            Examen_Student[] examen_student = App.db.Examen_Student.Where(x => x.Examen_Id == examen.Id).ToArray();
            foreach(Examen_Student e_s in examen_student)
            {
                StudentsWp.Children.Add(new StudentUserControl(e_s));
            }
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new AddStudentPage(examen));
        }
    }
}
