using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace INTEXII_App.Models.ViewModels
{
    public class ImageUploadViewModel
    {
        public ImageUploadViewModel()
        {
            
        }

        public Image Images { get; set; }

        [Required]
        [Display(Name = "File")]
        public IFormFile fileForm { get; set; }

        public string type { get; set; }

        public string BurialId { get; set; }

        public string ImagePodecimaler { get; set; }
    }
}
