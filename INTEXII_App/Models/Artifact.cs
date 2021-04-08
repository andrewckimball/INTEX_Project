using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class Artifact
    {
        public Artifact()
        {
            CarbonDatings = new HashSet<CarbonDating>();
            HumanSamples = new HashSet<HumanSample>();
            Images = new HashSet<Image>();
            MiscSamples = new HashSet<MiscSample>();
        }

        public int ArtifactId { get; set; }
        public int AreaId { get; set; }
        public int QuadrantCardinalityId { get; set; }
        public DateTime? DateFound { get; set; }
        public bool? PreviouslySampled { get; set; }
        public int? BurialDepth { get; set; }
        public int? Rack { get; set; }
        public int? Bag { get; set; }
        public int BurialNumber { get; set; }

        public virtual Area Area { get; set; }
        public virtual QuadrantCardinality QuadrantCardinality { get; set; }
        public virtual ICollection<CarbonDating> CarbonDatings { get; set; }
        public virtual ICollection<HumanSample> HumanSamples { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<MiscSample> MiscSamples { get; set; }
    }
}
