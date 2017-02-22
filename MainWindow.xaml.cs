using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace AlmoxarifadoUpas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();           
        }

        private void ModernWindow_Initialized(object sender, EventArgs e)
        {
            string con = (string)ConfigurationSettings.AppSettings["ConnectionString"];
            Criptografia cript = new Criptografia();
            Console.WriteLine(cript.DecryptConnectionString());
            Console.WriteLine(con);


        }
    }
}
