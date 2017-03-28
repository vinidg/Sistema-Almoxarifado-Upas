using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using AlmoxarifadoUpas.Context;

namespace AlmoxarifadoUpas.Pages.Materiais
{
    /// <summary>
    /// Interaction logic for RemoverMaterial.xaml
    /// </summary>
    public partial class RemoverMaterial : UserControl
    {
        IMateriais materiais = new MaterialDAO();
        public RemoverMaterial()
        {
            InitializeComponent();
        }

        private void Remover_Click(object sender, RoutedEventArgs e)
        {
            MaterialA row = (MaterialA)tabelaRemover.SelectedItems[0];
            materiais.RemoverMaterial(row);
            tabelaRemover.DataContext = materiais.ListarMateriais();
            tabelaRemovidos.DataContext = materiais.ListarMateriaisDesativados();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tabelaRemover.DataContext = materiais.ListarMateriais();
            tabelaRemovidos.DataContext = materiais.ListarMateriaisDesativados();
        }

        private void Liberar_Click(object sender, RoutedEventArgs e)
        {
            MaterialA row = (MaterialA)tabelaRemovidos.SelectedItems[0];
            materiais.LiberarMaterial(row);
            tabelaRemover.DataContext = materiais.ListarMateriais();
            tabelaRemovidos.DataContext = materiais.ListarMateriaisDesativados();
        }
    }
}
