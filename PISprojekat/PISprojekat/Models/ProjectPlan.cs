using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PISprojekat.Models
{
    public class ProjectPlan
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Describe { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        [Display(Name = "Plan Description")]
        public string PlanDescription { get; set; }
    }
}