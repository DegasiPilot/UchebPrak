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
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
