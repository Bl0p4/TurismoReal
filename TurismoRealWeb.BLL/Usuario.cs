using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealWeb.DAL;

namespace TurismoRealWeb.BLL
{
    public class Usuario
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public decimal Rut { get; set; }
        public string Dv { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Area { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Id_tipo { get; set; }
        public Tipo_usuario Tipo { get; set; }


        TurismoRealEntities db = new TurismoRealEntities();


        public bool Autenticar()
        {
            return db.USUARIO
                .Where(u => u.USERNAME == this.Username
                && u.PASSWORD == this.Password)
                .FirstOrDefault() != null;
        }


        

        public List<Usuario> ReadAll()
        {
            return this.db.USUARIO.Select(p => new Usuario()
            {
                Id = p.ID_USUARIO,
                Nombre = p.NOMBRE,
                Paterno = p.APE_PAT,
                Materno = p.APE_MAT,
                Rut = p.RUT,
                Dv = p.DV,
                Direccion = p.DIRECCION,
                Ciudad = p.CIUDAD,
                Telefono = p.TELEFONO,
                Email = p.EMAIL,
                Area = p.AREA_FUNCIONARIO,
                Username = p.USERNAME,
                Password = p.PASSWORD,
                Id_tipo = p.ID_TIPOUSUARIO,
                Tipo = new Tipo_usuario()
                {
                    Id = p.ID_TIPOUSUARIO,
                    Descripcion = p.TIPO_USUARIO.DESCRIPCION
                }
            }).ToList();
        }

        public bool Save()
        {
            try
            {
                //Procedimiento almacenado
                db.SP_CREATE_USUARIO(this.Id_tipo, this.Nombre, this.Paterno, this.Materno,
                                     this.Rut, this.Dv, this.Direccion, this.Ciudad,
                                     this.Telefono, this.Email, this.Area, this.Username, this.Password);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
