using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Nombre { get; set; } 
        public DateTime FecIni { get; set; }
        public DateTime FecFin { get; set; }
        public string CheckIn { get; set; }
        public string Checkout { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Total { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal total_serv { get; set; }

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
                FecIni = a.FECHA_INICIO,
                FecFin = a.FECHA_FIN,
                CheckIn = a.CHECK_IN,
                Checkout = a.CHECK_OUT,
                Total = a.TOTAL_ARRIENDO,
                total_serv = a.TOTAL_SERVICIOS,

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

        public List<Arriendo> ArriendosPorUser(decimal id)        
        {
            var arr = db.ARRIENDO.Select(
                a => new Arriendo()
                {
                    Id = a.ID_ARRIENDO,
                    ClienteId = a.ID_CLIENTE,
                    DptoId = a.ID_DPTO,
                    FecIni = a.FECHA_INICIO,
                    FecFin = a.FECHA_FIN,
                    CheckIn = a.CHECK_IN,
                    Checkout = a.CHECK_OUT,
                    Total = a.TOTAL_ARRIENDO,
                    total_serv = a.TOTAL_SERVICIOS,

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
                }).Where(a => a.ClienteId == id).ToList();
            return arr;
        }


        public bool Save()
        {
            try
            {
                TimeSpan ts = FecFin - FecIni;                
                decimal diferencia = ts.Days;
                if (diferencia < 0)
                {
                    diferencia = 1;
                }

                Total = Total * diferencia;
                //Procedimiento almacenado
                db.SP_CREATE_ARRIENDO(this.ClienteId,this.DptoId,this.FecIni,this.FecFin,this.Total, this.total_serv);
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
                FecIni = a.FECHA_INICIO,
                FecFin = a.FECHA_FIN,
                CheckIn = a.CHECK_IN,
                Checkout = a.CHECK_OUT,
                Total = a.TOTAL_ARRIENDO,
                total_serv = a.TOTAL_SERVICIOS,

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
                
                db.SP_UPDATE_ARRIENDO(this.Id,this.ClienteId, this.DptoId, this.FecIni, this.FecFin, this.Total, this.total_serv);
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
