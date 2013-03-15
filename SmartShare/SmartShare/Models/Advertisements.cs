using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartShare.Models
{
    public class Advertisements
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AdvertisementID { get; set; }

        [Required]
        [Display(Name = "Advertisement Title")]
        public string AdvertisementTitle { get; set; }

        [Required]
        [Display(Name = "Advertisement Description")]
        public string AdvertisementDesc { get; set; }

        [Display(Name = "Upload Image")]
        public byte[] AdvertisementImage { get; set; }

        //[Display(Name = "Select Image")]
        //public HttpPostedFileBase ImageFile { get; set; }

        public int UserId { get; set; }
        //[ForeignKey("UserId")]
        //public virtual UserProfile CreatedBy { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string CategoryType { get; set; }

        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Advertisement Type")]
        public string AdvertisementType { get; set; }
    }

    public class AdvertisementsContext : DbContext
    {
        public DbSet<Advertisements> AdvertisementsDb { get; set; }
    }
}