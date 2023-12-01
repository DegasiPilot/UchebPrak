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
        private Zav_Kafedra zav_Kafedra;
        private bool isNew;

        public AddEditSotrudnikPage(Sotrudnik sotrudnik)
        {
            InitializeComponent();
            this.sotrudnik = sotrudnik;
            DataContext = this.sotrudnik;
            isNew = !App.db.Sotrudnik.Any(x => x.TabNomer == sotrudnik.TabNomer);
            ShefCb.ItemsSource = App.db.Zav_Kafedra.ToArray();
            KafedraCb.ItemsSource = App.db.Kafedra.ToArray();
            DolgnostCb.ItemsSource = App.db.Sotrudnik.ToArray().Select(x => x.Dolgnost).Distinct();
            if (!isNew)
            {
                TabNomerTb.IsReadOnly = true;
                KafedraCb.SelectedItem = sotrudnik.Kafedra;
                DolgnostCb.SelectedItem = sotrudnik.Dolgnost;
                ShefCb.SelectedItem = App.db.Zav_Kafedra.First(x => x.TabNomer == sotrudnik.Shef_Id);
            }
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBlank())
            {
                sotrudnik.Kafedra_Shifr = KafedraCb.Text;
                sotrudnik.Familia = FamiliaTb.Text;
                sotrudnik.Dolgnost = DolgnostCb.Text;
                sotrudnik.Zarplata = int.Parse(ZarplataTb.Text);
                sotrudnik.Shef_Id = zav_Kafedra == null ? int.Parse(ShefCb.Text) : sotrudnik.TabNomer;

                if (isNew)
                {
                    if(!App.db.Sotrudnik.Any(x => x.TabNomer == sotrudnik.TabNomer))
                        App.db.Sotrudnik.Add(sotrudnik);
                    else
                    {
                        MessageBox.Show("Сотрудник с таким таб. номером уже существует!");
                        return;
                    }

                }
                if (zav_Kafedra != null && !App.db.Zav_Kafedra.Any(x => x.TabNomer == zav_Kafedra.TabNomer))
                {
                    zav_Kafedra.TabNomer = sotrudnik.TabNomer;
                    App.db.Zav_Kafedra.Add(zav_Kafedra);
                }
                    
                App.db.SaveChanges();
                App.MainFrame.Navigate(new SotrudnilListPage());
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
            if (ShefCb.SelectedItem == null && zav_Kafedra == null)
                errors.AppendLine("Выберите шефа");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return false;
            }
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
                zav_Kafedra = new Zav_Kafedra();
                zav_Kafedra.TabNomer = sotrudnik.TabNomer;
                sotrudnik.Shef_Id = sotrudnik.TabNomer;
                ShefCb.IsEnabled = false;
            }
            else
            {
                ShefCb.IsEnabled = true;
                if (App.db.Zav_Kafedra.Any(x => x.TabNomer == sotrudnik.TabNomer))
                {
                    zav_Kafedra = null;
                    ShefCb.ItemsSource = App.db.Zav_Kafedra.ToArray();
                    ShefCb.SelectedItem = null;
                    sotrudnik.Shef_Id = null;
                }
            }
        }
    }
}