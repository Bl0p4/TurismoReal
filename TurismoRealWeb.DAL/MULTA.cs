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
    
    public partial class MULTA
    {
        public decimal ID_MULTA { get; set; }
        public decimal ID_ARRIENDO { get; set; }
        public decimal MONTO_MULTA { get; set; }
        public string DESCRIPCION { get; set; }
    
        public virtual ARRIENDO ARRIENDO { get; set; }
    }
}
