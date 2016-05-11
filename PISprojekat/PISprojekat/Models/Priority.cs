using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PISprojekat.Models
{
    public class Priority
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Priority")]
        public string PriorityType { get; set; }
    }
}