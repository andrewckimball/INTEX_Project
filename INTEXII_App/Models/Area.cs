using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class Area
    {
        public Area()
        {
            Artifacts = new HashSet<Artifact>();
        }

        public int AreaId { get; set; }
        public int Latitude1 { get; set; }
        public int Latitude2 { get; set; }
        public string NorS { get; set; }
        public int Longitude1 { get; set; }
        public int Longitude2 { get; set; }
        public string EorW { get; set; }

        public virtual ICollection<Artifact> Artifacts { get; set; }
    }
}
