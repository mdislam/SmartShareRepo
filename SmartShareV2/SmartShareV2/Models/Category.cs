using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartShareV2.Models
{
    public class Category
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Advertisement Category")]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }
    }

    public class CategoryContext : DbContext
    {
        public CategoryContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Category> Category { get; set; }
    }
}