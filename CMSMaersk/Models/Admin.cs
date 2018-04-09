using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSMaersk.Models
{
    public class Admin
    {
        public int AdminID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual List<Agent> Agents { get; set; }
    }
}