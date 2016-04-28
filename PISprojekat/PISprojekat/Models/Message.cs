using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PISprojekat.Models
{
    public class Message
    {
        public int ID { get; set; }
        [Display(Name="Text")]
        public string MessageText { get; set; }
        [Display(Name = "Created at")]
        public DateTime CreateDate { get; set; }

        public int? IncidentId { get; set; }
        [ForeignKey("IncidentId")]
        [Display(Name = "Incident")]
        public Incident Incident { get; set; }

        public int? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        [Display(Name = "Author")]
        public MessageAuthor MessageAuthor { get; set; }

        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        [Display(Name = "Status")]
        public MessageStatus MessageStatus { get; set; }
    }
}