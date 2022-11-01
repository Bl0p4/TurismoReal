using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TurismoRealWeb.DAL;

namespace TurismoRealWeb.BLL
{
    public class Usuario
    {
        public decimal Id { get; set; }

        [Required(ErrorMessage = "Ingrese Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese Apellido")]
        public string Paterno { get; set; }

        [Required(ErrorMessage = "Ingrese Apellido Materno")]
        public string Materno { get; set; }

        [Required(ErrorMessage = "Ingrese Rut")]
        public decimal Rut { get; set; }

        [Required(ErrorMessage = "Ingrese Dígito Verificador")]
        public string Dv { get; set; }

        [Required(ErrorMessage = "Ingrese Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Ingrese Ciudad")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Ingrese Telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese Email")]
        public string Email { get; set; }
        public string Area { get; set; }

        [Required(ErrorMessage ="Ingrese Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Ingrese Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public decimal Id_tipo { get; set; }
        public Tipo_usuario Tipo { get; set; }

        public string Cuenta { get; set; }
        public string Pass { get; set; }


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
                this.Pass = TR_Recursos.ConvertirSha256(Pass);

                //Procedimiento almacenado
                db.SP_CREATE_USUARIO(this.Id_tipo, this.Nombre, this.Paterno, this.Materno,
                                     this.Rut, this.Dv, this.Direccion, this.Ciudad,
                                     this.Telefono, this.Email, this.Area, this.Cuenta, this.Pass);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Reg()
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
