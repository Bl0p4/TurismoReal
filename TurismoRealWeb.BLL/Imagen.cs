using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.ComponentModel;
using System.Web;

namespace TurismoRealWeb.BLL
{
    public class Imagen
    {
        public decimal Id { get; set; }
        public decimal DptoId { get; set; }
        public byte[] Image { get; set; }


        public Departamento departamento { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<Imagen> ReadAll(decimal id)
        {
            return this.db.IMAGEN.Select(i => new Imagen()
            {
                Id = i.ID_IMAGEN,
                DptoId = i.ID_DPTO,
                Image = i.FOTO,

                departamento = new Departamento()
                {
                    Id = i.ID_DPTO,
                    CiudadId = i.DEPARTAMENTO.ID_CIUDAD,
                    Nombre = i.DEPARTAMENTO.NOMBRE,
                    Direccion = i.DEPARTAMENTO.DIRECCION,
                    Superficie = i.DEPARTAMENTO.SUPERFICIE_DPTO,
                    Precio = i.DEPARTAMENTO.PRECIO_DPTO,
                    Disponible = i.DEPARTAMENTO.DISPONIBLE,
                    Condicion = i.DEPARTAMENTO.CONDICION,
                    NumDpto = i.DEPARTAMENTO.NRO_DPTO,
                }
            }).Where(i => i.DptoId == id).ToList();
        }


        




    }
}
