 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;

namespace TurismoRealWeb.BLL
{
    public class Departamento
    {

        public decimal Id { get; set; }
        public decimal CiudadId { get; set; }
        [Required, MinLength(3, ErrorMessage = "El {0} debe tener mínimo {1} caracteres"), MaxLength(50)]
        public string Nombre { get; set; }
        [Required, MaxLength(80)]
        public string Direccion { get; set; }
        [Required, MaxLength(25)]
        public string Superficie { get; set; }
        [Required, Range(1, 5000000, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
        public decimal Precio { get; set; }        
        public Boolean IsDisp { get; set; }
        public string Disponible { get; set; }
        public string Disp { get; set; }
        public decimal NroDpto { get; set; }
        [Required, MaxLength(100)]
        public string Condicion { get; set; }

        public Ciudad Ciudad { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();


        public List<Departamento> ReadAll()
        {
            return this.db.DEPARTAMENTO.Select(d => new Departamento() {
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
                if (IsDisp == true)
                {
                    Disponible = "1";
                }
                else if(IsDisp == false)
                {
                    Disponible = "0";
                }
                //Procedimiento almacenado
                db.SP_CREA_DPTO(this.CiudadId, this.Nombre, this.Direccion, 
                                this.Superficie, this.Precio, this.Disponible, this.Condicion, this.NroDpto);
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
                if (IsDisp == true)
                {
                    Disponible = "1";
                }
                else 
                {
                    Disponible = "0";
                }

                db.SP_UPDATE_DPTO(this.Id, this.CiudadId, this.Nombre, this.Direccion,
                                this.Superficie, this.Precio, this.Disponible, this.Condicion, this.NroDpto);
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
