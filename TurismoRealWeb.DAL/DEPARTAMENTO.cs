//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurismoRealWeb.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class DEPARTAMENTO
    {
        public DEPARTAMENTO()
        {
            this.INVENTARIO = new HashSet<INVENTARIO>();
            this.MANTENCION = new HashSet<MANTENCION>();
            this.IMAGEN = new HashSet<IMAGEN>();
            this.ARRIENDO = new HashSet<ARRIENDO>();
        }
    
        public decimal ID_DPTO { get; set; }
        public decimal ID_CIUDAD { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public string SUPERFICIE_DPTO { get; set; }
        public decimal PRECIO_DPTO { get; set; }
        public string DISPONIBLE { get; set; }
        public string CONDICION { get; set; }
        public string NRO_DPTO { get; set; }
    
        public virtual CIUDAD CIUDAD { get; set; }
        public virtual ICollection<INVENTARIO> INVENTARIO { get; set; }
        public virtual ICollection<MANTENCION> MANTENCION { get; set; }
        public virtual ICollection<IMAGEN> IMAGEN { get; set; }
        public virtual ICollection<ARRIENDO> ARRIENDO { get; set; }
    }
}
