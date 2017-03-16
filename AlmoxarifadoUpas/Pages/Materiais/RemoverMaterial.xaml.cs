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
            MaterialA row = (MaterialA)tabela.SelectedItems[0];
            materiais.RemoverMaterial(row);
            tabela.DataContext = materiais.ListarMateriais();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tabela.DataContext = materiais.ListarMateriais();
        }
    }
}
