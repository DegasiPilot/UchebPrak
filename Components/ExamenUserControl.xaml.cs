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
            FamiliaSortCb.SelectedIndex = 0;
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new AddStudentPage(examen));
        }

        private void FamiliaSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter(); 
        }

        private void Filter()
        {
            Examen_Student[] examen_student = App.db.Examen_Student.Where(x => x.Examen_Id == examen.Id).ToArray();
            switch (FamiliaSortCb.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    examen_student = examen_student.OrderBy(x => x.Student.Familia).ToArray();
                    break;
                case 2:
                    examen_student = examen_student.OrderByDescending(x => x.Student.Familia).ToArray();
                    break;
            }
            if(SearchTb.Text != "")
                examen_student = examen_student.Where(x => x.Student.Familia.ToLower().Contains(SearchTb.Text.ToLower())).ToArray();
            StudentsWp.Children.Clear();
            foreach (Examen_Student e_s in examen_student)
            {
                StudentsWp.Children.Add(new StudentUserControl(e_s));
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
