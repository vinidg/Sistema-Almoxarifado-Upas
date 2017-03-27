using AlmoxarifadoUpas.Context;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoUpas
{
    class ConsultaMaterialEntradaSaida
    {
        public List<MaterialA> materiais { get; set; }

        public ConsultaMaterialEntradaSaida()
        {
            adicionarMaterialAutoComplete();
        }

        public void adicionarMaterialAutoComplete()
        {
            using (Entities db = new Entities())
            {
                var mate = from material in db.MaterialA
                           select material;

                materiais = mate.ToList();
            }
        }


    }
}
