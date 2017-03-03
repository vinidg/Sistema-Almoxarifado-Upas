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
        }

        private void tabela_Initialized(object sender, EventArgs e)
        {
            tabela.DataContext = materiais.Listar();
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {         
                row = (MaterialA)tabela.SelectedItems[0];
                TextCodigo.Text = row.codigo;
                TextNome.Text = row.nome;
                TextUnidade.Text = row.unidade;
            
        }

        private void Confirmar_Click(object sender, RoutedEventArgs e)
        {
            materiais.EditarMaterial(row.id_material, TextCodigo.Text, TextNome.Text, TextUnidade.Text);
            tabela.DataContext = materiais.Listar();
        }

        private void UserControl_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            tabela.DataContext = materiais.Listar();
        }
    }

}
