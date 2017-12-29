//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartAdminMvc.Models.DbEntity
{
    using System;
    
    public partial class USP_Users_Get_Result
    {
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public int UserTypeID { get; set; }
        public string UserTypeName { get; set; }
        public Nullable<int> ReferenceID { get; set; }
        public string ReferenceName { get; set; }
        public int SecurityLevelID { get; set; }
        public string SecurityLevelName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public string Notes { get; set; }
        public Nullable<int> ReportsTo { get; set; }
        public string ReportsToName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
