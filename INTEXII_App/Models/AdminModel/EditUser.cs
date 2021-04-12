using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INTEXII_App.Models.AdminModel
{
    //Edit user model to connect controller and EditUser view - contains all releveant information for users
    public class EditUser
    {
        public EditUser()
        {
            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //List of roles associated with the user
        public IList<string> Roles { get; set; }
    }
}
