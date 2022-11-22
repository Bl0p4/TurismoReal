using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealWeb.BLL
{
    public class Transporte
    {
        public decimal Id { get; set; }
        public decimal ArriendoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Pasajeros { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public decimal Distancia { get; set; }
        public Boolean IsAceptada { get; set; }
        public string Aceptada { get; set; }
        public decimal Costo { get; set; }

    }
}
