namespace SWENProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StaffManagement")]
    public partial class StaffManagement
    {
        [Key]
        [StringLength(50)]
        public string StaffID { get; set; }

        [Required]
        [StringLength(50)]
        public string StaffName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(50)]
        public string BankAccountNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string MailingAddress { get; set; }

        public int PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string DutyTypes { get; set; }
    }
}
