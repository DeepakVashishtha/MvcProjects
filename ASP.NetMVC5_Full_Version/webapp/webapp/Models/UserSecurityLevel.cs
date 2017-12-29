using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartAdminMvc.Models
{
    public class UserSecurityLevel
    {
        public int SecurityLevelID { get; set; }
        public string SecurityLevelName { get; set; }
        public int UserTypeID { get; set; }
        public bool PageEdit { get; set; }
        public bool PageView { get; set; }
        public bool PageDelete { get; set; }
        public Nullable<int> PageId { get; set; }
    }
}