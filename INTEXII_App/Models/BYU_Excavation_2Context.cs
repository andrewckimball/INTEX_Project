using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class BYU_Excavation_2Context : DbContext
    {
        public BYU_Excavation_2Context()
        {
        }

        public BYU_Excavation_2Context(DbContextOptions<BYU_Excavation_2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Artifact> Artifacts { get; set; }
        public virtual DbSet<CarbonDating> CarbonDatings { get; set; }
        public virtual DbSet<HumanSample> HumanSamples { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<MiscSample> MiscSamples { get; set; }
        public virtual DbSet<QuadrantCardinality> QuadrantCardinalities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = intexii-db.cbixfz3dr1wn.us-east-1.rds.amazonaws.com; Database = BYU_Excavation_2; User Id= Group410; Password = group410isthebestintheentireworld; MultipleActiveResultSets = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.EorW)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude1).HasColumnName("Latitude_1");

                entity.Property(e => e.Latitude2).HasColumnName("Latitude_2");

                entity.Property(e => e.Longitude1).HasColumnName("Longitude_1");

                entity.Property(e => e.Longitude2).HasColumnName("Longitude_2");

                entity.Property(e => e.NorS)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Artifact>(entity =>
            {
                entity.ToTable("Artifact");

                entity.Property(e => e.ArtifactId).HasColumnName("ArtifactID");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.DateFound).HasColumnType("datetime");

                entity.Property(e => e.QuadrantCardinalityId).HasColumnName("Quadrant_Cardinality_ID");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Artifacts)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Artifact__AreaID__6754599E");

                entity.HasOne(d => d.QuadrantCardinality)
                    .WithMany(p => p.Artifacts)
                    .HasForeignKey(d => d.QuadrantCardinalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Artifact__Quadra__68487DD7");
            });

            modelBuilder.Entity<CarbonDating>(entity =>
            {
                entity.HasKey(e => e.C14sample)
                    .HasName("PK__CarbonDa__CC99662CD3C5E317");

                entity.ToTable("CarbonDating");

                entity.Property(e => e.C14sample).HasColumnName("C14Sample");

                entity.Property(e => e.ArtifactId).HasColumnName("ArtifactID");

                entity.Property(e => e.Calibrated95CalendarDateAvg).HasColumnName("Calibrated_95%_Calendar_Date_AVG");

                entity.Property(e => e.Calibrated95CalendarDateMax).HasColumnName("Calibrated_95%_Calendar_Date_MAX");

                entity.Property(e => e.Calibrated95CalendarDateMin).HasColumnName("Calibrated_95%_Calendar_Date_MIN");

                entity.Property(e => e.Calibrated95CalendarDateSpan).HasColumnName("Calibrated_95%_Calendar_Date_SPAN");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Conventional14cAgeBp).HasColumnName("Conventional_14C_Age_BP");

                entity.Property(e => e.LabNotes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Questions)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artifact)
                    .WithMany(p => p.CarbonDatings)
                    .HasForeignKey(d => d.ArtifactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarbonDat__Artif__6E01572D");
            });

            modelBuilder.Entity<HumanSample>(entity =>
            {
                entity.HasKey(e => e.HumanId)
                    .HasName("PK__HumanSam__119BA79CA826385B");

                entity.ToTable("HumanSample");

                entity.Property(e => e.HumanId).HasColumnName("HumanID");

                entity.Property(e => e.AgeMethod)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ArtifactId).HasColumnName("ArtifactID");

                entity.Property(e => e.ArtifactsDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BasilarSuture)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CranialId).HasColumnName("CranialID");

                entity.Property(e => e.CranialSuture)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionOfTaken)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EpiphysealUnion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GeFunctionTotal).HasColumnName("GE_FunctionTotal");

                entity.Property(e => e.GenderBody)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GenderGiles)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HairColor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HeadDirection)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MedialIpramus).HasColumnName("MedialIPRamus");

                entity.Property(e => e.Osteophytosis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PathologyAnomalies)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PreservationIndex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PubicSymphysis)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ToothAttrition)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ToothEruption)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artifact)
                    .WithMany(p => p.HumanSamples)
                    .HasForeignKey(d => d.ArtifactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HumanSamp__Artif__70DDC3D8");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.ArtifactId).HasColumnName("ArtifactID");

                entity.Property(e => e.ImagePointer)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Image_Pointer");

                entity.HasOne(d => d.Artifact)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ArtifactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Images__Artifact__6B24EA82");
            });

            modelBuilder.Entity<MiscSample>(entity =>
            {
                entity.HasKey(e => e.SampleId)
                    .HasName("PK__MiscSamp__8B99EC0AA20F5073");

                entity.ToTable("MiscSample");

                entity.Property(e => e.SampleId).HasColumnName("SampleID");

                entity.Property(e => e.ArtifactId).HasColumnName("ArtifactID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.HumanId).HasColumnName("HumanID");

                entity.HasOne(d => d.Artifact)
                    .WithMany(p => p.MiscSamples)
                    .HasForeignKey(d => d.ArtifactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MiscSampl__Artif__73BA3083");

                entity.HasOne(d => d.Human)
                    .WithMany(p => p.MiscSamples)
                    .HasForeignKey(d => d.HumanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MiscSampl__Human__74AE54BC");
            });

            modelBuilder.Entity<QuadrantCardinality>(entity =>
            {
                entity.ToTable("Quadrant_Cardinality");

                entity.Property(e => e.QuadrantCardinalityId).HasColumnName("Quadrant_Cardinality_ID");

                entity.Property(e => e.Cardinality)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
