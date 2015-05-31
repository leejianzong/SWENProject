namespace SWENProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reporting")]
    public partial class Reporting
    {
        [Key]
        [StringLength(50)]
        public string ReportID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomStatus { get; set; }

        [Required]
        public string AllOccupantsInARoom { get; set; }

        [Required]
        public string AllGuestInAllTheRoom { get; set; }

        [Required]
        public string RoomOccupancy { get; set; }

        [Required]
        public string DutiesStaffAllocatedTo { get; set; }
    }
}
