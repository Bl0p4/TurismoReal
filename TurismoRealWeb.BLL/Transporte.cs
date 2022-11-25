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
                Distancia = (decimal)a.KMS_DISTANCIA,
                Aceptada = a.ACEPTADA,
                Costo = (decimal)a.COSTO,
                Sentido = a.SENTIDO_VIAJE,


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
                if (IsDisp == true)
                {
                    Disponible = "1";
                }
                else if (IsDisp == false)
                {
                    Disponible = "0";
                }
                //Procedimiento almacenado
                db.SP_CREATE_DPTO(this.CiudadId, this.Nombre, this.Direccion, this.Superficie, this.Precio, this.Disponible, this.Condicion, this.NumDpto);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Departamento Find(int id)
        {
            return this.db.DEPARTAMENTO.Select(d => new Departamento()
            {
                Id = d.ID_DPTO,
                CiudadId = d.ID_CIUDAD,
                Nombre = d.NOMBRE,
                Direccion = d.DIRECCION,
                Superficie = d.SUPERFICIE_DPTO,
                Precio = d.PRECIO_DPTO,
                Disponible = d.DISPONIBLE,
                Condicion = d.CONDICION,
                NumDpto = d.NRO_DPTO,
                Ciudad = new Ciudad()
                {
                    Id = d.ID_CIUDAD,
                    Nombre = d.CIUDAD.NOMBRE
                }


            }).Where(d => d.Id == id).FirstOrDefault();
        }


        public bool Update()
        {
            try
            {
                if (IsDisp == true)
                {
                    Disponible = "1";
                }
                else
                {
                    Disponible = "0";
                }

                db.SP_UPDATE_DPTO(this.Id, this.CiudadId, this.Nombre, this.Direccion,
                                this.Superficie, this.NumDpto, this.Precio, this.Disponible, this.Condicion);
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
                db.SP_DELETE_DPTO(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
