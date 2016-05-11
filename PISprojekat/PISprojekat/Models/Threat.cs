using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PISprojekat.Models
{
    public class Threat
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Describe { get; set; }
        public int? ProjectPlanId { get; set; }
        [ForeignKey("ProjectPlanId")]
        [Display(Name = "Project")]
        public ProjectPlan ProjectPlan { get; set; }
    }
}