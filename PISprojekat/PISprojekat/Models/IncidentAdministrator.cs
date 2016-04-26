using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PISprojekat.Models
{
    public class IncidentAdministrator
    {
        public int ID { get; set; }

        [Display(Name = "Incident")]
        public int? IncidentId { get; set; }
        [Display(Name = "Incident")]
        [ForeignKey("IncidentId")]
        public Incident Incident { get; set; }

        [Display(Name = "Incident Category")]
        public int? IncidentCategoryId { get; set; }
        [Display(Name = "Incident Category")]
        [ForeignKey("IncidentCategoryId")]
        public IncidentCategory IncidentCategory { get; set; }
    }
}