using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartShare.Models
{
    public class Notifications
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NotificationID { get; set; }

        [Required]
        public int AdvertisementsID { get; set; }

        [Required]
        [Display(Name = "Message Body")]
        public string MessageBody { get; set; }

        [Required]
        [Display(Name = "Send To")]
        public int SendTo { get; set; }

        [Required]
        [Display(Name = "Send From")]
        public int SendFrom { get; set; }

        [Required]
        [Display(Name = "Notification Date")]
        public System.DateTime CreatedDate { get; set; }

        [Required]
        [Display(Name = "Have Seen")]
        public Nullable<int> HaveSeen { get; set; }
    }

    public class NotificationContext : DbContext
    {
        public DbSet<Notifications> NotificationDb { get; set; }
    }
}