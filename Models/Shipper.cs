using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demoASP.Models
{
    [Table("shippers")]
    public class Shipper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index]
        [Column("shipper_id")]
        public int ShipperId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "max length 150 charactors")]
        [Column("company_name")]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(24, ErrorMessage = "max length 24 charactors")]
        [Column("phone")]
        [Display(Name = "Tel.")]
        public string Phone { get; set; }

    }
}