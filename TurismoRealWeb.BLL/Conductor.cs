using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealWeb.BLL
{
    public class Conductor
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Licencia { get; set; }
        public DateTime FecNac { get; set; }
    }
}
