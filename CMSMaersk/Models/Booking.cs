using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMSMaersk.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        
        [ForeignKey("Item")]
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }

        public int VesselID { get; set; }
        public virtual Vessel Vessel { get; set; }
    }
}