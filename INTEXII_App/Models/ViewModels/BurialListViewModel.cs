using System;
using System.Collections.Generic;

namespace INTEXII_App.Models.ViewModels
{
    public class BurialListViewModel
    {
        public BurialListViewModel()
        {
        }

        public List<Area> Areas { get; set; }
        public List<Square> Squares { get; set; }
        public List<Burial> Burials { get; set; }
        public int RowCounter { get; set; } = 1;
    }
}
