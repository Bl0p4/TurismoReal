using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;

namespace TurismoRealWeb.BLL
{
    public class Acompanante
    {
        public decimal Id { get; set; }
        public decimal Rut { get; set; }
        public string Dv { get; set; }
        public string Nombre { get; set; }
        public DateTime FecNac { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<Acompanante> ReadAll()
        {
            return db.AMIGO.Select(a => new Acompanante()
            {
                Id = a.ID_AMIGO,
                Rut = a.RUT,
                Dv = a.DV,
                Nombre = a.NOMBRE_COMPLETO,
                FecNac = a.FEC_NAC,
                Telefono = a.TELEFONO,
                Email = a.EMAIL
            }).ToList();
        }



    }
}
