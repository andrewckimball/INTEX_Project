using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEXII_App.Models.ViewModels
{

    // this view model is to pass both the list of burials as well as 
    // a specific burial to the view to display comparison information
    public class DetailListViewModel
    {

        public DetailListViewModel()
        { }



        public DbSet<Burial> Burials { get; set; }

        public Burial DetailBurial { get; set; }
    }

    
}
