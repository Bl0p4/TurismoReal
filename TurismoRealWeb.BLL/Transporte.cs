using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;

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
        public string Sentido { get; set; }

        public Arriendo Arriendo { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();


        public List<Transporte> ReadAll()
        {
            return this.db.SOLICITUD_TRANSPORTE.Select(a => new Transporte()
            {
                Id = a.ID_SOLICITUD,
                ArriendoId = a.ID_ARRIENDO,
                Fecha = a.FECHA_INICIO,
                Pasajeros = a.PASAJEROS,
                Origen = a.DIR_INICIO,
                Destino = a.DIR_DESTINO,
                Sentido = a.SENTIDO_VIAJE,
                Distancia = (decimal)a.KMS_DISTANCIA,
                Aceptada = a.ACEPTADA,
                Costo = (decimal)a.COSTO,


                Arriendo = new Arriendo()
                {
                    Id = a.ID_ARRIENDO,
                    ClienteId = a.ARRIENDO.ID_CLIENTE,
                    DptoId = a.ARRIENDO.ID_DPTO,
                    FecIni = a.ARRIENDO.FECHA_INICIO,
                    FecFin = a.ARRIENDO.FECHA_FIN,
                    CheckIn = a.ARRIENDO.CHECK_IN,
                    Checkout = a.ARRIENDO.CHECK_OUT,
                    Total = a.ARRIENDO.TOTAL_ARRIENDO,
                    total_serv = a.ARRIENDO.TOTAL_SERVICIOS
                }

            }).ToList();
        }


        public bool Save()
        {
            try
            {
                //    if (IsAceptada == true)
                //    {
                //        Aceptada = "1";
                //    }
                //    else if (IsAceptada == false)
                //    {
                //       Aceptada = "0";
                //    }
                //Procedimiento almacenado
                db.SP_CREATE_SOLTRANSPORT(this.ArriendoId, this.Fecha, this.Pasajeros, this.Origen, this.Destino, this.Distancia, this.Costo, this.Sentido);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Transporte Find(int id)
        {
            return this.db.SOLICITUD_TRANSPORTE.Select(a => new Transporte()
            {
                Id = a.ID_SOLICITUD,
                ArriendoId = a.ID_ARRIENDO,
                Fecha = a.FECHA_INICIO,
                Pasajeros = a.PASAJEROS,
                Origen = a.DIR_INICIO,
                Destino = a.DIR_DESTINO,
                Sentido = a.SENTIDO_VIAJE,
                Distancia = (decimal)a.KMS_DISTANCIA,
                Aceptada = a.ACEPTADA,
                Costo = (decimal)a.COSTO,


                Arriendo = new Arriendo()
                {
                    Id = a.ID_ARRIENDO,
                    ClienteId = a.ARRIENDO.ID_CLIENTE,
                    DptoId = a.ARRIENDO.ID_DPTO,
                    FecIni = a.ARRIENDO.FECHA_INICIO,
                    FecFin = a.ARRIENDO.FECHA_FIN,
                    CheckIn = a.ARRIENDO.CHECK_IN,
                    Checkout = a.ARRIENDO.CHECK_OUT,
                    Total = a.ARRIENDO.TOTAL_ARRIENDO,
                    total_serv = a.ARRIENDO.TOTAL_SERVICIOS
                }


            }).Where(a => a.Id == id).FirstOrDefault();
        }


        public List<Transporte> BuscarPorArriendo(int id)
        {
            return this.db.SOLICITUD_TRANSPORTE.Select(a => new Transporte()
            {
                Id = a.ID_SOLICITUD,
                ArriendoId = a.ID_ARRIENDO,
                Fecha = a.FECHA_INICIO,
                Pasajeros = a.PASAJEROS,
                Origen = a.DIR_INICIO,
                Destino = a.DIR_DESTINO,
                Sentido = a.SENTIDO_VIAJE,
                Distancia = (decimal)a.KMS_DISTANCIA,
                Aceptada = a.ACEPTADA,
                Costo = (decimal)a.COSTO,


                Arriendo = new Arriendo()
                {
                    Id = a.ID_ARRIENDO,
                    ClienteId = a.ARRIENDO.ID_CLIENTE,
                    DptoId = a.ARRIENDO.ID_DPTO,
                    FecIni = a.ARRIENDO.FECHA_INICIO,
                    FecFin = a.ARRIENDO.FECHA_FIN,
                    CheckIn = a.ARRIENDO.CHECK_IN,
                    Checkout = a.ARRIENDO.CHECK_OUT,
                    Total = a.ARRIENDO.TOTAL_ARRIENDO,
                    total_serv = a.ARRIENDO.TOTAL_SERVICIOS
                }

            }).Where(a => a.ArriendoId == id).ToList();
        }


        public bool Update()
        {
            try
            {
                //if (IsAceptada == true)
                //    {
                //        Aceptada = "1";
                //    }
                //    else if (IsAceptada == false)
                //    {
                //       Aceptada = "0";
                //    }

                db.SP_UPDATE_SOLTRANSPORT(this.Id, this.ArriendoId, this.Fecha, this.Pasajeros, this.Origen, this.Destino, this.Sentido, this.Distancia, this.Aceptada, this.Costo);
                
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {
                db.SP_CANCEL_SOLTRANSPORT(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
