using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;

namespace TurismoRealWeb.BLL
{
    public class Reserva
    {
        public decimal Id { get; set; }
        public string NomPersona { get; set; }
        public DateTime Fech { get; set; }
        public decimal ArriendoId { get; set; }
        public decimal Acomp { get; set; }
        public decimal Valor { get; set; }
        public Boolean IsVig { get; set; }
        public string Vigente { get; set; }


        TurismoRealEntities db = new TurismoRealEntities();


        public List<Departamento> ReadAll()
        {
            return this.db.DEPARTAMENTO.Select(d => new Departamento()
            {
                Id = d.ID_DPTO,
                CiudadId = d.ID_CIUDAD,
                Nombre = d.NOMBRE,
                Direccion = d.DIRECCION,
                Superficie = d.SUPERFICIE_DPTO,
                Precio = d.PRECIO_DPTO,
                Disponible = d.DISPONIBLE,
                Condicion = d.CONDICION,
                NroDpto = d.NRO_DPTO,
                Ciudad = new Ciudad()
                {
                    Id = d.ID_CIUDAD,
                    Nombre = d.CIUDAD.NOMBRE
                }
            }).ToList();
        }

        public bool Save()
        {
            try
            {
                if (IsVig == true)
                {
                    Vigente = "1";
                }
                else if (IsVig == false)
                {
                    Vigente = "0";
                }
                //Procedimiento almacenado
                //db.SP_CREATE_RESERVA();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Departamento Find(int id)
        {
            return this.db.DEPARTAMENTO.Select(d => new Departamento()
            {
                Id = d.ID_DPTO,
                CiudadId = d.ID_CIUDAD,
                Nombre = d.NOMBRE,
                Direccion = d.DIRECCION,
                Superficie = d.SUPERFICIE_DPTO,
                Precio = d.PRECIO_DPTO,
                Disponible = d.DISPONIBLE,
                Condicion = d.CONDICION,
                NroDpto = d.NRO_DPTO,
                Ciudad = new Ciudad()
                {
                    Id = d.ID_CIUDAD,
                    Nombre = d.CIUDAD.NOMBRE
                }


            }).Where(d => d.Id == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                if (IsVig == true)
                {
                    Vigente = "1";
                }
                else
                {
                    Vigente = "0";
                }

                //db.SP_UPDATE_RESERVA();
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
                db.SP_DELETE_DPTO(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
