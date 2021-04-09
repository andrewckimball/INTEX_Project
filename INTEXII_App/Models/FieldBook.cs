using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class FieldBook
    {
        public FieldBook()
        {
            FieldBookEntries = new HashSet<FieldBookEntry>();
        }

        public decimal FieldBookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FieldBookEntry> FieldBookEntries { get; set; }
    }
}
