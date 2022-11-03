using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;

namespace TurismoRealWeb.BLL
{
    public class Reserva
    {
        public decimal Id { get; set; }
        public string NomPersona { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fech { get; set; }
        public decimal ArriendoId { get; set; }
        public decimal Acomp { get; set; }
        public decimal Valor { get; set; }
        public Boolean IsVig { get; set; }
        public string Vigente { get; set; }

        public Arriendo Arriendo { get; set; }


        TurismoRealEntities db = new TurismoRealEntities();


        public List<Reserva> ReadAll()
        {
            return this.db.RESERVA.Select(a => new Reserva()
            {
                Id = a.ID_RESERVA,
                NomPersona = a.NOM_PERSONA,
                Fech = a.FECH_ARRIENDO,
                ArriendoId = a.ID_ARRIENDO,
                Acomp = a.ACOMPANANTES,
                Valor = a.COSTO_RESERVA,
                Vigente = a.VIGENTE,

                Arriendo = new Arriendo() 
                {
                    Id = a.ID_ARRIENDO,
                    ClienteId = a.ARRIENDO.ID_CLIENTE,
                    DptoId = a.ARRIENDO.ID_DPTO,
                    FecReserva = a.ARRIENDO.FECHA_RESERVA,
                    ValReserva = a.ARRIENDO.VALOR_RESERVA,
                    ResPago = a.ARRIENDO.RESERVA_PAGADA,
                    FecIni = a.ARRIENDO.FECHA_INICIO,
                    FecFin = a.ARRIENDO.FECHA_FIN,
                    CheckIn = a.ARRIENDO.CHECK_IN,
                    Checkout = a.ARRIENDO.CHECK_OUT,
                    Total = a.ARRIENDO.TOTAL_ARRIENDO
                }

            }).ToList();
        }

        public bool Save()
        {
            try
            {
                if (IsVig == true)
                {
                    Vigente = "1";
                }
                else if (IsVig == false)
                {
                    Vigente = "0";
                }
                //Procedimiento almacenado
                db.SP_CREATE_RESERVA(this.NomPersona, this.Fech, this.ArriendoId, this.Acomp, this.Valor, this.Vigente);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Reserva Find(int id)
        {
            return this.db.RESERVA.Select(a => new Reserva()
            {
                Id = a.ID_RESERVA,
                NomPersona = a.NOM_PERSONA,
                Fech = a.FECH_ARRIENDO,
                ArriendoId = a.ID_ARRIENDO,
                Acomp = a.ACOMPANANTES,
                Valor = a.COSTO_RESERVA,
                Vigente = a.VIGENTE,

                Arriendo = new Arriendo()
                {
                    Id = a.ID_ARRIENDO,
                    ClienteId = a.ARRIENDO.ID_CLIENTE,
                    DptoId = a.ARRIENDO.ID_DPTO,
                    FecReserva = a.ARRIENDO.FECHA_RESERVA,
                    ValReserva = a.ARRIENDO.VALOR_RESERVA,
                    ResPago = a.ARRIENDO.RESERVA_PAGADA,
                    FecIni = a.ARRIENDO.FECHA_INICIO,
                    FecFin = a.ARRIENDO.FECHA_FIN,
                    CheckIn = a.ARRIENDO.CHECK_IN,
                    Checkout = a.ARRIENDO.CHECK_OUT,
                    Total = a.ARRIENDO.TOTAL_ARRIENDO
                }


            }).Where(d => d.Id == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                if (IsVig == true)
                {
                    Vigente = "1";
                }
                else
                {
                    Vigente = "0";
                }

                db.SP_UPDATE_RESERVA(this.Id,this.NomPersona, this.Fech, this.ArriendoId, this.Acomp);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Cancelar(int id)
        {
            try
            {
                db.SP_CANCEL_RESERVA(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
