using AlmoxarifadoUpas.Context;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HistoricoMovimentacao hm = new HistoricoMovimentacao();
            hm.id_materialA = Convert.ToInt32(id_material.Text);
            hm.origem = TextOrigem.Text;
            hm.destino = TextDestino.Text;
            hm.quantidade = Convert.ToInt32(TextMovimento.Text);
            hm.tipoMovimentacao = "ENTRADA";

            materiais.EntradaDeMateriais(hm);
        }

        private void AutoCompleteNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AutoCompleteNome.Text.Length == 1)
            {
                ConsultaMaterialEntradaSaida cme = new ConsultaMaterialEntradaSaida();
                List<MaterialA> listaMaterial = cme.materiais;

                using (Entities db = new Entities())
                {
                    var con = (from materia in db.MaterialA where materia.codigo.Contains(AutoCompleteNome.Text.ToLower()) || materia.nome.Contains(AutoCompleteNome.Text.ToLower()) select materia).ToList();
                    listaMaterial = con;
                }
                AutoCompleteNome.ItemsSource = listaMaterial;
            }

        }
    }
}
