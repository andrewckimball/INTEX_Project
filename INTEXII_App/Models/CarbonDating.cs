using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class CarbonDating
    {
        public decimal CarbonDatingId { get; set; }
        public decimal BurialId { get; set; }
        public decimal? TubeNumber { get; set; }
        public decimal? SizeMl { get; set; }
        public decimal? Foci { get; set; }
        public string Location { get; set; }
        public string Questions { get; set; }
        public decimal? Conventional14cAgeBp { get; set; }
        public decimal? Calibrated95CalendarDateMax { get; set; }
        public decimal? Calibrated95CalendarDateMin { get; set; }
        public decimal? Calibrated95CalendarDateSpan { get; set; }
        public decimal? Calibrated95CalendarDateAvg { get; set; }
        public string Category { get; set; }
        public string LabNotes { get; set; }

        public virtual Burial Burial { get; set; }
    }
}
