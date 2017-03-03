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
        IMateriais material;
        public RemoverMaterial()
        {
            InitializeComponent();
            tabela.DataContext = material.Listar();
        }

        private void Remover_Click(object sender, RoutedEventArgs e)
        {
            if(tabela.SelectedItems[0].GetType().Equals(typeof(AlmoxarifadoUpas.Context.MaterialA)))
            {
                MaterialA row = (MaterialA)tabela.SelectedItems[0];
                material.RemoverMaterial(row);
            }
                
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            tabela.DataContext = material.Listar();
        }
    }
}
