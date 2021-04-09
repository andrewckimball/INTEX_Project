using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class Area
    {
        public Area()
        {
            Burials = new HashSet<Burial>();
        }

        public decimal AreaId { get; set; }
        public string Area1 { get; set; }

        public virtual ICollection<Burial> Burials { get; set; }
    }
}
