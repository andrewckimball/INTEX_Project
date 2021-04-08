using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class MiscSample
    {
        public int SampleId { get; set; }
        public int ArtifactId { get; set; }
        public int HumanId { get; set; }
        public string Description { get; set; }

        public virtual Artifact Artifact { get; set; }
        public virtual HumanSample Human { get; set; }
    }
}
