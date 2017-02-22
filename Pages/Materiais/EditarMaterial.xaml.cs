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

namespace AlmoxarifadoUpas.Pages.Materiais
{
    /// <summary>
    /// Interaction logic for EditarMaterial.xaml
    /// </summary>
    public partial class EditarMaterial : UserControl
    {
        MateriaisA materiais = new MateriaisA();
        public EditarMaterial()
        {
            InitializeComponent();
            tabela.DataContext = materiais.listar();
        }

        private void UserControl_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            tabela.DataContext = materiais.listar();
        }

    }
}
