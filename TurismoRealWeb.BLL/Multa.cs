using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealWeb.BLL
{
    public class Multa
    {
        public decimal Id { get; set; }
        public decimal ArriendoId { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
    }
}
