using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class Square
    {
        public Square()
        {
            Burials = new HashSet<Burial>();
        }

        public decimal SquareId { get; set; }
        public decimal LowPairNs { get; set; }
        public decimal HighPairNs { get; set; }
        public decimal LowPairEw { get; set; }
        public decimal HighPairEw { get; set; }
        public string BurialLocationNs { get; set; }
        public string BurialLocationEw { get; set; }


        public virtual ICollection<Burial> Burials { get; set; }
    }
}
