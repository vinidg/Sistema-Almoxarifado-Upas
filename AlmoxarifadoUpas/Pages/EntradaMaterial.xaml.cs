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
        private ObservableCollection<MaterialA> materiais = new ObservableCollection<MaterialA>();

        public Entrada()
        {
            InitializeComponent();
            adicionarMaterialAutoComplete();
        }

        private void adicionarMaterialAutoComplete()
        {
            IMateriais materia = new MaterialDAO();
            materiais = materia.Listar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public ObservableCollection<MaterialA> listaAutoComplete
        {
            get
            {
                return materiais;
            }
        }
    }
}
