using AlmoxarifadoUpas.Context;
using System.Collections.Generic;

namespace AlmoxarifadoUpas
{
    interface IMateriais
    {
        void InserirMaterial(string codigo, string material, string unidade);

        List<MaterialA> Listar();

        bool VerificarSeCodigoExiste(string codigoMaterial);

        void RemoverMaterial(MaterialA material);

        void EditarMaterial(MaterialA material);
    }
}