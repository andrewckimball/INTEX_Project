using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class FieldBookEntry
    {
        public decimal FieldBookEntryId { get; set; }
        public decimal FieldBookId { get; set; }
        public decimal BurialId { get; set; }
        public string PageNumber { get; set; }
        public string ExpertInitials { get; set; }
        public string CheckerInitials { get; set; }

        public virtual Burial Burial { get; set; }
        public virtual FieldBook FieldBook { get; set; }
    }
}
