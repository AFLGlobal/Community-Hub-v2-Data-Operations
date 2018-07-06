using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using System.Collections.Generic;

namespace Conversion.Data.v1
{
    public partial class communityContext : DbContext
    {
        public communityContext()
        {
        }

        public communityContext(DbContextOptions<communityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<BusinessUnits> BusinessUnits { get; set; }
        public virtual DbSet<Contributions> Contributions { get; set; }
        public virtual DbSet<Designations> Designations { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<FriendWork> FriendWork { get; set; }
        public virtual DbSet<GivingCampaigns> GivingCampaigns { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<Priorities> Priorities { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<ReportViews> ReportViews { get; set; }
        public virtual DbSet<Rewards> Rewards { get; set; }
        public virtual DbSet<ServiceTypes> ServiceTypes { get; set; }
        public virtual DbSet<Usages> Usages { get; set; }
        public virtual DbSet<Waivers> Waivers { get; set; }
        public virtual DbSet<WorkOpportunities> WorkOpportunities { get; set; }
        public virtual DbSet<EmployeeWork> EmployeeWork { get; set; }

        // Unable to generate entity type for table 'dbo.RewardLocations'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CampaignRewards'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UWEmployeeTable'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CampaignOrganizations'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CampaignLocations'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.EmployeeWork'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.OrganizationLocations'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("v1_conn_string"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Hash).HasColumnName("hash");

                entity.Property(e => e.LastAccess).HasColumnType("datetime");

                entity.Property(e => e.LastIp).HasColumnName("LastIP");
            });

            modelBuilder.Entity<BusinessUnits>(entity =>
            {
                entity.HasKey(e => e.BusinessUnitId);

                entity.Property(e => e.BusinessUnitId).HasColumnName("BusinessUnitID");

                entity.Property(e => e.BusinessUnit).IsRequired();
            });

            modelBuilder.Entity<Contributions>(entity =>
            {
                entity.HasKey(e => e.ContributionId);

                entity.Property(e => e.ContributionId).HasColumnName("ContributionID");

                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");

                entity.Property(e => e.ConfirmationEmailSent).HasColumnType("datetime");

                entity.Property(e => e.ContributionAmount).HasColumnType("money");

                entity.Property(e => e.ContributionDate).HasColumnType("datetime");

                entity.Property(e => e.ContributionFrequency)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ContributionMethod)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ShirtSize).HasMaxLength(10);

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.Uwpsocieties)
                    .HasColumnName("UWPSocieties")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Designations>(entity =>
            {
                entity.HasKey(e => e.DesignationId);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.Designation).IsRequired();

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.BusinessUnitId).HasColumnName("BusinessUnitID");

                entity.Property(e => e.EmpAltEmail).HasMaxLength(50);

                entity.Property(e => e.EmpCell).HasMaxLength(50);

                entity.Property(e => e.EmpCity).HasMaxLength(50);

                entity.Property(e => e.EmpEmail).HasMaxLength(50);

                entity.Property(e => e.EmpFirst)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpLast)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpMiddle).HasMaxLength(50);

                entity.Property(e => e.EmpPhone).HasMaxLength(50);

                entity.Property(e => e.EmpPostal).HasMaxLength(50);

                entity.Property(e => e.EmpState).HasMaxLength(50);

                entity.Property(e => e.EmpStreet).HasMaxLength(50);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Mid).HasColumnName("MID");

                entity.Property(e => e.SupervisorId).HasColumnName("SupervisorID");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<EmployeeWork>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);
            });

            modelBuilder.Entity<FriendWork>(entity =>
            {
                entity.HasKey(e => e.Ffid);

                entity.Property(e => e.Ffid).HasColumnName("FFID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeWorkId).HasColumnName("EmployeeWorkID");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<GivingCampaigns>(entity =>
            {
                entity.HasKey(e => e.CampaignId);

                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PrizeQualifier).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.GroupName).IsRequired();
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocCountry)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LocName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Organizations>(entity =>
            {
                entity.HasKey(e => e.OrganizationId);

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Organization).IsRequired();
            });

            modelBuilder.Entity<Priorities>(entity =>
            {
                entity.HasKey(e => e.PriorityId);

                entity.Property(e => e.PriorityId).HasColumnName("PriorityID");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.PriorityName).IsRequired();
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.DateEmailSent).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ProjectDescription).HasColumnType("text");

                entity.Property(e => e.ProjectName).IsRequired();

                entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");

                entity.Property(e => e.TshirtRequired).HasColumnName("TShirtRequired");
            });

            modelBuilder.Entity<ReportViews>(entity =>
            {
                entity.HasKey(e => e.ReportViewId);

                entity.Property(e => e.ReportViewId).HasColumnName("ReportViewID");

                entity.Property(e => e.FriendlyName).IsRequired();

                entity.Property(e => e.ViewName).IsRequired();
            });

            modelBuilder.Entity<Rewards>(entity =>
            {
                entity.HasKey(e => e.RewardId);

                entity.Property(e => e.RewardId).HasColumnName("RewardID");

                entity.Property(e => e.Reward).IsRequired();
            });

            modelBuilder.Entity<ServiceTypes>(entity =>
            {
                entity.HasKey(e => e.ServiceTypeId);

                entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");

                entity.Property(e => e.ServiceType).IsRequired();
            });

            modelBuilder.Entity<Usages>(entity =>
            {
                entity.HasKey(e => e.UsageId);

                entity.Property(e => e.UsageId).HasColumnName("UsageID");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.Usage).IsRequired();
            });

            modelBuilder.Entity<Waivers>(entity =>
            {
                entity.HasKey(e => e.WaiverId);

                entity.Property(e => e.WaiverId).HasColumnName("WaiverID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.WaiverText).IsRequired();

                entity.Property(e => e.WaiverUrl)
                    .IsRequired()
                    .HasColumnName("WaiverURL");
            });

            modelBuilder.Entity<WorkOpportunities>(entity =>
            {
                entity.HasKey(e => e.WorkOpportunityId);

                entity.Property(e => e.WorkOpportunityId).HasColumnName("WorkOpportunityID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.WoendDateTime)
                    .HasColumnName("WOEndDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Wohours).HasColumnName("WOHours");

                entity.Property(e => e.WostartDateTime)
                    .HasColumnName("WOStartDateTime")
                    .HasColumnType("datetime");
            });
        }
    }
}
