using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PISprojekat.Models
{
    public class Risk
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Risk Level")]
        [Range(1, 10)]
        public int RiskLevel { get; set; }

        public int? ProjectPlanId { get; set; }
        [ForeignKey("ProjectPlanId")]
        [Display(Name = "Project")]
        public ProjectPlan ProjectPlan { get; set; }

        public int? ThreatId { get; set; }
        [ForeignKey("ThreatId")]
        [Display(Name = "Threat")]
        public Threat Threat { get; set; }

        public int? VulnerabilityId { get; set; }
        [ForeignKey("VulnerabilityId")]
        [Display(Name = "Vulnerability")]
        public Vulnerability Vulnerability { get; set; }
    }
}