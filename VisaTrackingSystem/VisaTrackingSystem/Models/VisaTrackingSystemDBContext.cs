using Microsoft.EntityFrameworkCore;

namespace VisaTrackingSystem.Models
{
    public partial class VisaTrackingSystemDBContext : DbContext
    {
        public VisaTrackingSystemDBContext()
        {
        }

        public VisaTrackingSystemDBContext(DbContextOptions<VisaTrackingSystemDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<VisaDetails> VisaDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\ProjectsV13;Initial Catalog=VisaTrackingSystemDB;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VisaDetails>(entity =>
            {
                entity.HasKey(e => e.VisaRequsitionId);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VisaExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.VisaIssueDate).HasColumnType("datetime");

                entity.Property(e => e.VisaStatus)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });
        }
    }
}
