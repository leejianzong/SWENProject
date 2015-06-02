namespace SWENProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [StringLength(50)]
        public string BookingID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string StaffIncharge { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckinDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckoutDate { get; set; }

        public int NumberOfAdult { get; set; }

        public int NumberOfKid { get; set; }

        public int ContactNumber { get; set; }

        [Required]
        public string MailingAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentDetails { get; set; }

        [StringLength(50)]
        public string CreditCardNumber { get; set; }

        [StringLength(50)]
        public string CreditCardHolderName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreditCardExpiryDate { get; set; }

        [StringLength(50)]
        public string AdditionalRemarks { get; set; }

        public DateTime? LateCheck { get; set; }
    }
}
