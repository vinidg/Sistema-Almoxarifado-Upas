using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoUpas.Context
{
    public class MaterialContext : DbContext
    {
        public MaterialContext() : base("name=DAHUEEntities") { }
        public DbSet<MaterialA> materialA {get; set;}
        public DbSet<HistoricoMovimentacao> historicoMovimentacao { get; set; }
    }
}
