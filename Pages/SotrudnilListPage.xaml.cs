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
    /// Логика взаимодействия для SotrudnilListPage.xaml
    /// </summary>
    public partial class SotrudnilListPage : Page
    {
        public static WrapPanel SotrydniksWrapPanell;

        public SotrudnilListPage()
        {
            InitializeComponent();
            foreach (Sotrudnik sotrudnik in App.db.Sotrudnik.ToArray())
            {
                SotrudniksWp.Children.Add(new SotrudnikUserControl(sotrudnik));
            }
            SotrydniksWrapPanell = SotrudniksWp;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new AddEditSotrudnikPage(new Sotrudnik()));
        }
    }
}
