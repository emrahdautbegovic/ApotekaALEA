using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PISprojekat.Models
{
    public class Asset
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Name cannot be longer than 20 characters!")]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Vendor { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Serial number cannot be longer than 50 characters.")]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Next Maintenance Date")]
        public DateTime NextMaintenanceDate { get; set; }
        [Required]
        [Display(Name = "Depreciation Value")]
        public int DepreciationValue { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Owner name cannot be longer than 20 characters.")]
        public string Owner { get; set; }
        public string Parrent { get; set; }

        public int? AssetTypeId { get; set; }
        [ForeignKey("AssetTypeId")]
        [Display(Name = "AssetType")]
        public AssetType AssetType { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name = "Category")]
        public Category Category { get; set; }

        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        [Display(Name = "Status")]
        public Status Status { get; set; }

        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        [Display(Name = "Department")]
        public Department Department { get; set; }
    }
}