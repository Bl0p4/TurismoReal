using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;

namespace TurismoRealWeb.BLL
{
    public class Servicio_Contratado
    {
        public decimal ServicioId { get; set; }
        public decimal ArriendoId { get; set; }
        public decimal Costo { get; set; }
        public DateTime Fecha { get; set; }
        public bool IsRealizado { get; set; }
        public string Realizado { get; set; }
        public bool IsPostChk { get; set; }
        public string PostChk { get; set; }

        public decimal TotalCosto { get; set; }

        public Arriendo Arriendo { get; set; }

        public Servicio Servicio { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<Servicio_Contratado> ReadAll()
        {
            return this.db.SERVICIO_CONTRATADO.Select(s => new Servicio_Contratado()
            {
                ServicioId = s.ID_SERVICIO,
                ArriendoId = s.ID_ARRIENDO,
                Costo = s.COSTO,
                Fecha = (DateTime)s.FECHA_REALIZACION,
                Realizado = s.REALIZADO,
                PostChk = s.POST_CHECK_IN,

                Arriendo = new Arriendo()
                {
                    Id = s.ID_ARRIENDO,
                    ClienteId = s.ARRIENDO.ID_CLIENTE,
                    DptoId = s.ARRIENDO.ID_DPTO,
                    FecIni = s.ARRIENDO.FECHA_INICIO,
                    FecFin = s.ARRIENDO.FECHA_FIN,
                    CheckIn = s.ARRIENDO.CHECK_IN,
                    Checkout = s.ARRIENDO.CHECK_OUT,
                    Total = s.ARRIENDO.TOTAL_ARRIENDO,
                    total_serv = s.ARRIENDO.TOTAL_SERVICIOS
                },

                Servicio = new Servicio()
                {
                    Id = s.SERVICIO_EXTRA.ID_SERVICIO,
                    Descripcion = s.SERVICIO_EXTRA.DESCRIPCION,
                    Costo = s.SERVICIO_EXTRA.COSTO_ACTUAL
                }

            }).ToList();
        }

        public List<Servicio_Contratado> BuscarPorArriendo(int id)
        {
            return this.db.SERVICIO_CONTRATADO.Select(s => new Servicio_Contratado()
            {
                ServicioId = s.ID_SERVICIO,
                ArriendoId = s.ID_ARRIENDO,
                Costo = s.COSTO,
                Fecha = (DateTime)s.FECHA_REALIZACION,
                Realizado = s.REALIZADO,
                PostChk = s.POST_CHECK_IN,

                Arriendo = new Arriendo()
                {
                    Id = s.ID_ARRIENDO,
                    ClienteId = s.ARRIENDO.ID_CLIENTE,
                    DptoId = s.ARRIENDO.ID_DPTO,
                    FecIni = s.ARRIENDO.FECHA_INICIO,
                    FecFin = s.ARRIENDO.FECHA_FIN,
                    CheckIn = s.ARRIENDO.CHECK_IN,
                    Checkout = s.ARRIENDO.CHECK_OUT,
                    Total = s.ARRIENDO.TOTAL_ARRIENDO,
                    total_serv = s.ARRIENDO.TOTAL_SERVICIOS
                },

                Servicio = new Servicio()
                {
                    Id = s.SERVICIO_EXTRA.ID_SERVICIO,
                    Descripcion = s.SERVICIO_EXTRA.DESCRIPCION,
                    Costo = s.SERVICIO_EXTRA.COSTO_ACTUAL
                }

            }).Where(s => s.ArriendoId == id).ToList();
        }
              


        public bool Save()
        {
            try
            {
                
                //Procedimiento almacenado
                db.SP_MONTO_SERVICIOS(this.ArriendoId, this.Costo);
                db.SP_CONTRATA_SERVICIO(this.ArriendoId, this.ServicioId, this.Costo, this.Fecha, this.Realizado, this.PostChk);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
