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
        }

        private void KafedraSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            Kafedra[] Kafedras = App.db.Kafedra.ToArray();
            switch (FamiliaSortCb.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    sotrudniks = sotrudniks.OrderBy(x => x.Familia).ToArray();
                    break;
                case 2:
                    sotrudniks = sotrudniks.OrderByDescending(x => x.Familia).ToArray();
                    break;
            }
            switch (ZarplataSortCb.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    sotrudniks = sotrudniks.OrderBy(x => x.Zarplata).ToArray();
                    break;
                case 2:
                    sotrudniks = sotrudniks.OrderByDescending(x => x.Zarplata).ToArray();
                    break;
            }
            if (SearchTb.Text != "")
                sotrudniks = sotrudniks.Where(x => x.Familia.ToLower().Contains(SearchTb.Text.ToLower())).ToArray();
            SotrudniksWp.Children.Clear();
            foreach (Sotrudnik sotrudnik in sotrudniks)
            {
                SotrudniksWp.Children.Add(new SotrudnikUserControl(sotrudnik));
            }
        }
    }
}
