using System;
using Alerts.Models.Dama;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Alerts.Repository.DataContext
{
    public partial class DamaContext : DbContext
    {
        public DamaContext()
        {
        }

        public DamaContext(DbContextOptions<DamaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artbaseline> Artbaselines { get; set; }
        public virtual DbSet<ARTVisit> Artvisits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=DamaLocal;User Id=sa;Password=P@55w0rd;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artbaseline>(entity =>
            {
                entity.HasKey(e => e.Reference)
                    .HasName("PK_dbo.ARTBaseline");

                entity.ToTable("ARTBaseline");

                entity.HasIndex(e => new { e.Artsite, e.EnrollentDate, e.ArtstartDate })
                    .HasName("speed");

                entity.Property(e => e.Reference)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApsStaffCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Artcode)
                    .IsRequired()
                    .HasColumnName("ARTCode")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Artconso)
                    .HasColumnName("ARTConso")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Artsite)
                    .IsRequired()
                    .HasColumnName("ARTSite")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ArtstartDate)
                    .HasColumnName("ARTStartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BarCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Bmi).HasColumnName("BMI");

                entity.Property(e => e.CaseManagerCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cd4)
                    .HasColumnName("CD4")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cd4date)
                    .HasColumnName("CD4Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Child)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ClientPcs)
                    .HasColumnName("ClientPCs")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ClinicalStage)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactTelephone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfTest).HasColumnType("datetime");

                entity.Property(e => e.EligibilityCriteria)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.EnrollentDate).HasColumnType("datetime");

                entity.Property(e => e.ExistingArtcode)
                    .IsRequired()
                    .HasColumnName("ExistingARTCode")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ExpectedDeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.FeedingOption)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.InhstartDate)
                    .HasColumnName("INHStartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.InhstopDate)
                    .HasColumnName("INHStopDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Kptype)
                    .HasColumnName("KPType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastChangeDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastChangedBy)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PregnancyAge)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Profession)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Tbscreening)
                    .HasColumnName("TBScreening")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TbtheraphyStartDate)
                    .HasColumnName("TBTheraphyStartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TbtheraphyStopDate)
                    .HasColumnName("TBTheraphyStopDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TestedInThisFacility)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UniqueHospitalCode)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ViralHepatites)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ViralHepatitesType)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.WasPatientRetested)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ARTVisit>(entity =>
            {
                entity.HasKey(e => new { e.BaselineCode, e.Refline })
                    .HasName("PK_dbo.ARTVisit");

                entity.ToTable("ARTVisit");

                entity.HasIndex(e => e.BaselineCode)
                    .HasName("IX_BaselineCode");

                entity.HasIndex(e => new { e.Artsite, e.TransDate })
                    .HasName("speed");

                entity.Property(e => e.BaselineCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Refline)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Artcode)
                    .IsRequired()
                    .HasColumnName("ARTCode")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Artconso)
                    .IsRequired()
                    .HasColumnName("ARTConso")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Artsite)
                    .IsRequired()
                    .HasColumnName("ARTSite")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Arvregimen)
                    .IsRequired()
                    .HasColumnName("ARVRegimen")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CaseManagerReference)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientPcs)
                    .HasColumnName("ClientPCs")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Cotrimoxazole)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DefaulterOutCome)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DiedStatus)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DispensationReference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorReference)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dstatus)
                    .HasColumnName("DStatus")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Inhgiven)
                    .HasColumnName("INHGiven")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IsMultiVisit)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IsPregnant)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.LastChangeDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastChangedBy)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NextAppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.NurseReference)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PatientStatus)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PregnancyStatus)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PrevRegimen)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PrevTreatmentLine)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SessionCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SourceSitecode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SubstitutionReason)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Tbscreening)
                    .HasColumnName("TBScreening")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TransDate).HasColumnType("datetime");

                entity.Property(e => e.TransferSiteCode)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.TransferType)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TreatmentLine)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaselineCodeNavigation)
                    .WithMany(p => p.ARTVisit)
                    .HasForeignKey(d => d.BaselineCode)
                    .HasConstraintName("FK_dbo.ARTVisit_dbo.ARTBaseline_BaselineCode");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
