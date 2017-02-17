using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoUpas
{
   public enum Movimento { SAIDA, ENTRADA };
   public class HistoricoMovimentacao
    {
        private int id;
        private String origem;
        private String destino;
        private int quantidade;
        private Movimento tipoMovimentacao;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Origem
        {
            get { return origem; }
            set { origem = value; }
        }
        public String Destino
        {
            get { return destino; }
            set { destino = value; }
        }
        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public Movimento TipoMovimentacao
        {
            get { return tipoMovimentacao; }
            set { tipoMovimentacao = value; }
        }
    }
}
