using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;

namespace TurismoRealWeb.BLL
{
    public class Tipo_usuario
    {
        public decimal Id { get; set; }
        public string Descripcion { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<Tipo_usuario> ReadAll()
        {
            return db.TIPO_USUARIO.Select(t => new Tipo_usuario()
            {
                Id = t.ID_TIPOUSUARIO,
                Descripcion = t.DESCRIPCION
            }).ToList();
        }
    }
}
