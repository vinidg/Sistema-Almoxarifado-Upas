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
        MateriaisA materiais = new MateriaisA();
        public RemoverMaterial()
        {
            InitializeComponent();
            tabela.DataContext = materiais.listar();
        }

        private void Remover_Click(object sender, RoutedEventArgs e)
        {
            if(tabela.SelectedItems[0].GetType().Equals(typeof(AlmoxarifadoUpas.MaterialA)))
            {
                MaterialA row = (MaterialA)tabela.SelectedItems[0];
                materiais.Remover(row);
            }
                
        }

        private void UserControl_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            tabela.DataContext = materiais.listar();
        }

    }
}
