using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PISprojekat.Models
{
    public class Incident
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Describe { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Create Time")]
        public DateTime CreateTime { get; set; }

        public int? PriorityId { get; set; }
        [ForeignKey("PriorityId")]
        [Display(Name = "Priority")]
        public Priority Priority { get; set; }

        public int? IncidentStatusId { get; set; }
        [ForeignKey("IncidentStatusId")]
        [Display(Name = "Status")]
        public IncidentStatus IncidentStatus { get; set; }
    }
}