//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MimAcher.Infra
{
    using System;
    using System.Collections.Generic;
    
    public partial class ALUNO_ENSINAR
    {
        public int cod_ae { get; set; }
        public string login { get; set; }
        public int cod_e { get; set; }
    
        public virtual ALUNO ALUNO { get; set; }
        public virtual ENSINAR ENSINAR { get; set; }
    }
}