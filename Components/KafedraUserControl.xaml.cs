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
    public partial class KafedraUserControl : UserControl
    {
        private Kafedra kafedra;

        public KafedraUserControl(Kafedra kafedra)
        {
            InitializeComponent();
            this.kafedra = kafedra;
            DataContext = kafedra;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new AddEditKafedraPage(kafedra));
        }
    }
}
