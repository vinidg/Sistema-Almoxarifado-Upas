using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace AlmoxarifadoUpas.Pages.Materiais
{
    /// <summary>
    /// Interaction logic for RemoverMaterial.xaml
    /// </summary>
    public partial class RemoverMaterial : UserControl
    {
        MateriaisA materiaisA;
        public RemoverMaterial()
        {
            InitializeComponent();
            tabela.DataContext = materiaisA.listar();
        }

        private void Remover_Click(object sender, RoutedEventArgs e)
        {
            if(tabela.SelectedItems[0].GetType().Equals(typeof(AlmoxarifadoUpas.MaterialA)))
            {
                MaterialA row = (MaterialA)tabela.SelectedItems[0];
                materiaisA.Remover(row);
            }
                
        }

    }
}
