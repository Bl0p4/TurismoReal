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
    
    public partial class ARRIENDO_AMIGO
    {
        public decimal ID { get; set; }
        public decimal ID_ARRIENDO { get; set; }
        public decimal ID_AMIGOS { get; set; }
    
        public virtual AMIGO AMIGO { get; set; }
        public virtual ARRIENDO ARRIENDO { get; set; }
    }
}