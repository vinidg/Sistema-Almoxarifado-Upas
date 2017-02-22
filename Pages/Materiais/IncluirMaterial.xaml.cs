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
        MateriaisA materiaisA;
        public IncluirMaterial()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (MaterialContext db = new MaterialContext())
            {
                try
                {
                    MaterialA materialA = new MaterialA();

                    materialA.Codigo = TextCodigo.Text;
                    materialA.Material = TextMaterial.Text;
                    materialA.Unidade = TextUnidade.Text;

                    db.materialA.Add(materialA);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void ValidadorDeNumero(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
