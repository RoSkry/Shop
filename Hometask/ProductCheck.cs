//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hometask
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductCheck
    {
        public int Id { get; set; }
        public int Count { get; set; }
    
        public virtual Check Check { get; set; }
        public virtual Product Product { get; set; }
    }
}
