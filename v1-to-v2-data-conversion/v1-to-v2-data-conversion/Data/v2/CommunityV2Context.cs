using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Conversion.Data.v2
{
    public partial class CommunityV2Context : DbContext
    {
        public CommunityV2Context()
        {
        }

        public CommunityV2Context(DbContextOptions<CommunityV2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<Waiver> Waiver { get; set; }
        public virtual DbSet<WorkOpportunity> WorkOpportunity { get; set; }
        public virtual DbSet<WorkOpportunityForEmployee> WorkOpportunityForEmployee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("v2_conn_string"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeAlternateEmail).HasMaxLength(50);

                entity.Property(e => e.EmployeeCellPhone).HasMaxLength(50);

                entity.Property(e => e.EmployeeCity).HasMaxLength(50);

                entity.Property(e => e.EmployeeFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeMiddleName).HasMaxLength(50);

                entity.Property(e => e.EmployeePassword).HasColumnType("text");

                entity.Property(e => e.EmployeePhone).HasMaxLength(50);

                entity.Property(e => e.EmployeeState).HasMaxLength(10);

                entity.Property(e => e.EmployeeZip).HasMaxLength(10);

                entity.Property(e => e.LastAccessDateTime).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.MId).HasColumnName("M_ID");

                entity.Property(e => e.Title)
                    .HasColumnName("TItle")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_79");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationCountry)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.DateEmailSent).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ProjectDescription).HasColumnType("text");

                entity.Property(e => e.ProjectName).IsRequired();

                entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");

                entity.Property(e => e.TshirtRequired).HasColumnName("TShirtRequired");

                entity.Property(e => e.WaiverId).HasColumnName("WaiverID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_43");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_62");

                entity.HasOne(d => d.Waiver)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.WaiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_53");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");

                entity.Property(e => e.ServiceType1)
                    .IsRequired()
                    .HasColumnName("ServiceType");
            });

            modelBuilder.Entity<Waiver>(entity =>
            {
                entity.Property(e => e.WaiverId).HasColumnName("WaiverID");

                entity.Property(e => e.WaiverText).IsRequired();

                entity.Property(e => e.WaiverUrl)
                    .IsRequired()
                    .HasColumnName("WaiverURL");
            });

            modelBuilder.Entity<WorkOpportunity>(entity =>
            {
                entity.Property(e => e.WorkOpportunityId).HasColumnName("WorkOpportunityID");

                entity.Property(e => e.AllowGuests).HasColumnName("AllowGuests ");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.WorkOpportunityStartDateTime).HasColumnType("datetime");

                entity.Property(e => e.WorkOpportunityStopDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.WorkOpportunity)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_100");
            });

            modelBuilder.Entity<WorkOpportunityForEmployee>(entity =>
            {
                entity.Property(e => e.WorkOpportunityForEmployeeId).HasColumnName("WorkOpportunityForEmployeeID");

                entity.Property(e => e.EmployeeDateSignedUp).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.TshirtSize)
                    .HasColumnName("TShirtSize")
                    .HasMaxLength(50);

                entity.Property(e => e.WorkOpportunityId).HasColumnName("WorkOpportunityID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.WorkOpportunityForEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_115");

                entity.HasOne(d => d.WorkOpportunity)
                    .WithMany(p => p.WorkOpportunityForEmployee)
                    .HasForeignKey(d => d.WorkOpportunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_119");
            });
        }
    }
}
