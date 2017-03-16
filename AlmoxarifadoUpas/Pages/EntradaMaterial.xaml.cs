using AlmoxarifadoUpas.Context;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace AlmoxarifadoUpas.Pages
{
    /// <summary>
    /// Interaction logic for Entrada.xaml
    /// </summary>
    public partial class Entrada : UserControl
    {
        IMateriais materiais = new MaterialDAO();
        public Entrada()
        {
            InitializeComponent();
        }

        private void validacaoNumero(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Confirmar_Click(object sender, RoutedEventArgs e)
        {
            int id_material = 0;

            try
            {
                id_material = materiais.PegarIdMaterial(AutoCompleteNome.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Código inexistente !",Application.Current.MainWindow.Name,MessageBoxButton.OK,MessageBoxImage.Error);
                AutoCompleteNome.Focus();
                return;
            }

            HistoricoMovimentacao hm = new HistoricoMovimentacao();
            hm.id_materialA = id_material;
            hm.origem = TextOrigem.Text;
            hm.destino = TextDestino.Text;
            hm.quantidade = Convert.ToInt32(TextMovimento.Text);
            hm.tipoMovimentacao = TipoMovimentacao.Entrada.ToString();

            materiais.EntradaDeMateriais(hm);
        }

        private void AutoCompleteNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AutoCompleteNome.Text.Length >= 1)
            {
                AutoCompleteNome.ItemsSource = materiais.autoComplete(AutoCompleteNome.Text);
            }
        }

        private void Limpar_Click(object sender, RoutedEventArgs e)
        {
            AutoCompleteNome.Clear();
            TextDestino.Clear();
            TextOrigem.Clear();
            TextMovimento.Clear();
        }
    }
}
