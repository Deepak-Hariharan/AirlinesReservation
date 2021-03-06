//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirlinesAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class FlightSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FlightSchedule()
        {
            this.ReservationMasters = new HashSet<ReservationMaster>();
        }
    
        public string FlightNo { get; set; }
        public System.DateTime TravelDate { get; set; }
        public System.TimeSpan DepartTime { get; set; }
        public System.TimeSpan ArriveTime { get; set; }
        public Nullable<int> FreeSeats { get; set; }
    
        public virtual Flight Flight { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationMaster> ReservationMasters { get; set; }
    }
}
