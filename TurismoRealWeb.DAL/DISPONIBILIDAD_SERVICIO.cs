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
    
    public partial class DISPONIBILIDAD_SERVICIO
    {
        public decimal ID_DPTO { get; set; }
        public decimal ID_SERVICIO { get; set; }
        public string ACTUALMENTE_DISPONIBLE { get; set; }
    
        public virtual DEPARTAMENTO DEPARTAMENTO { get; set; }
        public virtual SERVICIO_EXTRA SERVICIO_EXTRA { get; set; }
    }
}
