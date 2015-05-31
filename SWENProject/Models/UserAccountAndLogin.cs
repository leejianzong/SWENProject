namespace SWENProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccountAndLogin")]
    public partial class UserAccountAndLogin
    {
        [Key]
        [StringLength(50)]
        public string AccountID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public byte[] FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string MailingAddress { get; set; }

        public int ContactNumber { get; set; }
    }
}
