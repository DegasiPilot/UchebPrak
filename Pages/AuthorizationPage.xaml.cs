using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

namespace UchebPrak.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public int[] TabNomers;

        public AuthorizationPage()
        {
            InitializeComponent();
            TabNomers = App.db.Sotrudnik.Select(x => x.TabNomer).ToArray();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TabNomerTb.Text != "")
            {
                int tabNomer = int.Parse(TabNomerTb.Text);
                if (TabNomers.Contains(tabNomer))
                {
                    App.User = App.db.Sotrudnik.First(x => x.TabNomer == tabNomer);
                    MessageBox.Show($"Вы вошли как {App.User.Familia}, ваша роль {App.User.Dolgnost}");
                    EnterAs(App.User.Dolgnost);
                }
                else
                    MessageBox.Show($"Сотрудника с таб. номером {TabNomerTb.Text} не существует");
            }
            else
            {
                MessageBox.Show("Вы вошли как гость!");
                EnterAs("гость");
            }
        }

        private void TabNomerPreviewInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private void EnterAs(string role)
        {
            switch (role)
            {
                case "зав. кафедрой":
                    App.MainFrame.Navigate(new KafedraListPage());
                    break;
                case "преподаватель":
                    App.MainFrame.Navigate(new ExamList());
                    break;
                case "инженер":
                    App.MainFrame.Navigate(new SotrudnilListPage());
                    break;
                case "гость":
                    App.MainFrame.Navigate(new DisciplinaListPage());
                    break;
                case "":
                    break;
            }
        }

        private void CreateQRBtn_Click(object sender, RoutedEventArgs e)
        {
            // Ссылка на XL таблицу
            string soucer_xl = "https://w.wiki/8Ls8";
            // Создание переменной библиотеки QRCoder
            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
            // Присваеваем значиения
            QRCoder.QRCodeData data = qr.CreateQrCode(soucer_xl, QRCoder.QRCodeGenerator.ECCLevel.L);
            // переводим в Qr
            QRCoder.QRCode code = new QRCoder.QRCode(data);
            Bitmap bitmap = code.GetGraphic(100);
            /// Создание картинки
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                imageQr.Source = bitmapimage;
            }
        }
    }
}
