using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;

namespace TurismoRealWeb.BLL
{
    public class Inventario
    {
        public decimal Id { get; set; }
        public decimal DptoId { get; set; }
        public string Item { get; set; }
        public decimal Valor { get; set; }
        public string Disponible { get; set; }

        public Departamento Dpto { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<Inventario> ReadAll()
        {
            return this.db.INVENTARIO.Select(i => new Inventario()
            {
                Id = i.ID_INVENTARIO,
                DptoId = i.ID_DPTO,
                Item = i.NOMBRE,
                Valor = i.VALOR,
                Disponible = i.DISPONIBLE,
                
                Dpto = new Departamento()
                {
                    Id = i.ID_DPTO,
                    CiudadId = i.DEPARTAMENTOS.ID_CIUDAD,
                    Nombre = i.DEPARTAMENTOS.NOMBRE,
                    Direccion = i.DEPARTAMENTOS.DIRECCION,
                    Superficie = i.DEPARTAMENTOS.SUPERFICIE_DPTO,
                    Precio = i.DEPARTAMENTOS.PRECIO_DPTO,
                    Disponible = i.DEPARTAMENTOS.DISPONIBLE,
                    Condicion = i.DEPARTAMENTOS.CONDICION                    
                }


            }).ToList();
        }

        public bool Save()
        {
            try
            {
                //Procedimiento almacenado
                db.SP_CREA_ITEM(this.DptoId, this.Item, this.Valor);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Inventario Find(int id)
        {
            return this.db.INVENTARIO.Select(i => new Inventario()
            {
                Id = i.ID_INVENTARIO,
                DptoId = i.ID_DPTO,
                Item = i.NOMBRE,
                Valor = i.VALOR,
                Disponible = i.DISPONIBLE,
                Dpto = new Departamento()
                {
                    Id = i.ID_DPTO,
                    CiudadId = i.DEPARTAMENTOS.ID_CIUDAD,
                    Nombre = i.DEPARTAMENTOS.NOMBRE,
                    Direccion = i.DEPARTAMENTOS.DIRECCION,
                    Superficie = i.DEPARTAMENTOS.SUPERFICIE_DPTO,
                    Precio = i.DEPARTAMENTOS.PRECIO_DPTO,
                    Disponible = i.DEPARTAMENTOS.DISPONIBLE,
                    Condicion = i.DEPARTAMENTOS.CONDICION
                }


            }).Where(i => i.Id == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_ITEM(this.Id, this.DptoId, this.Item, this.Valor, this.Disponible);                
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                db.SP_DELETE_ITEM(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
