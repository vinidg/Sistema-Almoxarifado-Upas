using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoUpas
{
    public class MaterialA
    {
        private int id;
        private String codigo;
        private String material;
        private String unidade;
        private int saldo;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public String Material
        {
            get { return material; }
            set { material = value; }
        }
        public String Unidade
        {
            get { return unidade; }
            set { unidade = value; }
        }
        public int Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

    }
}
