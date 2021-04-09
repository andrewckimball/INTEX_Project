using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class Artifact
    {
        public decimal ArtifactId { get; set; }
        public decimal BurialId { get; set; }
        public string Description { get; set; }

        public virtual Burial Burial { get; set; }
    }
}
