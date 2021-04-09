using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INTEXII_App.Models.AdminModel
{
    public class CreateRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}
