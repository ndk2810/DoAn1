//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HeThongThueXe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOADONCT
    {
        public int IDHDCT { get; set; }
        public Nullable<int> IDHoaDon { get; set; }
        public Nullable<int> IDXe { get; set; }
        public Nullable<decimal> Gia { get; set; }
    
        public virtual HOADON HOADON { get; set; }
        public virtual XE XE { get; set; }
    }
}
