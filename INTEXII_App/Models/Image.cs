using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


#nullable disable

namespace INTEXII_App.Models
{
    public partial class Image
    {
        public decimal ImageId { get; set; }
        public decimal BurialId { get; set; }
        public string ImagePodecimaler { get; set; }

        public virtual Burial Burial { get; set; }

    }
}
