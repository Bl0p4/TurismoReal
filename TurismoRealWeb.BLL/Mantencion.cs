using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;

namespace TurismoRealWeb.BLL
{
    public class Mantencion
    {
        public decimal Id { get; set; }
        public decimal DptoId { get; set; }        
        public DateTime Fech_ini { get; set; }
        public DateTime Fech_term { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }

        public Departamento Dpto { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<Mantencion> ReadAll()
        {
            return this.db.MANTENCION.Select(m => new Mantencion()
            {
                Id = m.ID_MANTENCION,
                DptoId = m.ID_DPTO,
                Fech_ini = m.FECHA_INICIO,
                Fech_term = m.FECHA_FIN,
                Descripcion = m.DESCRIPCION,
                Costo = m.COSTO,

                Dpto = new Departamento()
                {
                    Id = m.ID_DPTO,
                    CiudadId = m.DEPARTAMENTO.ID_CIUDAD,
                    Nombre = m.DEPARTAMENTO.NOMBRE,
                    Direccion = m.DEPARTAMENTO.DIRECCION,
                    Superficie = m.DEPARTAMENTO.SUPERFICIE_DPTO,
                    Precio = m.DEPARTAMENTO.PRECIO_DPTO,
                    Disponible = m.DEPARTAMENTO.DISPONIBLE,
                    Condicion = m.DEPARTAMENTO.CONDICION,
                    NroDpto = m.DEPARTAMENTO.NRO_DPTO
                }

            }).ToList();
        }

        public bool Save()
        {
            try
            {
                //Procedimiento almacenado
                db.SP_CREA_MANTEN(this.DptoId, this.Fech_ini, this.Fech_term,
                                      this.Descripcion, this.Costo);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Mantencion Find(int id)
        {
            return this.db.MANTENCION.Select(m => new Mantencion()
            {
                Id = m.ID_MANTENCION,
                DptoId = m.ID_DPTO,
                Fech_ini = m.FECHA_INICIO,
                Fech_term = m.FECHA_FIN,
                Descripcion = m.DESCRIPCION,
                Costo = m.COSTO,

                Dpto = new Departamento()
                {
                    Id = m.ID_DPTO,
                    CiudadId = m.DEPARTAMENTO.ID_CIUDAD,
                    Nombre = m.DEPARTAMENTO.NOMBRE,
                    Direccion = m.DEPARTAMENTO.DIRECCION,
                    Superficie = m.DEPARTAMENTO.SUPERFICIE_DPTO,
                    Precio = m.DEPARTAMENTO.PRECIO_DPTO,
                    Disponible = m.DEPARTAMENTO.DISPONIBLE,
                    Condicion = m.DEPARTAMENTO.CONDICION,
                    NroDpto = m.DEPARTAMENTO.NRO_DPTO
                }


            }).Where(i => i.Id == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_MANTEN(this.Id, this.DptoId, this.Fech_ini, this.Fech_term,
                                      this.Descripcion, this.Costo);
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
                db.SP_DELETE_MANTEN(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}