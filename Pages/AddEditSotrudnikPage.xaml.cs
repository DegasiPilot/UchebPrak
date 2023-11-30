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
    /// Логика взаимодействия для AddEditSotrudnikPage.xaml
    /// </summary>
    public partial class AddEditSotrudnikPage : Page
    {
        private Sotrudnik sotrudnik;

        public AddEditSotrudnikPage(Sotrudnik sotrudnik)
        {
            InitializeComponent();
            this.sotrudnik = sotrudnik;
            DataContext = this.sotrudnik;
            KafedraCb.ItemsSource = App.db.Kafedra.ToArray();
            KafedraCb.SelectedItem = sotrudnik.Kafedra;
            DolgnostCb.ItemsSource = App.db.Sotrudnik.ToArray().Select(x => x.Dolgnost).Distinct();
            DolgnostCb.SelectedItem = sotrudnik.Dolgnost;
            ShefCb.ItemsSource = App.db.Zav_Kafedra.ToArray();
            ShefCb.SelectedItem = sotrudnik.Zav_Kafedra;
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBlank())
            {
                if (!App.db.Sotrudnik.Any(x => x.TabNomer == sotrudnik.TabNomer))
                    App.db.Sotrudnik.Add(sotrudnik);
                App.db.SaveChanges();
            }
        }

        private bool CheckBlank()
        {
            StringBuilder errors = new StringBuilder();
            if (KafedraCb.SelectedItem == null)
                errors.AppendLine("Выберите кафедру");
            if (FamiliaTb.Text == "")
                errors.AppendLine("Введите фамилию");
            if (DolgnostCb.SelectedItem == null)
                errors.AppendLine("Выберите должность");
            if (ZarplataTb.Text == "")
                errors.AppendLine("Введите зарплату");
            if (ShefCb.SelectedItem == null)
                errors.AppendLine("Выберите шефа");

            if (errors.Length > 0)
                return false;
            else
                return true;
        }

        private void FamiliaPreviewInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text[0]) && !char.IsWhiteSpace(e.Text[0]) && e.Text[0] != '.')
                e.Handled = true;
        }

        private void ZarplataPreviewInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private void DolgnostCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedItem.ToString() == "зав. кафедрой")
            {
                ShefCb.IsEnabled = false;
                Zav_Kafedra zav_Kafedra = new Zav_Kafedra();
                zav_Kafedra.TabNomer = sotrudnik.TabNomer;
                App.db.Zav_Kafedra.Add(zav_Kafedra);
                ShefCb.ItemsSource = App.db.Zav_Kafedra.ToArray();
                ShefCb.SelectedItem = zav_Kafedra;
                sotrudnik.Shef_Id = sotrudnik.TabNomer;
            }
            else
            {
                ShefCb.IsEnabled = true;
                if (App.db.Zav_Kafedra.Any(x => x.TabNomer == sotrudnik.TabNomer))
                {
                    Zav_Kafedra zav_Kafedra = App.db.Zav_Kafedra.First(x => x.TabNomer == sotrudnik.TabNomer);
                    App.db.Zav_Kafedra.Remove(zav_Kafedra);
                    ShefCb.ItemsSource = App.db.Zav_Kafedra.ToArray();
                    ShefCb.SelectedItem = null;
                    sotrudnik.Shef_Id = null;
                }
            }
        }
    }
}
