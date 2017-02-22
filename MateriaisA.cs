using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace AlmoxarifadoUpas
{
    public class MateriaisA
    {
        public static List<MaterialA> _materiais;

        public void Adicionar(MaterialA materiais)
        {
            if(_materiais.Count(c => c.Codigo.Equals(materiais.Codigo)) > 0)
            {
                MessageBox.Show("Material ja cadastrado !");
                return;
            }
            else
            {
                _materiais.Add(materiais);
            }
        }

        public void Remover(MaterialA materiais)
        {
            var material = _materiais.SingleOrDefault(x => x.Id == materiais.Id);
            _materiais.Remove(material);
            Salvar();
        }

        public List<MaterialA> listar()
        {
            return _materiais;
        }
        public void Salvar()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<MaterialA>));
            FileStream fs = new FileStream(".//ALVES_DIAS_MATERIAIS.xml", FileMode.Truncate);
            ser.Serialize(fs, _materiais);
            fs.Close();
        }

        public void Carregar()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<MaterialA>));
            FileStream fs = new FileStream(".//ALVES_DIAS_MATERIAIS.xml", FileMode.OpenOrCreate);
            try
            {
                _materiais = ser.Deserialize(fs) as List<MaterialA>;
            }
            catch(InvalidOperationException ex)
            {
                ser.Serialize(fs, _materiais);
            }
            finally
            {
                fs.Close();
            }
        }

    }
    
}
