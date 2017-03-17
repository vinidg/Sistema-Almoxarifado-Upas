//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlmoxarifadoUpas.Context
{
    using FirstFloor.ModernUI.Presentation;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class HistoricoMovimentacao : NotifyPropertyChanged, IDataErrorInfo
    {
        public int id_movimento { get; set; }
        private string origem;
        public string Origem { get { return this.origem; } set { if (this.origem != value) { this.origem = value; OnPropertyChanged("Origem"); }; } }
        private string destino;
        public string Destino { get { return this.destino; } set { if (this.destino != value) { this.destino = value; OnPropertyChanged("Destino"); }; } }
        private int quantidade;
        public int Quantidade { get { return this.quantidade; } set { if (this.quantidade != value) { this.quantidade = value; OnPropertyChanged("Quantidade"); }; } }
        private int id_materialA;
        public int Id_materialA { get { return this.id_materialA; } set { if (this.id_materialA != value) { this.id_materialA = value; OnPropertyChanged("Id_materialA"); }; } }
        private string tipoMovimentacao;
        public string TipoMovimentacao { get { return this.tipoMovimentacao; } set { if (this.tipoMovimentacao != value) { this.tipoMovimentacao = value; OnPropertyChanged("TipoMovimentacao"); }; } }

        public virtual MaterialA MaterialA { get; set; }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Origem")
                {
                    return string.IsNullOrEmpty(this.origem) ? "Origem requerido" : null;
                }
                if (columnName == "Destino")
                {
                    return string.IsNullOrEmpty(this.destino) ? "Destino requerido" : null;
                }
                if (columnName == "Quantidade")
                {
                    return string.IsNullOrEmpty(Convert.ToString(this.quantidade)) ? "Quantidade requerida" : null;
                }
                if (columnName == "TipoMovimentacao")
                {
                    return string.IsNullOrEmpty(this.tipoMovimentacao) ? "Tipo de movimenta��o requerida" : null;
                }
                if (columnName == "Id_MaterialA")
                {
                    return string.IsNullOrEmpty(Convert.ToString(this.id_materialA)) ? "C�digo requerida" : null;
                }
                return null;
            }
        }
    }
}
