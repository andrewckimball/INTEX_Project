using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class BYU_ExcavationContext : DbContext
    {
        public BYU_ExcavationContext()
        {
        }

        public BYU_ExcavationContext(DbContextOptions<BYU_ExcavationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Artifact> Artifacts { get; set; }
        public virtual DbSet<BiologicalSample> BiologicalSamples { get; set; }
        public virtual DbSet<Burial> Burials { get; set; }
        public virtual DbSet<CarbonDating> CarbonDatings { get; set; }
        public virtual DbSet<FieldBook> FieldBooks { get; set; }
        public virtual DbSet<FieldBookEntry> FieldBookEntries { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Square> Squares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = intexii-db.cbixfz3dr1wn.us-east-1.rds.amazonaws.com; Database = BYU_Excavation; User Id= Group410; Password = group410isthebestintheentireworld; MultipleActiveResultSets = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");

                entity.Property(e => e.AreaId)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AreaID");

                entity.Property(e => e.Area1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Area");
            });

            modelBuilder.Entity<Artifact>(entity =>
            {
                entity.ToTable("Artifact");

                entity.Property(e => e.ArtifactId)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ArtifactID");

                entity.Property(e => e.BurialId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("BurialID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.Artifacts)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Artifact__Burial__7A3223E8");
            });

            modelBuilder.Entity<BiologicalSample>(entity =>
            {
                entity.ToTable("BiologicalSample");

                entity.Property(e => e.BiologicalSampleId)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BiologicalSampleID");

                entity.Property(e => e.BurialId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("BurialID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Initials)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SampleBag)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleRack)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.BiologicalSamples)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Biologica__Buria__719CDDE7");
            });

            modelBuilder.Entity<Burial>(entity =>
            {
                entity.ToTable("Burial");

                entity.Property(e => e.BurialId)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BurialID");

                entity.Property(e => e.AgeCodeSingle)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AgeMethod)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AreaHillBurials).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.AreaId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("AreaID");

                entity.Property(e => e.Bag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BasilarSuture)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BasionBregmaHeight).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BasionNasion).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BasionProsthionLength).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BizygomaticDiameter).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BodyAnalysisYear).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BoneLength).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BurialAdultChild)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BurialDepth).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BurialGenderMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BurialNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BurialPreservation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BurialWrapping)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Byusample).HasColumnName("BYUSample");

                entity.Property(e => e.ClusterNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CranialSuture)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateFound).HasColumnType("datetime");

                entity.Property(e => e.DateOnSkull).HasColumnType("datetime");

                entity.Property(e => e.DecimalerorbitalBreadth)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("decimalerorbitalBreadth");

                entity.Property(e => e.Description)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionOfTaken)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.DorsalPitting).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EastToFeet).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EastToHead).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EpiphysealUnion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EstimateLivingStature).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EstimatedAge)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FaceBundle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FemurDiameter).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FemurHead).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FemurLength).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ForemanMagnum).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.GeFunctionTotal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("GE_FunctionTotal");

                entity.Property(e => e.GenderCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gonian).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.HairColor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HeadDirection)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Humerus).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.HumerusHead).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.HumerusLength).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IliacCrest).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LengthCm)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("LengthCM");

                entity.Property(e => e.LengthM).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaximumCranialBreadth).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaximumCranialLength).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaximumNasalBreadth).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MedialClavicle).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MedialIpramus)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("MedialIPRamus");

                entity.Property(e => e.NasionProsthion).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.NorthToFeet).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.NorthToHead).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.NuchalCrest).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrbitEdge).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OsteologyUnknownComment)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Osteophytosis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ParietalBossing).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PathologyAnomalies)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PoroticHyperotosisLocations)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreaurSulcus).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PreservationIndex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PubicBone).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PubicSymphysis)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Rack)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Robust).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SampleNumber).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SciaticNotch).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SexBody)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SexGiles)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Shelf)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SouthToFeet).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SouthToHead).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SquareId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("SquareID");

                entity.Property(e => e.SubPubicAngle).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SupraorbitalRidges).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TibiaLength).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TmjOa).HasColumnName("TMJ_OA");

                entity.Property(e => e.Tomb).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ToothAttrition)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ToothEruption)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VentralArc).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WestToFeet).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WestToHead).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ZygomaticCrest).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Burials)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Burial__AreaID__690797E6");

                entity.HasOne(d => d.Square)
                    .WithMany(p => p.Burials)
                    .HasForeignKey(d => d.SquareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Burial__SquareID__681373AD");
            });

            modelBuilder.Entity<CarbonDating>(entity =>
            {
                entity.ToTable("CarbonDating");

                entity.Property(e => e.CarbonDatingId)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CarbonDatingID");

                entity.Property(e => e.BurialId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("BurialID");

                entity.Property(e => e.Calibrated95CalendarDateAvg)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Calibrated_95%_Calendar_Date_AVG");

                entity.Property(e => e.Calibrated95CalendarDateMax)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Calibrated_95%_Calendar_Date_MAX");

                entity.Property(e => e.Calibrated95CalendarDateMin)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Calibrated_95%_Calendar_Date_MIN");

                entity.Property(e => e.Calibrated95CalendarDateSpan)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Calibrated_95%_Calendar_Date_SPAN");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Conventional14cAgeBp)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Conventional_14C_Age_BP");

                entity.Property(e => e.Foci).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LabNotes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Questions)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.SizeMl).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TubeNumber).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.CarbonDatings)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarbonDat__Buria__74794A92");
            });

            modelBuilder.Entity<FieldBook>(entity =>
            {
                entity.ToTable("FieldBook");

                entity.Property(e => e.FieldBookId)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FieldBookID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FieldBookEntry>(entity =>
            {
                entity.ToTable("FieldBookEntry");

                entity.Property(e => e.FieldBookEntryId)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FieldBookEntryID");

                entity.Property(e => e.BurialId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("BurialID");

                entity.Property(e => e.CheckerInitials)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExpertInitials)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FieldBookId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("FieldBookID");

                entity.Property(e => e.PageNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.FieldBookEntries)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FieldBook__Buria__6EC0713C");

                entity.HasOne(d => d.FieldBook)
                    .WithMany(p => p.FieldBookEntries)
                    .HasForeignKey(d => d.FieldBookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FieldBook__Field__6DCC4D03");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageId)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ImageID");

                entity.Property(e => e.BurialId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("BurialID");

                entity.Property(e => e.ImagePodecimaler)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Image_Podecimaler");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Images__BurialID__7755B73D");
            });

            modelBuilder.Entity<Square>(entity =>
            {
                entity.ToTable("Square");

                entity.Property(e => e.SquareId)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SquareID");

                entity.Property(e => e.BurialLocationEw)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("BurialLocationEW");

                entity.Property(e => e.BurialLocationNs)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("BurialLocationNS");

                entity.Property(e => e.HighPairEw)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("HighPairEW");

                entity.Property(e => e.HighPairNs)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("HighPairNS");

                entity.Property(e => e.LowPairEw)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("LowPairEW");

                entity.Property(e => e.LowPairNs)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("LowPairNS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
