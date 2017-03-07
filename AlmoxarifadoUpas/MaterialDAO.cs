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

        public ObservableCollection<MaterialA> Listar()
        {
            List<MaterialA> materiais = new List<MaterialA>();
            using (Entities db = new Entities())
            {
                materiais = (from MaterialA in db.MaterialA
                             select MaterialA).ToList();
            }
            return materiais;
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
                db.MaterialA.Remove(m);
                db.SaveChanges();
                MessageBox.Show("Material removido com sucesso !", Application.Current.MainWindow.Name, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void EditarMaterial(int id, string codigo, string nome, string unidade)
        {
            using (Entities db = new Entities())
            {
                MaterialA EMaterial = db.MaterialA.First(x => x.id_material == id);
                EMaterial.codigo = codigo;
                EMaterial.nome = nome;
                //EMaterial.unidade = unidade;

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
    }
}
