using MedicalServices.Enums;
using MedicalServices.Models;
using MedicalServices.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<PatientFavoriteDoctors> PatientFavoriteDoctors { get; set; }
        public DbSet<AvailableAppointments> AvailableAppointments { get; set; }
        public DbSet<Chat> Chats { get; set; }


        public static class AdminSeeder
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Patient)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PatientId)
                .OnDelete(DeleteBehavior.NoAction); // Change to NoAction or Restrict

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Doctor)
                .WithMany(d => d.Bookings)
                .HasForeignKey(b => b.DoctorId)
                .OnDelete(DeleteBehavior.NoAction); // Change to NoAction or Restrict

            // Booking Relationships
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Doctor)
                .WithMany(d => d.Bookings)
                .HasForeignKey(b => b.DoctorId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Patient)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PatientId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Appointment)
                .WithMany()
                .HasForeignKey(b => b.AppointmentId);

            modelBuilder.Entity<Review>()
               .HasOne(b => b.Patient)
               .WithMany(p => p.Reviews)
               .HasForeignKey(b => b.PatientId)
               .OnDelete(DeleteBehavior.NoAction); // Change to NoAction or Restrict

            modelBuilder.Entity<PatientFavoriteDoctors>()
                .HasKey(pfd => new { pfd.PatientId, pfd.DoctorId });

            modelBuilder.Entity<PatientFavoriteDoctors>()
                .HasOne(p => p.patient)
                .WithMany(d => d.PatientFavoriteDoctors)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete for Patient

            modelBuilder.Entity<PatientFavoriteDoctors>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.PatientFavoriteDoctors)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete for Doctor

            modelBuilder.Entity<Doctor>()
            .HasMany(d => d.AvailableAppointments)
            .WithOne(a => a.Doctor)
            .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<AvailableAppointments>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.AvailableAppointments)
            .HasForeignKey(a => a.DoctorId);


        }
    }
}
