using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AlmoxarifadoUpas.Context;
using System.Collections.ObjectModel;

namespace AlmoxarifadoUpas
{
    class MaterialDAO : IMateriais
    {
        public void InserirMaterial(MaterialA material)
        {
            using (Entities db = new Entities())
            {
                try
                {
                    db.MaterialA.Add(material);

                    HistoricoMovimentacao hm = new HistoricoMovimentacao();
                    hm.id_materialA = material.id_material;
                    hm.destino = "";
                    hm.origem = "";
                    hm.quantidade = 0;
                    hm.tipoMovimentacao = TipoMovimentacao.Inserir_material.ToString();

                    db.HistoricoMovimentacao.Add(hm);
                    db.SaveChanges();

                    MessageBox.Show("Material cadastrado com sucesso !", Application.Current.MainWindow.Name, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        public List<MaterialA> ListarMateriais()
        {
            List<MaterialA> materiais = new List<MaterialA>();
            using (Entities db = new Entities())
            {
                materiais = (from MaterialA in db.MaterialA
                             select MaterialA).ToList();
            }
            return materiais;
        }

        public List<HistoricoMovimentacao> ListarHistorico()
        {
            List<HistoricoMovimentacao> historico = new List<HistoricoMovimentacao>();
            using (Entities db = new Entities())
            {
                historico = (from h in db.HistoricoMovimentacao
                             select h).ToList();
            }
            return historico;
        }

        public bool VerificarSeCodigoExiste(string codigoMaterial)
        {
            using (Entities db = new Entities())
            {
                var consulta = (from materia in db.MaterialA
                                where materia.codigo == codigoMaterial
                                select materia.codigo).Count();
                if (consulta >= 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void RemoverMaterial(MaterialA material)
        {
            using (Entities db = new Entities())
            {
                MaterialA m = db.MaterialA.First(x => x.id_material == material.id_material);
                m.desativado = true;

                HistoricoMovimentacao hm = new HistoricoMovimentacao();
                hm.id_materialA = material.id_material;
                hm.destino = "";
                hm.origem = "";
                hm.quantidade = 0;
                hm.tipoMovimentacao = TipoMovimentacao.Remover_material.ToString();

                db.SaveChanges();
                MessageBox.Show("Material removido com sucesso !", Application.Current.MainWindow.Name, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void EditarMaterial(int id, string codigo, string nome, string unidade)
        {
            using (Entities db = new Entities())
            {
                MaterialA material = db.MaterialA.First(x => x.id_material == id);
                material.codigo = codigo;
                material.nome = nome;
                material.unidade = unidade;

                HistoricoMovimentacao hm = new HistoricoMovimentacao();
                hm.id_materialA = material.id_material;
                hm.destino = "";
                hm.origem = "";
                hm.quantidade = 0;
                hm.tipoMovimentacao = TipoMovimentacao.alterar_material.ToString();

                db.SaveChanges();
                MessageBox.Show("Material alterado com sucesso !", Application.Current.MainWindow.Name, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void EntradaDeMateriais(HistoricoMovimentacao historico)
        {
            using (Entities db = new Entities())
            {
                try
                {
                    MaterialA material = db.MaterialA.First(m => m.id_material == historico.id_materialA);
                    material.saldo += historico.quantidade;

                    db.MaterialA.Add(material);
                    db.HistoricoMovimentacao.Add(historico);

                    db.SaveChanges();

                    MessageBox.Show(historico.quantidade + " itens foram adicionados para o material " + material.nome +" !",Application.Current.MainWindow.Name,MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        public void SaidaDeMateriais(HistoricoMovimentacao historico)
        {
            using (Entities db = new Entities())
            {
                try
                {
                    MaterialA material = db.MaterialA.First(m => m.id_material == historico.id_materialA);
                    material.saldo -= historico.quantidade;

                    db.MaterialA.Add(material);
                    db.HistoricoMovimentacao.Add(historico);

                    db.SaveChanges();

                    MessageBox.Show(historico.quantidade + " itens foram retirados do material " + material.nome + " !", Application.Current.MainWindow.Name, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        public int PegarIdMaterial(string codigo)
        {
            int id_material=0;
            using (Entities db = new Entities())
            {
                var id = (from m in db.MaterialA
                         where m.codigo == codigo
                         select m.id_material).First();
                id_material = Convert.ToInt32(id);
            }
            return id_material;
        }

        public List<MaterialA> autoComplete(string AutoCompleteNome)
       {
            ConsultaMaterialEntradaSaida cme = new ConsultaMaterialEntradaSaida();
            List<MaterialA> listaMaterial = cme.materiais;

            using (Entities db = new Entities())
            {
                var con = (from materia in db.MaterialA where materia.codigo.Contains(AutoCompleteNome.ToLower()) || materia.nome.Contains(AutoCompleteNome.ToLower()) select materia).ToList();
                listaMaterial = con;
            }

            return listaMaterial;
        }

    }
}
