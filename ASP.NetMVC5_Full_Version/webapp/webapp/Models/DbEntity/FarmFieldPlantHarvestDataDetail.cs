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
    using System.Collections.Generic;
    
    public partial class FarmFieldPlantHarvestDataDetail
    {
        public int FarmFieldPlantHarvestDataDetailID { get; set; }
        public int FarmFieldPlantHarvestDataID { get; set; }
        public string ContainerIDNO { get; set; }
        public int EmployeeID { get; set; }
    
        public virtual FarmFieldPlantHarvestData FarmFieldPlantHarvestData { get; set; }
    }
}