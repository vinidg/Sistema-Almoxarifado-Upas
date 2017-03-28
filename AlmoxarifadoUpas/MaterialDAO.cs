using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AlmoxarifadoUpas.Context;
using System.Collections.ObjectModel;
using FirstFloor.ModernUI.Windows.Controls;
using System.Data.Entity;

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
                    hm.Id_materialA = material.Id_material;
                    hm.Destino = "";
                    hm.Origem = "";
                    hm.Quantidade = 0;
                    hm.TipoMovimentacao = TipoMovimentacao.Inserir_material.ToString();

                    db.HistoricoMovimentacao.Add(hm);
                    db.SaveChanges();

                    ModernDialog.ShowMessage("Material cadastrado com sucesso !", Application.Current.MainWindow.Name, MessageBoxButton.OK);
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
                             where MaterialA.Desativado == false
                             select MaterialA).ToList();
            }
            return materiais;
        }

        public List<MaterialA> ListarMateriaisDesativados()
        {
            List<MaterialA> materiais = new List<MaterialA>();
            using (Entities db = new Entities())
            {
                materiais = (from MaterialA in db.MaterialA
                             where MaterialA.Desativado == true
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

        public List<MaterialA> AutoComplete(string AutoCompleteNome)
        {
            ConsultaMaterialEntradaSaida cme = new ConsultaMaterialEntradaSaida();
            List<MaterialA> listaMaterial = cme.materiais;

            using (Entities db = new Entities())
            {
                var con = (from materia in db.MaterialA where materia.Desativado == false && materia.Codigo.Contains(AutoCompleteNome.ToLower()) || materia.Nome.Contains(AutoCompleteNome.ToLower()) select materia).ToList();
                listaMaterial = con;
            }

            return listaMaterial;
        }

        public bool VerificarSeCodigoExiste(string codigoMaterial)
        {
            using (Entities db = new Entities())
            {
                var consulta = (from materia in db.MaterialA
                                where materia.Codigo == codigoMaterial
                                select materia.Codigo).Count();
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
            if (Environment.UserName.Equals("454604385"))
            {
                var resultado = ModernDialog.ShowMessage("Remover permanente ?", "Admin", MessageBoxButton.YesNo);

                if (resultado == MessageBoxResult.Yes)
                {
                    using (Entities db = new Entities())
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.MaterialA.Attach(material);
                        db.Entry(material).State = EntityState.Deleted;
                        db.SaveChanges();
                        db.Configuration.ValidateOnSaveEnabled = true;
                        ModernDialog.ShowMessage("Material Removido !", Application.Current.MainWindow.Name, MessageBoxButton.OK);
                    }
                }
                else if (resultado == MessageBoxResult.No)
                {
                    Remover(material);
                }
            }
            else
            {
                var resultado = ModernDialog.ShowMessage("Remover material ?", "Admin", MessageBoxButton.YesNo);

                if (resultado == MessageBoxResult.Yes)
                {
                    Remover(material);
                }
            }

        }

        private void Remover(MaterialA material)
        {
            using (Entities db = new Entities())
            {

                MaterialA m = db.MaterialA.First(x => x.Id_material == material.Id_material);
                m.Desativado = true;

                HistoricoMovimentacao hm = new HistoricoMovimentacao();
                hm.Id_materialA = material.Id_material;
                hm.Destino = "";
                hm.Origem = "";
                hm.Quantidade = 0;
                hm.TipoMovimentacao = TipoMovimentacao.Remover_material.ToString();

                db.SaveChanges();
                ModernDialog.ShowMessage("Material removido com sucesso !", Application.Current.MainWindow.Name, MessageBoxButton.OK);

            }
        }

        private void Liberar(MaterialA material)
        {
            using (Entities db = new Entities())
            {

                MaterialA m = db.MaterialA.First(x => x.Id_material == material.Id_material);
                m.Desativado = false;

                HistoricoMovimentacao hm = new HistoricoMovimentacao();
                hm.Id_materialA = material.Id_material;
                hm.Destino = "";
                hm.Origem = "";
                hm.Quantidade = 0;
                hm.TipoMovimentacao = TipoMovimentacao.Liberar_material.ToString();

                db.SaveChanges();
                ModernDialog.ShowMessage("Material liberado com sucesso !", Application.Current.MainWindow.Name, MessageBoxButton.OK);

            }
        }

        public void LiberarMaterial(MaterialA material)
        {
            var resultado = ModernDialog.ShowMessage("Liberar permanente ?", "Admin", MessageBoxButton.YesNo);

            if (resultado == MessageBoxResult.Yes)
            {
                Liberar(material);
            }

        }

        public void EditarMaterial(int id, string codigo, string nome, string unidade)
        {
            using (Entities db = new Entities())
            {
                MaterialA material = db.MaterialA.First(x => x.Id_material == id);
                material.Codigo = codigo;
                material.Nome = nome;
                material.Unidade = unidade;

                HistoricoMovimentacao hm = new HistoricoMovimentacao();
                hm.Id_materialA = material.Id_material;
                hm.Destino = "";
                hm.Origem = "";
                hm.Quantidade = 0;
                hm.TipoMovimentacao = TipoMovimentacao.alterar_material.ToString();

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
                    MaterialA material = db.MaterialA.First(m => m.Id_material == historico.Id_materialA);
                    material.Saldo += historico.Quantidade;

                    db.HistoricoMovimentacao.Add(historico);

                    db.SaveChanges();

                    ModernDialog.ShowMessage(historico.Quantidade + " itens foram adicionados para o material " + material.Nome + " !", Application.Current.MainWindow.Name, MessageBoxButton.OK);
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
                    MaterialA material = db.MaterialA.First(m => m.Id_material == historico.Id_materialA);

                    material.Saldo -= historico.Quantidade;
                    db.HistoricoMovimentacao.Add(historico);

                    db.SaveChanges();

                    ModernDialog.ShowMessage(historico.Quantidade + " itens foram retirados do material " + material.Nome + " !", Application.Current.MainWindow.Name, MessageBoxButton.OK);
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
            int id_material = 0;
            using (Entities db = new Entities())
            {
                var id = (from m in db.MaterialA
                          where m.Codigo == codigo
                          && m.Desativado == false
                          select m.Id_material).First();
                id_material = Convert.ToInt32(id);
            }
            return id_material;
        }


    }
}
