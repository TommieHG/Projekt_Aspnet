//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventory.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Object
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Object()
        {
            this.Tbl_Object_Location = new HashSet<Tbl_Object_Location>();
        }
    
        public int Ob_ID { get; set; }
        public int FK_Ca_ID { get; set; }
        public string Ob_Name { get; set; }
        public Nullable<System.DateTime> Ob_Purchase_Date { get; set; }
        public Nullable<double> Ob_Est_Value { get; set; }
        public string Ob_Description { get; set; }
    
        public virtual Tbl_Category Tbl_Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Object_Location> Tbl_Object_Location { get; set; }
    }
}