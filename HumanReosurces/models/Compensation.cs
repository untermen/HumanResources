//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HumanReosurces.models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Compensation
    {
        public long Id_compensation { get; set; }
        public long Id_employee { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public string Benefits { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}