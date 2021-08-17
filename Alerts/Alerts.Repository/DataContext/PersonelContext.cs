using Alerts.Models.Personel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alerts.Repository.DataContext
{
    public partial class PersonelContext : DbContext
    {
        public PersonelContext()
        {
        }

        public PersonelContext(DbContextOptions<PersonelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alert> Alerts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=HBPAYHR;User Id=sa;Password=P@55w0rd;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alert>(entity =>
            {
                entity.HasKey(e => new { e.Reference, e.Refline });

                entity.ToTable("ALERTS");

                entity.Property(e => e.Reference)
                    .HasColumnName("REFERENCE")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Refline)
                    .HasColumnName("REFLINE")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Atype)
                    .IsRequired()
                    .HasColumnName("ATYPE")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bodyemail)
                    .IsRequired()
                    .HasColumnName("BODYEMAIL")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bodysms)
                    .IsRequired()
                    .HasColumnName("BODYSMS")
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Edate)
                    .HasColumnName("EDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasColumnName("ESTATUS")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Etime)
                    .IsRequired()
                    .HasColumnName("ETIME")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Expiration)
                    .HasColumnName("EXPIRATION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Provider)
                    .IsRequired()
                    .HasColumnName("PROVIDER")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sdate)
                    .HasColumnName("SDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sstatus)
                    .IsRequired()
                    .HasColumnName("SSTATUS")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Stime)
                    .IsRequired()
                    .HasColumnName("STIME")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("SUBJECT")
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasColumnName("TELEPHONE")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("TITLE")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
