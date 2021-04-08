using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class CarbonDating
    {
        public int C14sample { get; set; }
        public int ArtifactId { get; set; }
        public int? TubeNumber { get; set; }
        public int? SizeMl { get; set; }
        public int? Foci { get; set; }
        public string Location { get; set; }
        public string Questions { get; set; }
        public int? Conventional14cAgeBp { get; set; }
        public int? Calibrated95CalendarDateMax { get; set; }
        public int? Calibrated95CalendarDateMin { get; set; }
        public int? Calibrated95CalendarDateSpan { get; set; }
        public int? Calibrated95CalendarDateAvg { get; set; }
        public string Category { get; set; }
        public string LabNotes { get; set; }

        public virtual Artifact Artifact { get; set; }
    }
}
