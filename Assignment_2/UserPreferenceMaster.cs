//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated> 
//------------------------------------------------------------------------------

namespace Assignment_2
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserPreferenceMaster
    {
        public System.Guid Id { get; set; }
        public System.Guid UserID { get; set; }
        public string ThemeColor { get; set; }
        public string Font { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
