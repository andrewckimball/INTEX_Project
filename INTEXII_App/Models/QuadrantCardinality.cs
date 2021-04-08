using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class QuadrantCardinality
    {
        public QuadrantCardinality()
        {
            Artifacts = new HashSet<Artifact>();
        }

        public int QuadrantCardinalityId { get; set; }
        public string Cardinality { get; set; }

        public virtual ICollection<Artifact> Artifacts { get; set; }
    }
}
