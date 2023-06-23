using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HubBrokerjobApplications.Models
{
    public partial class HubJobsContext : DbContext
    {
       

        public HubJobsContext(DbContextOptions<HubJobsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompanyMaster> CompanyMaster { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<StudentMaster> StudentMaster { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyMaster>(entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.Property(e => e.DocuentName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DocumentContent).IsRequired();

                entity.Property(e => e.DocumentType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StudentMaster>(entity =>
            {
                entity.HasKey(e => e.StuId);

                entity.Property(e => e.CurrentAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.PermanentAddress)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
