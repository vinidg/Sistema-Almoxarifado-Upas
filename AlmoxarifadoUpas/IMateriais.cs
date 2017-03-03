﻿using AlmoxarifadoUpas.Context;
using System.Collections.Generic;

namespace AlmoxarifadoUpas
{
    interface IMateriais
    {
        void InserirMaterial(string codigo, string nome, string unidade);

        List<MaterialA> Listar();

        bool VerificarSeCodigoExiste(string codigoMaterial);

        void RemoverMaterial(MaterialA material);

        void EditarMaterial(int id, string codigo, string nome, string unidade);
    }
}