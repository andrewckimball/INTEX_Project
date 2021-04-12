using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEXII_App.Models.AdminModel
{
    //Model to display all roles associated with a given user
    public class ManageUserRoles
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
