using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;

namespace TurismoRealWeb.BLL
{
    public class Servicio
    {
        public decimal Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<Servicio> ReadAll()
        {
            return db.SERVICIO_EXTRA.Select(s => new Servicio()
            {
                Id = s.ID_SERVICIO,
                Descripcion = s.DESCRIPCION,
                Costo = s.COSTO_ACTUAL
            }).ToList();
        }

        public Servicio Find(decimal id)
        {
            return db.SERVICIO_EXTRA.Select(s => new Servicio()
            {
                Id = s.ID_SERVICIO,
                Descripcion = s.DESCRIPCION,
                Costo = s.COSTO_ACTUAL
            }).Where(s => s.Id == id).FirstOrDefault();
        }

        public Servicio GetCosto(decimal id)
        {
            return db.SERVICIO_EXTRA.Select(s => new Servicio()
            {
                Costo = s.COSTO_ACTUAL
            }).Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
