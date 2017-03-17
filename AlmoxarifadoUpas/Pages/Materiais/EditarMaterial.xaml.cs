using AlmoxarifadoUpas.Context;
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
        IMateriais materiais = new MaterialDAO();
        MaterialA row;
        public EditarMaterial()
        {
            InitializeComponent();
            cbUnidade.ItemsSource = Enum.GetValues(typeof(Unidade)).Cast<Unidade>();
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {         
            row = (MaterialA)tabela.SelectedItems[0];
            TextCodigo.Text = row.Codigo;
            TextNome.Text = row.Nome;
            cbUnidade.Text = row.Unidade;
        }

        private void Confirmar_Click(object sender, RoutedEventArgs e)
        {
            materiais.EditarMaterial(row.Id_material, TextCodigo.Text, TextNome.Text, cbUnidade.Text);
            tabela.DataContext = materiais.ListarMateriais();

            TextCodigo.Clear();
            TextNome.Clear();
            cbUnidade.SelectedIndex = 1;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tabela.DataContext = materiais.ListarMateriais();
        }
    }

}
