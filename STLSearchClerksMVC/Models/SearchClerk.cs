//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace STLSearchClerksMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SearchClerk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SearchClerk()
        {
            this.DoubleBookings = new HashSet<DoubleBooking>();
        }
    
        public int SearchClerkId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoubleBooking> DoubleBookings { get; set; }
    }
}
