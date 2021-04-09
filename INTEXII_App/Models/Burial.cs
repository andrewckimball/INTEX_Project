using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class Burial
    {
        public Burial()
        {
            Artifacts = new HashSet<Artifact>();
            BiologicalSamples = new HashSet<BiologicalSample>();
            CarbonDatings = new HashSet<CarbonDating>();
            FieldBookEntries = new HashSet<FieldBookEntry>();
            Images = new HashSet<Image>();
        }

        public decimal BurialId { get; set; }
        public decimal SquareId { get; set; }
        public decimal AreaId { get; set; }
        public string BurialNumber { get; set; }
        public decimal SouthToHead { get; set; }
        public decimal SouthToFeet { get; set; }
        public decimal WestToHead { get; set; }
        public decimal WestToFeet { get; set; }
        public decimal Length { get; set; }
        public decimal Depth { get; set; }
        public bool PhotoTaken { get; set; }
        public bool BurialGoods { get; set; }
        public DateTime? DateFound { get; set; }
        public string ClusterNumber { get; set; }
        public decimal? SampleNumber { get; set; }
        public string Rack { get; set; }
        public string Shelf { get; set; }
        public string Bag { get; set; }
        public bool? PreviouslySampled { get; set; }
        public string SexBody { get; set; }
        public string SexGiles { get; set; }
        public decimal? GeFunctionTotal { get; set; }
        public string Description { get; set; }
        public string BasilarSuture { get; set; }
        public decimal? VentralArc { get; set; }
        public decimal? SubPubicAngle { get; set; }
        public decimal? SciaticNotch { get; set; }
        public decimal? PubicBone { get; set; }
        public decimal? PreaurSulcus { get; set; }
        public decimal? MedialIpramus { get; set; }
        public decimal? DorsalPitting { get; set; }
        public decimal? ForemanMagnum { get; set; }
        public decimal? FemurHead { get; set; }
        public decimal? HumerusHead { get; set; }
        public string Osteophytosis { get; set; }
        public string PubicSymphysis { get; set; }
        public decimal? BoneLength { get; set; }
        public decimal? MedialClavicle { get; set; }
        public decimal? IliacCrest { get; set; }
        public decimal? FemurDiameter { get; set; }
        public decimal? Humerus { get; set; }
        public decimal? FemurLength { get; set; }
        public decimal? HumerusLength { get; set; }
        public decimal? TibiaLength { get; set; }
        public decimal? Robust { get; set; }
        public decimal? SupraorbitalRidges { get; set; }
        public decimal? OrbitEdge { get; set; }
        public decimal? ParietalBossing { get; set; }
        public decimal? Gonian { get; set; }
        public decimal? NuchalCrest { get; set; }
        public decimal? ZygomaticCrest { get; set; }
        public string CranialSuture { get; set; }
        public decimal? MaximumCranialLength { get; set; }
        public decimal? MaximumCranialBreadth { get; set; }
        public decimal? BasionBregmaHeight { get; set; }
        public decimal? BasionNasion { get; set; }
        public decimal? BasionProsthionLength { get; set; }
        public decimal? BizygomaticDiameter { get; set; }
        public decimal? NasionProsthion { get; set; }
        public decimal? MaximumNasalBreadth { get; set; }
        public decimal? DecimalerorbitalBreadth { get; set; }
        public string HairColor { get; set; }
        public string PreservationIndex { get; set; }
        public bool? HairTaken { get; set; }
        public bool? SoftTissueTaken { get; set; }
        public bool? BoneTaken { get; set; }
        public bool? ToothTaken { get; set; }
        public bool? TextileTaken { get; set; }
        public string DescriptionOfTaken { get; set; }
        public bool? ArtifactFound { get; set; }
        public string EstimatedAge { get; set; }
        public string AgeMethod { get; set; }
        public decimal? EstimateLivingStature { get; set; }
        public string ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string PathologyAnomalies { get; set; }
        public string EpiphysealUnion { get; set; }
        public string HeadDirection { get; set; }
        public bool? Byusample { get; set; }
        public decimal? BodyAnalysisYear { get; set; }
        public bool? SkullAtMagazine { get; set; }
        public bool? PostcraniaAtMagazine { get; set; }
        public bool? ToBeConfirmed { get; set; }
        public bool? SkullTrauma { get; set; }
        public bool? PostcraniaTrauma { get; set; }
        public bool? CribiaOrbitala { get; set; }
        public bool? PoroticHyperotosis { get; set; }
        public string PoroticHyperotosisLocations { get; set; }
        public bool? MetopicSuture { get; set; }
        public bool? ButtonOsteoma { get; set; }
        public string OsteologyUnknownComment { get; set; }
        public bool? TmjOa { get; set; }
        public bool? LinearHypoplasiaEnamel { get; set; }
        public decimal? AreaHillBurials { get; set; }
        public decimal? Tomb { get; set; }
        public string BurialPreservation { get; set; }
        public string BurialWrapping { get; set; }
        public string BurialAdultChild { get; set; }
        public string GenderCode { get; set; }
        public string BurialGenderMethod { get; set; }
        public string AgeCodeSingle { get; set; }
        public string FaceBundle { get; set; }
        public DateTime? DateOnSkull { get; set; }

        public virtual Area Area { get; set; }
        public virtual Square Square { get; set; }
        public virtual ICollection<Artifact> Artifacts { get; set; }
        public virtual ICollection<BiologicalSample> BiologicalSamples { get; set; }
        public virtual ICollection<CarbonDating> CarbonDatings { get; set; }
        public virtual ICollection<FieldBookEntry> FieldBookEntries { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
