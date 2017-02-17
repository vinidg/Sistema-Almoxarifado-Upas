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
    class MateriaisA
    {
        private List<MaterialA> _materiais;

        public MateriaisA()
        {
            this._materiais = new List<MaterialA>();
        }

        public void Adicionar(MaterialA materiais)
        {
            if(this._materiais.Count(c => c.Codigo.Equals(materiais.Codigo)) > 0)
            {
                MessageBox.Show("Material ja cadastrado !");
                return;
            }
            else
            {
                this._materiais.Add(materiais);
            }
        }

        public void Remover(MaterialA materiais)
        {
            var material = this._materiais.SingleOrDefault(x => x.Id == materiais.Id);
            this._materiais.Remove(material);
            Salvar();
        }

        public List<MaterialA> listar()
        {
            return this._materiais;
        }
        public void Salvar()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<MaterialA>));
            FileStream fs = new FileStream(".//ALVES_DIAS_MATERIAIS.xml", FileMode.OpenOrCreate);
            ser.Serialize(fs, this._materiais);
            fs.Close();
        }

        public void Carregar()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<MaterialA>));
            FileStream fs = new FileStream(".//ALVES_DIAS_MATERIAIS.xml", FileMode.OpenOrCreate);
            try
            {
                this._materiais = ser.Deserialize(fs) as List<MaterialA>;
            }
            catch(InvalidOperationException ex)
            {
                ser.Serialize(fs, this._materiais);
            }
            finally
            {
                fs.Close();
            }
        }

    }
    
}
