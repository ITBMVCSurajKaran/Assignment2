using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_2.Models
{
    public class GroupViewModel
    {

        public System.Guid Id { get; set; }
        public string GroupName { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.Guid> CourseID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> DateEdited { get; set; }
        public Nullable<bool> IsEnable { get; set; }
        public Nullable<bool> IsActive { get; set; }

    }
}