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
    /// Логика взаимодействия для KafedraListPage.xaml
    /// </summary>
    public partial class KafedraListPage : Page
    {
        public KafedraListPage()
        {
            InitializeComponent();
            Filter();
        }

        private void KafedraSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            Kafedra[] kafedras = App.db.Kafedra.ToArray();
            switch (KafedraSortCb.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    kafedras = kafedras.OrderBy(x => x.Nazvanie).ToArray();
                    break;
                case 2:
                    kafedras = kafedras.OrderByDescending(x => x.Nazvanie).ToArray();
                    break;
            }
            if (SearchTb.Text != "")
                kafedras = kafedras.Where(x => x.Nazvanie.ToLower().Contains(SearchTb.Text.ToLower())).ToArray();
            KafedrasWp.Children.Clear();
            foreach (Kafedra kafedra in kafedras)
            {
                KafedrasWp.Children.Add(new KafedraUserControl(kafedra));
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new AddEditKafedraPage(new Kafedra()));
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
