//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ghostly.DAL.SQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class fdc_food
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fdc_food()
        {
            this.fdc_branded_food = new HashSet<fdc_branded_food>();
        }
    
        public double fdc_id { get; set; }
        public string data_type { get; set; }
        public string description { get; set; }
        public string food_category_id { get; set; }
        public Nullable<System.DateTime> publication_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fdc_branded_food> fdc_branded_food { get; set; }
    }
}