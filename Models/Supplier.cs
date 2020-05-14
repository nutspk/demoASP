using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demoASP.Models
{
    [Table("suppliers")]
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index]
        [Column("supplier_id")]
        [Display(Name = "Supplier Id")]
        public int SupplierID { get; set; }

        [Required]
        [Index]
        [StringLength(150, ErrorMessage = "max length 150 charactors")]
        [Column("company_name")]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "max length 30 charactors")]
        [Column("contact_name")]
        [Display(Name = "Contact name")]
        public string ContactName { get; set; }

        [Column("contact_title")]
        [Display(Name = "Contact Title")]
        [StringLength(30, ErrorMessage = "max length 30 charactors")]
        public string ContactTitle { get; set; }

        [Column("address")]
        [Display(Name = "Address")]
        [StringLength(60, ErrorMessage = "max length 60 charactors")]
        public string Address { get; set; }

        [Required]
        [Column("city")]
        [Display(Name = "City")]
        [StringLength(15, ErrorMessage = "max length 15 charactors")]
        public string City { get; set; }

        [Column("region")]
        [Display(Name = "Region")]
        [StringLength(15, ErrorMessage = "max length 15 charactors")]
        public string Region { get; set; }

        [Required]
        [Column("postal_code")]
        [Display(Name = "Postal Code")]
        [StringLength(10, ErrorMessage = "max length 10 charactors")]
        public string PostalCode { get; set; }

        [Required]
        [Column("country")]
        [Display(Name = "Country")]
        [StringLength(15, ErrorMessage = "max length 15 charactors")]
        public string Country { get; set; }

        [Required]
        [Column("phone")]
        [Display(Name = "Phone")]
        [StringLength(24, ErrorMessage = "max length 24 charactors")]
        public string Phone { get; set; }

        [Column("fax")]
        [Display(Name = "Fax")]
        [StringLength(24, ErrorMessage = "max length 24 charactors")]
        public string Fax { get; set; }

        [Column("homepage")]
        [Display(Name = "Home Page")]
        public string HomePage { get; set; }

        public virtual ICollection<Product> Products { get; set; }
            = new HashSet<Product>();
    }
}