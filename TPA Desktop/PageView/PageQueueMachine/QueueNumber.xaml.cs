using QRCoder;
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
using TPA_Desktop.MVVM;

namespace TPA_Desktop.PageView.PageQueueMachine
{
    /// <summary>
    /// Interaction logic for QueueNumber.xaml
    /// </summary>
    public partial class QueueNumber : Page
    {

        public ModelViewQueue queue;

        public QueueNumber()
        {
            InitializeComponent();
            queue = new ModelViewQueue();
            DGQueue.ItemsSource = queue.grabDatabase();
        }

        private void Button_Generate(object sender, RoutedEventArgs e)
        {
            if (!txtName.Text.Equals(""))
            {
                String x = "QUE";

                if (queue.grabDatabase().Count() < 10)
                {
                    x += "00";
                    x += (queue.grabDatabase().Count()+1).ToString();
                }
                else if (queue.grabDatabase().Count() < 100)
                {
                    x += "0";
                    x += (queue.grabDatabase().Count() + 1).ToString();
                }
                else
                {
                    x += (queue.grabDatabase().Count() + 1).ToString();
                }

                queue.insertQueue(x, txtName.Text);

                DGQueue.ItemsSource = queue.grabDatabase();

                QRCodeGenerator qr = new QRCodeGenerator();
                QRCodeData data = qr.CreateQrCode(txtName.Text, QRCodeGenerator.ECCLevel.Q);
                XamlQRCode code = new XamlQRCode(data);

                DrawingImage qrCodeAsXaml = code.GetGraphic(20);
                qrCode.Source = qrCodeAsXaml;

                MessageBox.Show("Your Queue Number is " + x);

            }
            else
            {
                MessageBox.Show("Name must be filled");
            }
        }
    }
}
