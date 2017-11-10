using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_2.Models
{
    public class GroupDetailView
    {
        public System.Guid Id { get; set; }
        public System.Guid GroupId { get; set; }
        public System.Guid UserId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateEdited { get; set; }
        public Nullable<bool> IsEnable { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}