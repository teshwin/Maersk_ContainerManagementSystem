using CMSMaersk.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSMaersk.Models
{
    public class Vessel
    {
        public int VesselID { get; set; }

        [Required]
        [Display(Name = "Vessel Name")]
        public string Name { get; set; }

        [Required]
        public string Route { get; set; }

        [Required]
        public DayOfWeek Departure { get; set; }

        [Required]
        public DayOfWeek Arrival { get; set; }

        [Required]
        [Display(Name = "Available Bays")]
        public int TotalBays { get; set; }

        public virtual List<Booking> Bookings { get; set; }

        public bool HasSpace()
        {
            VesselRepository vesselRepository = new VesselRepository();
            var totalOccupied = vesselRepository.GetTotalBaysOccupied(this.VesselID);
            return totalOccupied < this.TotalBays;
        }
    }
}