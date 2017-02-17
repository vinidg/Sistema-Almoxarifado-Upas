using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Xml;
using System.Data;
using System;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Linq;

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
            MaterialA material = new MaterialA()
            {
                Id = gerarId(), 
                Codigo = TextCodigo.Text,
                Unidade = TextUnidade.Text,
                Material = TextMaterial.Text,
                Saldo = Convert.ToInt32(TextSaldo.Text)
            };
            materiaisA.Adicionar(material);
            materiaisA.Salvar();
            materiaisA.listar();
        }

        private void ValidadorDeNumero(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public int gerarId()
        {
            int id;
            var ultimoItem = materiaisA.listar().LastOrDefault();
            
            if(ultimoItem == null)
            {
                id = 1;
            }
            else
            {
                id = ultimoItem.Id + 1;
            }

            return id;            
        }
    }
}
