using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AlmoxarifadoUpas.Context;

namespace AlmoxarifadoUpas
{
    class MaterialDAO : IMateriais
    {
        public void InserirMaterial(string codigo, string material, string unidade)
        {
            using (ALMOXARIFADOUPASEntities db = new ALMOXARIFADOUPASEntities())
            {
                try
                {              
                        MaterialA materialA = new MaterialA();

                        materialA.codigo = codigo;
                        materialA.material = material;
                        materialA.unidade = unidade;
                        db.MaterialA.Add(materialA);
                        db.SaveChanges();

                        MessageBox.Show("Material cadastrado com sucesso !", Application.Current.MainWindow.Name,MessageBoxButton.OK, MessageBoxImage.Information);                      
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        public List<MaterialA> Listar()
        {
            List<MaterialA> materiais = new List<MaterialA>();
            using (ALMOXARIFADOUPASEntities db = new ALMOXARIFADOUPASEntities())
            {
                materiais = (from MaterialA in db.MaterialA
                             select MaterialA).ToList();
            }
            return materiais;
        }

        public bool VerificarSeCodigoExiste(string codigoMaterial)
        {
            using (ALMOXARIFADOUPASEntities db = new ALMOXARIFADOUPASEntities())
            {
                var consulta = (from materialA in db.MaterialA
                                where materialA.codigo == codigoMaterial
                                select materialA.codigo).Count();
                if (consulta >= 1)
                {
                    return false;
                }else
                {
                    return true;
                }
            }
        }

        public void RemoverMaterial(MaterialA material)
        {
            using (ALMOXARIFADOUPASEntities db = new ALMOXARIFADOUPASEntities())
            {
                MaterialA m = db.MaterialA.First(x => x.id_material == material.id_material);
                db.MaterialA.Remove(m);
                db.SaveChanges();
                MessageBox.Show("Material removido com sucesso !", Application.Current.MainWindow.Name, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void EditarMaterial(MaterialA material)
        {
            using (ALMOXARIFADOUPASEntities db = new ALMOXARIFADOUPASEntities())
            {
                MaterialA EMaterial = db.MaterialA.First(x => x.id_material == material.id_material);
                EMaterial.codigo = material.codigo;
                EMaterial.material = material.material;
                EMaterial.unidade = material.unidade;

                db.SaveChanges();
            }
        }
    }
}
