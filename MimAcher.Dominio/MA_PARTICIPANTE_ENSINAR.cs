//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MimAcher.Dominio
{
    using System;
    using System.Collections.Generic;
    
    public partial class MA_PARTICIPANTE_ENSINAR
    {
        public int cod_p_ensinar { get; set; }
        public int cod_item { get; set; }
        public int cod_participante { get; set; }
        public int cod_status { get; set; }
    
        public virtual MA_ITEM MA_ITEM { get; set; }
        public virtual MA_STATUS MA_STATUS { get; set; }
    }
}
