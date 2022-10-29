using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;

namespace TurismoRealWeb.BLL
{
    public class Arriendo
    {
        public decimal Id { get; set; }
        public decimal ClienteId { get; set; }
        public decimal DptoId { get; set; }
        public DateTime FecReserva { get; set; }
        public decimal ValReserva { get; set; }
        public Boolean IsResPago { get; set; }
        public string ResPago { get; set; }
        public DateTime FecIni { get; set; }
        public DateTime FecFin { get; set; }
        public string CheckIn { get; set; }
        public string Checkout { get; set; }
        public decimal Total { get; set; }

        public Usuario Cliente { get; set; }
        public Departamento Departamento { get; set; }


        TurismoRealEntities db = new TurismoRealEntities();


        public List<Arriendo> ReadAll()
        {
            return this.db.ARRIENDO.Select(a => new Arriendo()
            {
                Id = a.ID_ARRIENDO,
                ClienteId = a.ID_CLIENTE,
                DptoId = a.ID_DPTO,
                FecReserva = a.FECHA_RESERVA,
                ValReserva = a.VALOR_RESERVA,
                ResPago = a.RESERVA_PAGADA,
                FecIni = a.FECHA_INICIO,
                FecFin = a.FECHA_FIN,
                CheckIn = a.CHECK_IN,
                Checkout = a.CHECK_OUT,
                Total = a.TOTAL_ARRIENDO,

                Cliente = new Usuario()
                {
                    Id = a.USUARIO.ID_USUARIO,
                    Nombre = a.USUARIO.NOMBRE,
                    Paterno = a.USUARIO.APE_PAT,
                    Materno = a.USUARIO.APE_MAT,
                    Rut = a.USUARIO.RUT,
                    Dv = a.USUARIO.DV,
                    Direccion = a.USUARIO.DIRECCION,
                    Ciudad = a.USUARIO.CIUDAD,
                    Telefono = a.USUARIO.TELEFONO,
                    Email = a.USUARIO.EMAIL,
                    Area = a.USUARIO.AREA_FUNCIONARIO,
                    Username = a.USUARIO.USERNAME,
                    Password = a.USUARIO.PASSWORD,
                    Id_tipo = a.USUARIO.ID_TIPOUSUARIO,
                },

                Departamento = new Departamento()
                {
                    Id = a.ID_DPTO,
                    CiudadId = a.DEPARTAMENTO.ID_CIUDAD,
                    Nombre = a.DEPARTAMENTO.NOMBRE,
                    Direccion = a.DEPARTAMENTO.DIRECCION,
                    Superficie = a.DEPARTAMENTO.SUPERFICIE_DPTO,
                    Precio = a.DEPARTAMENTO.PRECIO_DPTO,
                    Disponible = a.DEPARTAMENTO.DISPONIBLE,
                    Condicion = a.DEPARTAMENTO.CONDICION,
                    NumDpto = a.DEPARTAMENTO.NRO_DPTO,
                }


            }).ToList();
        }

        public bool Save()
        {
            try
            {
                if (IsResPago == true)
                {
                    ResPago = "1";
                }
                else if (IsResPago == false)
                {
                    ResPago = "0";
                }
                //Procedimiento almacenaao
                //ab.SP_CREATE_ARRIENDO();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Arriendo Find(int id)
        {
            return this.db.ARRIENDO.Select(a => new Arriendo()
            {
                Id = a.ID_ARRIENDO,
                ClienteId = a.ID_CLIENTE,
                DptoId = a.ID_DPTO,
                FecReserva = a.FECHA_RESERVA,
                ValReserva = a.VALOR_RESERVA,
                ResPago = a.RESERVA_PAGADA,
                FecIni = a.FECHA_INICIO,
                FecFin = a.FECHA_FIN,
                CheckIn = a.CHECK_IN,
                Checkout = a.CHECK_OUT,
                Total = a.TOTAL_ARRIENDO,

                Cliente = new Usuario()
                {
                    Id = a.USUARIO.ID_USUARIO,
                    Nombre = a.USUARIO.NOMBRE,
                    Paterno = a.USUARIO.APE_PAT,
                    Materno = a.USUARIO.APE_MAT,
                    Rut = a.USUARIO.RUT,
                    Dv = a.USUARIO.DV,
                    Direccion = a.USUARIO.DIRECCION,
                    Ciudad = a.USUARIO.CIUDAD,
                    Telefono = a.USUARIO.TELEFONO,
                    Email = a.USUARIO.EMAIL,
                    Area = a.USUARIO.AREA_FUNCIONARIO,
                    Username = a.USUARIO.USERNAME,
                    Password = a.USUARIO.PASSWORD,
                    Id_tipo = a.USUARIO.ID_TIPOUSUARIO,
                },

                Departamento = new Departamento()
                {
                    Id = a.ID_DPTO,
                    CiudadId = a.DEPARTAMENTO.ID_CIUDAD,
                    Nombre = a.DEPARTAMENTO.NOMBRE,
                    Direccion = a.DEPARTAMENTO.DIRECCION,
                    Superficie = a.DEPARTAMENTO.SUPERFICIE_DPTO,
                    Precio = a.DEPARTAMENTO.PRECIO_DPTO,
                    Disponible = a.DEPARTAMENTO.DISPONIBLE,
                    Condicion = a.DEPARTAMENTO.CONDICION,
                    NumDpto = a.DEPARTAMENTO.NRO_DPTO,
                }


            }).Where(a => a.Id == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                if (IsResPago == true)
                {
                    ResPago = "1";
                }
                else if (IsResPago == false)
                {
                    ResPago = "0";
                }

                //db.SP_UPDATE_ARRIENDO();
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
                db.SP_DELETE_ARRIENDO(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
