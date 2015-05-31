namespace SWENProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Reporting> Reportings { get; set; }
        public virtual DbSet<StaffManagement> StaffManagements { get; set; }
        public virtual DbSet<UserAccountAndLogin> UserAccountAndLogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.BookingID)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.RoomStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.StaffIncharge)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.MailingAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.PaymentDetails)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.CreditCardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.CreditCardHolderName)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.AdditionalRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<Reporting>()
                .Property(e => e.ReportID)
                .IsUnicode(false);

            modelBuilder.Entity<Reporting>()
                .Property(e => e.RoomStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Reporting>()
                .Property(e => e.AllOccupantsInARoom)
                .IsUnicode(false);

            modelBuilder.Entity<Reporting>()
                .Property(e => e.AllGuestInAllTheRoom)
                .IsUnicode(false);

            modelBuilder.Entity<Reporting>()
                .Property(e => e.RoomOccupancy)
                .IsUnicode(false);

            modelBuilder.Entity<Reporting>()
                .Property(e => e.DutiesStaffAllocatedTo)
                .IsUnicode(false);

            modelBuilder.Entity<StaffManagement>()
                .Property(e => e.StaffID)
                .IsUnicode(false);

            modelBuilder.Entity<StaffManagement>()
                .Property(e => e.StaffName)
                .IsUnicode(false);

            modelBuilder.Entity<StaffManagement>()
                .Property(e => e.BankAccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<StaffManagement>()
                .Property(e => e.MailingAddress)
                .IsUnicode(false);

            modelBuilder.Entity<StaffManagement>()
                .Property(e => e.DutyTypes)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccountAndLogin>()
                .Property(e => e.AccountID)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccountAndLogin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccountAndLogin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccountAndLogin>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccountAndLogin>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccountAndLogin>()
                .Property(e => e.MailingAddress)
                .IsUnicode(false);
        }
    }
}
