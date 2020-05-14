using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demoASP.Models
{
    [Table("customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index]
        [Column("customer_id")]
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "max length 150 charactors")]
        [Column("company_name")]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "max length 30 charactors")]
        [Column("contact_name")]
        [Display(Name = "Contact name")]
        public string ContactName { get; set; }

        [StringLength(30, ErrorMessage = "max length 30 charactors")]
        [Column("contact_title")]
        [Display(Name = "Contact Title")]
        public string ContactTitle { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "max length 60 charactors")]
        [Column("address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(15, ErrorMessage = "max length 15 charactors")]
        [Column("city")]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(15, ErrorMessage = "max length 15 charactors")]
        [Column("region")]
        [Display(Name = "Region")]
        public string Region { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "max length 10 charactors")]
        [Column("postal_code")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "max length 15 charactors")]
        [Column("country")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [StringLength(24, ErrorMessage = "max length 24 charactors")]
        [Column("phone")]
        [Display(Name = "Tel.")]
        public string Phone { get; set; }

        [StringLength(24, ErrorMessage = "max length 24 charactors")]
        [Column("fax")]
        [Display(Name = "Fax.")]
        public string Fax { get; set; }


        public virtual ICollection<Order> Orders { get; set; }

        public int OrderCount => (Orders != null) ? Orders.Count() : 0;

    }
}