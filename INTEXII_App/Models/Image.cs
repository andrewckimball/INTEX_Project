using System;
using System.Collections.Generic;

#nullable disable

namespace INTEXII_App.Models
{
    public partial class Image
    {
        public int ImageId { get; set; }
        public int ArtifactId { get; set; }
        public string ImagePointer { get; set; }

        public virtual Artifact Artifact { get; set; }
    }
}
