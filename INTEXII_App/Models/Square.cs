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
            //SquareIdString = LowPairNs.ToString() + '/' + HighPairNs.ToString() + ' ' + BurialLocationNs + ' ' + LowPairEw.ToString() + '/' + HighPairEw.ToString() + ' ' + BurialLocationEw;
        }

        public decimal SquareId { get; set; }
        public decimal LowPairNs { get; set; }
        public decimal HighPairNs { get; set; }
        public decimal LowPairEw { get; set; }
        public decimal HighPairEw { get; set; }
        public string BurialLocationNs { get; set; }
        public string BurialLocationEw { get; set; }

        //public string SquareIdString { get; set; }

        public virtual ICollection<Burial> Burials { get; set; }
    }
}
