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
    
    public partial class INVENTARIO
    {
        public decimal ID_INVENTARIO { get; set; }
        public decimal ID_DPTO { get; set; }
        public string NOMBRE { get; set; }
        public decimal VALOR { get; set; }
        public string DISPONIBLE { get; set; }
    
        public virtual DEPARTAMENTOS DEPARTAMENTOS { get; set; }
    }
}
