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
    
    public partial class DEPARTAMENTOS
    {
        public DEPARTAMENTOS()
        {
            this.INVENTARIO = new HashSet<INVENTARIO>();
            this.MANTENCIONES = new HashSet<MANTENCIONES>();
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
        public string ESTADO { get; set; }
    
        public virtual CIUDADES CIUDADES { get; set; }
        public virtual ICollection<INVENTARIO> INVENTARIO { get; set; }
        public virtual ICollection<MANTENCIONES> MANTENCIONES { get; set; }
    }
}
