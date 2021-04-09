using System;
using System.Collections.Generic;

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
