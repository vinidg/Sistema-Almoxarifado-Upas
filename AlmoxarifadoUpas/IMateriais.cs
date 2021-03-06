﻿using AlmoxarifadoUpas.Context;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AlmoxarifadoUpas
{
    interface IMateriais
    {
        void InserirMaterial(MaterialA material);

        List<MaterialA> ListarMateriais();

        List<MaterialA> ListarMateriaisDesativados();

        List<HistoricoMovimentacao> ListarHistorico();
        
        bool VerificarSeCodigoExiste(string codigoMaterial);

        void RemoverMaterial(MaterialA material);

        void LiberarMaterial(MaterialA material);

        void EditarMaterial(int id, string codigo, string nome, string unidade);

        void EntradaDeMateriais(HistoricoMovimentacao historico);

        void SaidaDeMateriais(HistoricoMovimentacao historico);

        int PegarIdMaterial(string codigo);

        List<MaterialA> AutoComplete(string AutoCompleteNome);
    }
}