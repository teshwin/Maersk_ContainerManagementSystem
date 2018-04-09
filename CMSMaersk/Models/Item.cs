using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSMaersk.Models
{
    public class Item
    {
        public int ItemID { get; set; }

        [Display(Name = "Item")]
        public string ItemName { get; set; }

        [Required]
        [Range(1, 50)]
        [Display(Name = "Total Bays")]
        public int TotalBays { get; set; }

        [Required]
        [Display(Name = "Due Day")]
        public DayOfWeek DueDay{ get; set; }

        public Status Status { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }

    public enum Status { Complete, Pending, Unassigned}
}