using System;
using System.Collections.Generic;

namespace INTEXII_App.Models.ViewModels
{
    public class BurialListViewModel
    {
        public BurialListViewModel()
        {
        }

        public IEnumerable<Area> Areas { get; set; }
        public IEnumerable<Square> Squares { get; set; }
        public IEnumerable<Burial> Burials { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public Square TempSquare { get; set; }
        public int RowCounter { get; set; } = 1;
    }
}
