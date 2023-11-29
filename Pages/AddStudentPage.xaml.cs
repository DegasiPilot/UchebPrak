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
    /// Логика взаимодействия для AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        private Examen_Student examen_student;

        public AddStudentPage(Examen exam)
        {
            InitializeComponent();
            examen_student = new Examen_Student();
            examen_student.Examen_Id = exam.Id;
            DataContext = examen_student;
            Student[] usedStudents = App.db.Examen_Student.Where(x => x.Examen_Id == examen_student.Examen_Id).Select(x => x.Student).ToArray();
            StudentCb.ItemsSource = App.db.Student.ToArray().Except(usedStudents).ToArray();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFields())
            {
                App.db.Examen_Student.Add(examen_student);
                App.db.SaveChanges();
                App.MainFrame.Navigate(new ExamList());
            }
        }

        private bool CheckFields()
        {
            if (examen_student.Student_RegNomer == null)
            {
                MessageBox.Show("Выберите студента");
                return false;
            }
            else
                return true;
        }

        private void OcenkaTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 0)
                examen_student.Ocenka = int.Parse((sender as TextBox).Text);
            else
                examen_student.Ocenka = null;
        }

        private void OcenkaTbPreviewInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]) || int.Parse(e.Text) < 1 || int.Parse(e.Text) > 5)
            {
                e.Handled = true;
            }
        }

        private void StudentCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            examen_student.Student_RegNomer = ((sender as ComboBox).SelectedItem as Student).RegNomer;
        }
    }
}