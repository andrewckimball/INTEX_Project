using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEXII_App.Models.ViewModels
{
    public class DetailListViewModel
    {

        public DetailListViewModel()
        { }



        public DbSet<Burial> Burials { get; set; }

        public Burial DetailBurial { get; set; }
    }

    
}
