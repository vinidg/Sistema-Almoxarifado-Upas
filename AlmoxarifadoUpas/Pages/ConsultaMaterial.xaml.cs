using AlmoxarifadoUpas.Context;
using FirstFloor.ModernUI.Windows.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Vbe.Interop;
using System.Threading;

namespace AlmoxarifadoUpas.Pages
{
    /// <summary>
    /// Interaction logic for ConsultaMaterial.xaml
    /// </summary>
    public partial class ConsultaMaterial : UserControl, Microsoft.Vbe.Interop.Window
    {
        IMateriais materiais = new MaterialDAO();

        public VBE VBE
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Microsoft.Vbe.Interop.Windows Collection
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Caption
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Visible
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Left
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Top
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        int Microsoft.Vbe.Interop.Window.Width
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        int Microsoft.Vbe.Interop.Window.Height
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public vbext_WindowState WindowState
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public vbext_WindowType Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public LinkedWindows LinkedWindows
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Microsoft.Vbe.Interop.Window LinkedWindowFrame
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int HWnd
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void SetFocus()
        {
            throw new NotImplementedException();
        }

        public void SetKind(vbext_WindowType eKind)
        {
            throw new NotImplementedException();
        }

        public void Detach()
        {
            throw new NotImplementedException();
        }

        public void Attach(int lWindowHandle)
        {
            throw new NotImplementedException();
        }

        public ConsultaMaterial()
        {
            InitializeComponent();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tabelaMateriais.DataContext = materiais.ListarMateriais();
            tabelaHistorico.DataContext = materiais.ListarHistorico();
        }

        private void ToExcel_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog salvar = new SaveFileDialog();
            salvar.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            salvar.Title = "Salvar como Arquivo Excel";
            salvar.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";

            if (salvar.ShowDialog() != false)
            {
                try
                {

                Excel.Application excel = new Excel.Application();
                excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet1 = (Worksheet)excel.Sheets[1];

                for (int i = 1; i < tabelaMateriais.Columns.Count +1; i++) //Başlıklar için
                {
                    excel.Cells[1, i + 1].Font.Bold = true;
                    excel.Columns[i + 1].ColumnWidth = 15; //Sütun genişliği ayarı
                    excel.Cells[1, i] = tabelaMateriais.Columns[i-1].Header;
                }
                for (int i = 0; i < tabelaMateriais.Columns.Count; i++)
                { //www.ahmetcansever.com
                    for (int j = 0; j < tabelaMateriais.Items.Count; j++)
                    {
                        TextBlock b = null;
                        b = tabelaMateriais.Columns[i].GetCellContent(tabelaMateriais.Items[j]) as TextBlock;
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                        myRange.Value2 = b.Text;
                    }
                }

                excel.ActiveWorkbook.SaveCopyAs(salvar.FileName.ToString());
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
                ModernDialog.ShowMessage("Exportação para Excel foi realizada e salva na área de trabalho","",MessageBoxButton.OK);
                }
                catch (ThreadAbortException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }

        }
    }
}
