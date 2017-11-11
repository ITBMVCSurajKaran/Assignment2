using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_2.Models
{
    public partial class AnnouncementViewModel
    {
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string UserType { get; set; }
        public string DateCreated { get; set; }
        
    }
}