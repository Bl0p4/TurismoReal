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
        public DateTime FechComp { get; set; }
        public Boolean IsDisp { get; set; }

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
                FechComp = i.FECHA_COMPRA,
                
                Dpto = new Departamento()
                {
                    Id = i.ID_DPTO,
                    CiudadId = i.DEPARTAMENTO.ID_CIUDAD,
                    Nombre = i.DEPARTAMENTO.NOMBRE,
                    Direccion = i.DEPARTAMENTO.DIRECCION,
                    Superficie = i.DEPARTAMENTO.SUPERFICIE_DPTO,
                    Precio = i.DEPARTAMENTO.PRECIO_DPTO,
                    Disponible = i.DEPARTAMENTO.DISPONIBLE,
                    Condicion = i.DEPARTAMENTO.CONDICION,
                    NumDpto = i.DEPARTAMENTO.NRO_DPTO
                }
            }).ToList();
        }

        public bool Save()
        {
            try
            {
                if (IsDisp == true)
                {
                    Disponible = "1";
                }
                else if (IsDisp == false)
                {
                    Disponible = "0";
                }
                FechComp = Convert.ToDateTime(FechComp);
                //Procedimiento almacenado
                db.SP_CREA_ITEM(this.DptoId, this.Item, this.Valor, this.Disponible, this.FechComp);
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
                FechComp = i.FECHA_COMPRA,
                Dpto = new Departamento()
                {
                    Id = i.ID_DPTO,
                    CiudadId = i.DEPARTAMENTO.ID_CIUDAD,
                    Nombre = i.DEPARTAMENTO.NOMBRE,
                    Direccion = i.DEPARTAMENTO.DIRECCION,
                    Superficie = i.DEPARTAMENTO.SUPERFICIE_DPTO,
                    Precio = i.DEPARTAMENTO.PRECIO_DPTO,
                    Disponible = i.DEPARTAMENTO.DISPONIBLE,
                    Condicion = i.DEPARTAMENTO.CONDICION
                }


            }).Where(i => i.Id == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                if (IsDisp == true)
                {
                    Disponible = "1";
                }
                else if (IsDisp == false)
                {
                    Disponible = "0";
                }
                FechComp = Convert.ToDateTime(FechComp);
                db.SP_UPDATE_ITEM(this.Id, this.DptoId, this.Item, this.Valor, this.Disponible, this.FechComp);                
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
