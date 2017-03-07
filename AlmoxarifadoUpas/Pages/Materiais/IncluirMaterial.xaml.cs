using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Xml;
using System.Data;
using System;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Linq;
using AlmoxarifadoUpas.Context;

namespace AlmoxarifadoUpas.Pages
{
    /// <summary>
    /// Interaction logic for IncluirMaterial.xaml
    /// </summary>
    public partial class IncluirMaterial : UserControl
    {
        IMateriais materiais = new MaterialDAO();
        public IncluirMaterial()
        {
            InitializeComponent();
            cbUnidade.ItemsSource = Enum.GetValues(typeof(Unidade)).Cast<Unidade>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (materiais.VerificarSeCodigoExiste(TextCodigo.Text))
            {
                MaterialA material = new MaterialA();
                material.codigo = TextCodigo.Text;
                material.nome = TextNome.Text;
                material.unidade = cbUnidade.SelectedItem.ToString();

                materiais.InserirMaterial(material);
                TextCodigo.Text = "";
                TextNome.Text = "";
                cbUnidade.Text = "";
            }
            else
            {
                MessageBox.Show("Código ja cadastrado no sistema !", Application.Current.MainWindow.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                TextCodigo.Text = "";
                return;
            }
        }

    }
}
