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
    /// Логика взаимодействия для SotrudnikUserControl.xaml
    /// </summary>
    public partial class SotrudnikUserControl : UserControl
    {
        private Sotrudnik sotrudnik;

        public SotrudnikUserControl(Sotrudnik sotrudnik)
        {
            InitializeComponent();
            this.sotrudnik = sotrudnik;
            DataContext = this.sotrudnik;
        }

        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new AddEditSotrudnikPage(sotrudnik));
        }
    }
}
