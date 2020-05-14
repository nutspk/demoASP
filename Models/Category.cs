using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demoASP.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "max length 50 charactors")]
        [Column("category_name")]
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }
    }
}