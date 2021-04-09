using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class BiologicalSample
    {
        public decimal BiologicalSampleId { get; set; }
        public decimal BurialId { get; set; }
        public string Description { get; set; }
        public string SampleRack { get; set; }
        public string SampleBag { get; set; }
        public bool PreviouslySampled { get; set; }
        public string Initials { get; set; }

        public virtual Burial Burial { get; set; }
    }
}
