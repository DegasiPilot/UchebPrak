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

namespace UchebPrak.Components
{
    /// <summary>
    /// Логика взаимодействия для StudentUserControl.xaml
    /// </summary>
    public partial class StudentUserControl : UserControl
    {
        private Examen_Student examen_student;

        public StudentUserControl(Examen_Student examen_student)
        {
            InitializeComponent();
            this.examen_student = examen_student;
            DataContext = examen_student;
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.SaveChanges();
        }

        private void OcenkaTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 0)
            {
                examen_student.Ocenka = int.Parse((sender as TextBox).Text);
            }
            else
                examen_student.Ocenka = null;
            App.db.SaveChanges();
        }

        private void OcenkaTbPreviewInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]) || int.Parse(e.Text) < 1 || int.Parse(e.Text) > 5)
            {
                e.Handled = true;
            }     
        }
    }
}
