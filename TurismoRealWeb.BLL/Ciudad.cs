using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;

namespace TurismoRealWeb.BLL
{
    public class Ciudad
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<Ciudad> ReadAll()
        {
            return db.CIUDAD.Select(c => new Ciudad()
            {
                Id = c.ID_CIUDAD,
                Nombre = c.NOMBRE 
            }).ToList();
        }
    }
}
